using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDC_database_app
{
    class ConString
    {
        private static string _constr = @"Data Source=ELMERJR\SQLEXPRESS;Initial Catalog=GDC_test_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string GetConString()
        {
            return _constr;
        }
    
        public static void SetConString(string constr)
        {
            _constr = constr;
        } 
    
    
    }

    
}
