using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Print.Model;
using Print.Report;
using DevExpress.XtraReports.UI;
using System.Collections.Specialized;
using System.Deployment.Application;
using System.Web;
using Microsoft.Win32;
using Print.Report.Form_Kfzydd_3F;

namespace Print
{
    public partial class Form1 : Form
    {
        
        public Form1( )
        {
            InitializeComponent();
            
             
            RptEntry();
          
        }

        public void RptEntry( )
        {
            try
            {
                if (!ApplicationDeployment.IsNetworkDeployed)
                    return;

               

                string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                NameValueCollection  nameValueTable = HttpUtility.ParseQueryString(queryString);

                if (nameValueTable.Count == 0)
                    return;

                string form = nameValueTable["form"];
                string func = nameValueTable["func"];

                 
                if (form == "Form_THBJSearch")
                {
                    if (func == "jtdy")
                    {
                        RP_JTDJ rpt = new RP_JTDJ(nameValueTable);
                        using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                        {
                            // printTool.ShowPreviewDialog();
                            printTool.Print();
                        } 
                    }
                   
                }
                else if (form == "Form_Kfzydd_3F")
                {
                    if (func == "phd")
                    {
                        RP_JTDJ rpt = new RP_JTDJ(nameValueTable);
                        using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                        {
                             printTool.ShowPreviewDialog();
                           // printTool.Print();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

     
        //List<ReturnLabelObj> list = new List<ReturnLabelObj>();
        //list.Add(new ReturnLabelObj { ghdw = "haitian", bjlsh = "123", sum = 10, current = 2 });
        //list.Add(new ReturnLabelObj { ghdw = "haitian", bjlsh = "123", sum = 10, current = 3 });
        //list.Add(new ReturnLabelObj { ghdw = "haitian", bjlsh = "123", sum = 10, current = 7 });
        // ReturnLabel report = new ReturnLabel();
        //// report.DataSource = list;
        // documentViewer1.DocumentSource = report;
        // report.CreateDocument();

        //var list = from b in ctx.EMPLOYEES
        //           select b;
        //XtraReport2 report = new XtraReport2();
        //report.DataSource = list.ToList() ;
        //documentViewer1.DocumentSource = report;
        //report.CreateDocument();

        //   report.Print();
        //using (ReportPrintTool printTool = new ReportPrintTool(report))
        //{
        //    // Invoke the Print dialog.
        //   printTool.PrintDialog();
        //    report.p
        //    // Send the report to the default printer.
        //    //  printTool.Print();


        //}

        // using (WLEntities ctx = new WLEntities())
        //{
        //    var items = (from u in ctx.T_USER
        //                 select u).Take(1); 
        //    string sb = items.First().NAME + items.First().USR_ID;
        //    label1.Text = sb;

        //}

        //string url = "http://localhost/Forms/ClimbBug1.application?bjlsh=123";
        //Process.Start("rundll32.exe", "dfshim.dll,ShOpenVerbApplication " + url);

        private void button1_Click(object sender, EventArgs e)
        {

            NameValueCollection nameValueTable  = new NameValueCollection();
            nameValueTable.Add("p_bjlsh", "9595692");
            rpt_PhdHz rpt = new rpt_PhdHz(nameValueTable);
            //rpt.Parameters["ParamYtpch"].Value = "231892018050300900001";
            //rpt.Parameters["ParamYtpch"].Visible = false;
            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                // Invoke the Print dialog.
               //  printTool.PrintDialog();
               // printTool.Print();
               printTool.ShowPreviewDialog();
                // report.p
                // Send the report to the default printer.
                //  printTool.Print();


            }
            //Application.Exit();
            //MessageBox.Show(Environment.Version.ToString());
            //MessageBox.Show(Environment.Version.Major.ToString());
            //  GetVersionFromRegistry();
        }
    private static void GetVersionFromRegistry()
    {
            // Opens the registry key for the .NET Framework entry.
            List<string> listVersion = new List<string>();
            using (RegistryKey ndpKey = 
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
                OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                // or later, you can use:
                // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                
            foreach (string versionKeyName in ndpKey.GetSubKeyNames())
            {
                if (versionKeyName.StartsWith("v"))
                {

                    RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                    string name = (string)versionKey.GetValue("Version", "");
                    if (name != "")
                    {
                         listVersion.Add(versionKeyName);
                       Console.WriteLine(versionKeyName  );
                            continue;
                    } 
                    foreach (string subKeyName in versionKey.GetSubKeyNames())
                    {

                        listVersion.Add(versionKeyName+ " " + subKeyName);
                        Console.WriteLine(versionKeyName + " " + subKeyName);
                          
                         
                    }
                }
            }
        }

            if (listVersion.Contains("v4 Full") || listVersion.Contains("v4.0 Full"))
            {
                Console.WriteLine(   " zai"    );
            }
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            #if !DEBUG
            Application.Exit();
            #endif
        }



        private class DummyBackgroundTask
        {
            public DummyBackgroundTask()
            {

            }
        }
    }
}
