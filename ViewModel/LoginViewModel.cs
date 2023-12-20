using StockSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockSystem.ViewModel
{
    public class LoginViewModel : UsuarioModel
    {
        public bool Authenticate(string user, string password)
        {
            if (user == "admin" && password == "admin")
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
