using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ednevnik_projekat
{
     class konekcija
    {
        static public SqlConnection Connect()
            {
            String cs = ConfigurationManager.ConnectionStrings["Home"].ConnectionString;
            SqlConnection veza = new SqlConnection(cs);
            return veza;
            }
            
    }
}
