using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoydCrudAdventures
{
    public static class DB
    {
        public static string getConnection()
        {
            return ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        }

    }
}
