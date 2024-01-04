using CRUD_Forms.Data;
using StockSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.ViewModel
{
    class CurrentUserViewModel
    {
        public DataTable SetCurrent(string user)
        {
            // Modifique a autenticação para consultar o banco de dados
            SQL sql = new SQL();
            DataTable dt = sql.FindUser(user);

            return dt;
        }
    }
}
