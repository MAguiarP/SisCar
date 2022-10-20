using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using Npgsql;

namespace DAL
{
    public static class ConnectionFactory
    {
        public static NpgsqlConnection Connect ()
        {
            NpgsqlConnection conn = new NpgsqlConnection 
                 ("Server=localhost; Port=5432;User id=postgres;password=1995;Database=CSHARP;"); 
            conn.Open ();
            return conn;
        }
    }
}
