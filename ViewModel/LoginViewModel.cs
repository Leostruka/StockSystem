using CRUD_Forms.Data;
using StockSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockSystem.ViewModel
{
    public class LoginViewModel
    {
        public bool Authenticate(string user, string password)
        {
            // Modifique a autenticação para consultar o banco de dados
            SQL sql = new SQL();
            DataTable dt = sql.Authenticate(user, password);

            // Verifica se há alguma linha no DataTable retornado
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
