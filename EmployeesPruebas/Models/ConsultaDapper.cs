using MySqlConnector;
using System.Collections.Generic;
using Dapper;

namespace EmployeesPruebas.Models
{
    public class ConsultaDapper
    {
        private string CadenaConexion = @"server=localhost;port=3306;user=root;database=main";
        public string consultaSQL { get; set; } = "";
        public IEnumerable<Models.Employee> ConectarBD()
        {
            IEnumerable<Models.Employee> lst = null;
            MySqlConnection db = new MySqlConnection(CadenaConexion);
            lst = db.Query<Models.Employee>(consultaSQL);
            return lst;
        }
    }
}
