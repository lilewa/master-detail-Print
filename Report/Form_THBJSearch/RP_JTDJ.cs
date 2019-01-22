using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Print.Report
{
    public partial class RP_JTDJ : DevExpress.XtraReports.UI.XtraReport
    {
        MainWebService.MainWebServiceSoapClient service = new MainWebService.MainWebServiceSoapClient();
        protected string errMsg;
        protected string selectSql;
        string ytpch;
        string bjlsh;

        public RP_JTDJ(NameValueCollection  nameValueTable)
        {
            InitializeComponent();
            ytpch = nameValueTable["ytpch"];
            bjlsh = nameValueTable["bjlsh"];
            InitReport();
        }
        //7937693
        //2018011900750001
        //
          //  "p_ytpch:231892018050300900001", "p_bjlsh:8724523"
        public void InitReport()
        {
            DataTable dtHz = service.ExecuteReturnTb(out errMsg, this.GetType().ToString(), "JTDJ", new string[]
                 {   "p_bjlsh:"+bjlsh });
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
            
            DataTable dtMx = service.ExecuteReturnTb(out errMsg, this.GetType().ToString(), "JTMX", new string[]
            { "p_ytpch:"+ytpch, "p_bjlsh:"+bjlsh });
            if (!string.IsNullOrEmpty(errMsg))
            {
                MessageBox.Show(errMsg);
                return;
            }
            
            Parameters["ParamYtpch"].Value = ytpch;
            Parameters["ParamYtpch"].Visible = false;
            // DetailReport.DataSource = dtMx;
            DataSource = dtHz; 
            xrSubreport1.ReportSource.DataSource = dtMx;
           
        }
    }
}
