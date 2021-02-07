using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

namespace Print.Report.Form_Kfzydd_3F
{
    public partial class rpt_PhdHz : DevExpress.XtraReports.UI.XtraReport
    {
        string p_bjlsh;
        MainWebService.MainWebServiceSoapClient service = new MainWebService.MainWebServiceSoapClient();
        protected string errMsg;
        protected string selectSql;

        public rpt_PhdHz(NameValueCollection nameValueTable)
        {
            InitializeComponent();

            p_bjlsh = nameValueTable["p_bjlsh"];

            InitReport();
        }

        public void InitReport()
        {
            DataTable dtHz = service.ExecuteReturnTb(out errMsg, "JGWL.WindowsForm.WLScheduling.Form_Kfzydd_3F", "PhdHz", new string[]
                 {   "p_bjlsh:"+p_bjlsh });
            if (!string.IsNullOrEmpty(errMsg))
            {
                MessageBox.Show(errMsg);
                return;
            }

            if (dtHz.Rows.Count == 0)
            {
                MessageBox.Show("没有提取到包件头信息t_dfbj，");
                return;
            }

            DataTable dtMx = service.ExecuteReturnTb(out errMsg, "JGWL.WindowsForm.WLScheduling.Form_Kfzydd_3F", "PhdMx", 
                        new string[] {  "p_bjlsh:"+ p_bjlsh });
            if (!string.IsNullOrEmpty(errMsg))
            {
                MessageBox.Show(errMsg);
                return;
            }

             Parameters["ParamBjlsh"].Value = p_bjlsh;
            //Parameters["ParamYtpch"].Visible = false;
            // DetailReport.DataSource = dtMx;
            DataSource = dtHz;
            xrSubreport1.ReportSource.DataSource = dtMx;

        }
 
    }
}
