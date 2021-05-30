using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dts.Runtime;



namespace GDC_database_app
{
    class ExecuteSSIS
    {
        public string message = "";
        public void execPackage(string pkgaddress, string scraddress)
        {
            
            string pkgLocation = @pkgaddress;
            Package package;
            Application app;
            DTSExecResult result;
            Variables vars;
            app = new Application();
            package = app.LoadPackage(pkgLocation, null);
            vars = package.Variables;
            vars["Source_file"].Value = scraddress;//source file convert;
            //vars["Destination_file"].Value = "";//destination file convert;
            try { 
           
                result = package.Execute(null,vars,null,null,null);

            if(result == DTSExecResult.Success)
            {
                Console.WriteLine("Transfer Successfully");
                message = "Transfer Successfully";
            }
            else if (result == DTSExecResult.Failure)
            {
                Console.WriteLine("Transfer Failure");
                message = "Transfer Failed";
            }
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1);
            }

        }
    }
} //TO DO: 
  //ssis pacakge
  // 
