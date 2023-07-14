using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace Projekt_DatabaseApp.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        private readonly string _connectionStringPlanets;

        public RepositoryBase()
        {
            _connectionString = "Server=(local); Database=LogInM; Integrated Security=true";
            _connectionStringPlanets = "Server=(local); Database=Planety_archiwum; Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected SqlConnection GetConnectionPlanety()
        {
            return new SqlConnection(_connectionStringPlanets);
        }
    }
}
