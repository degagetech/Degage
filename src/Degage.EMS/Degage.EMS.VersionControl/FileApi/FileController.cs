using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Cors;
using Degage.Extension;
using System.IO.MemoryMappedFiles;

namespace Degage.EMS.VersionControl.Controllers
{
    /// <summary>
    /// 简易文件服务，后续完善文件管理服务后替换
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class FileController : ControllerBase
    {
        public FileManager FilesManager { get; private set; }
        public ILogger Logger { get; private set; }
        public FileController(FileManager filesManager, ILogger<FileController> logger)
        {
            this.FilesManager = filesManager;
            this.Logger = logger;
        }
        [HttpGet("down/{fileId}/{offset:int=0}/{size:int=0}")]
        public async Task<IActionResult> DownloadFileAsync(String fileId,Int32 offset=0, Int32 size = 0)
        {
            if (!this.FilesManager.IsValidFileId(fileId))
            {
                this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                ResponsePacket packet = ResponsePacket.Create(false, "文件标识不合法！");
                return new JsonResult(packet);
            }
            Stream stream = null;
            try
            {
                if (!await this.FilesManager.IsExistsFileAsync(fileId))
                {
                    this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.NotFound;
                    ResponsePacket packet = ResponsePacket.Create(false, "文件标识无效！");
                    return new JsonResult(packet);
                }
                stream = await this.FilesManager.GetFileStreamAsync(fileId);
                var mimeType = this.GetMimeType(fileId);
                if (offset > 0)
                {
                    stream.Seek(offset, SeekOrigin.Begin);
                }

                if (size > 0)
                {
                    this.Response.ContentType = mimeType;
                    Int32 bufferSize = 8192;
                    Byte[] buffer = new Byte[bufferSize];
                    Int32 leftSize = size;
                    if (size > stream.Length)
                    {
                        leftSize = (Int32)stream.Length;
                        this.Response.ContentLength = stream.Length;
                    }
                    try
                    {
                        while (leftSize > 0)
                        {
                            if (leftSize < bufferSize)
                            {
                                bufferSize = leftSize;
                            }
                            Int32 count = stream.Read(buffer, 0, bufferSize);
                            leftSize -= count;
                            await this.Response.Body.WriteAsync(buffer, 0, count);
                        }
                         await this.Response.Body.FlushAsync();
                        return new EmptyResult();
                    }
                    finally
                    {
                        stream.Close();
                    }
                }
                else
                {
                    FileStreamResult streamResult = new FileStreamResult(stream, mimeType);
                    return streamResult;
                }
            }
            catch (Exception exc)
            {
                this.Logger.LogError(LoggingEvents.FileDownloadError.ToEventId(), exc, LoggingEvents.FileDownloadError.ToString());
                this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.InternalServerError;
                ResponsePacket packet = ResponsePacket.Create(false, "未能获取文件数据！");
                return new JsonResult(packet);
            }
            finally
            {
                this.Logger.LogInformation(LoggingEvents.FileDownload.ToEventId(), "文件下载：" + fileId);
            }
        }
        /// <summary>
        /// 获取文件对应的 Mime 类型
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        private String GetMimeType(String fileId)
        {
            var mimeType = MimeTypes.GetMimeType(fileId);
            return mimeType;
        }
        const Int32 FileUploadLimitSize = 200 * 1024 * 1024;
        [RequestFormLimits(MultipartBodyLengthLimit = FileUploadLimitSize)]
        [RequestSizeLimit(FileUploadLimitSize)]
        [HttpPost("upload")]
        public async Task<ActionResult<String>> UploadFile([FromForm]IFormFile file)
        {
            String fileName = file?.FileName;
            if (String.IsNullOrWhiteSpace(fileName))
            {
                this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                ResponsePacket packet = ResponsePacket.Create(false, "文件名称不合法！");
                return new JsonResult(packet);
            }
            //大于 200M 的不予上传
            if (file.Length >= FileUploadLimitSize)
            {
                this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                ResponsePacket packet = ResponsePacket.Create(false, "上传文件过大！");
                return new JsonResult(packet);
            }
            Stream stream = null;
            String fileId = null;

            try
            {
                stream = file.OpenReadStream();
                fileId = await this.FilesManager.AddFileAsync(fileName, stream);
                if (fileId.IsNullOrEmpty())
                {
                    this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.InternalServerError;
                    ResponsePacket packet = ResponsePacket.Create(false, "文件添加失败！");
                    return new JsonResult(packet);
                }
                return fileId;
            }
            catch (Exception exc)
            {
                this.Logger.LogError(LoggingEvents.FileUploadError.ToEventId(), exc, LoggingEvents.FileUploadError.ToString());
                this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.InternalServerError;
                ResponsePacket packet = ResponsePacket.Create(false, "文件保存失败！");
                return new JsonResult(packet);
            }
            finally
            {
                this.Logger.LogInformation(LoggingEvents.FileUpload.ToEventId(), $"文件上传：{file.FileName}，大小：{file.Length.ToString()}，分配标识：{fileId}");
            }
        }

        // POST api/values
        [HttpDelete("delete/{fileId}")]
        public async Task<IActionResult> DeleteFileAsync(String fileId)
        {
            ResponsePacket packet = ResponsePacket.Create(false, "删除失败，");
            try
            {
                if (!this.FilesManager.IsValidFileId(fileId))
                {
                    this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                    packet.Message += "文件标识不合法！";
                    return new JsonResult(packet);
                }
                if (!await this.FilesManager.IsExistsFileAsync(fileId))
                {
                    this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.NotFound;
                    packet.Message += "文件标识无效！";
                    return new JsonResult(packet);
                }
                if (await this.FilesManager.DeleteFileAsync(fileId))
                {
                    packet.Success = true;
                    packet.Message = "已删除！";
                }
                return new JsonResult(packet);
            }
            catch (Exception exc)
            {
                this.Logger.LogError(LoggingEvents.FileDeleteError.ToEventId(), exc, LoggingEvents.FileDeleteError.ToString());
                this.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.InternalServerError;
                packet.Message = "Error，文件删除执行时失败！";
                return new JsonResult(packet);
            }
            finally
            {
                this.Logger.LogInformation(LoggingEvents.FileDownload.ToEventId(), $"文件删除：{fileId}");
            }
        }
    }
}
