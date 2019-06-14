let template_qms_iframe_dialog = `<el-dialog 
                :title='title'
                :visible.sync='dialogvisible'
                custom-class='qms-dialog'
                fullscreen='true'
                v-on:opened='dialogFormOpenedHandle'>
                <iframe  class='qms-content-iframe'  :src='address'></iframe>
                <div slot="footer" class="dialog-footer">
                    <el-button type="primary" v-on:click="confirmHandle">确 定</el-button>
                </div>
      </el-dialog>`;

Vue.component('qms-iframe-dialog',
    {
        props: ['count', 'dialogvisible','title','address' ],
        data: function () {
            return {
                adjuster:new DialogBodyAdjuster()
            };
        },
        methods:
        {
            dialogFormOpenedHandle: function () {
                this.adjuster.adjusting();
            },
            confirmHandle: function () {
                this.dialogvisible = false;
                this.$emit('update:dialogvisible', false);
            }
        },
        template: template_qms_iframe_dialog
    });