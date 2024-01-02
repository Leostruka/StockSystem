using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.Models
{
    public class UsuarioModel
    {
        public class User
        {
            public int id { get; }
            [Required]
            public string name { get; set; }
            [Required]
            public string cpf { get; set; }
            [Required]
            [EmailAddress]
            public string email { get; set; }
            [Required]
            public string user { get; set; }
            [Required]
            public SecureString password { get; set; }
        }
    }

}
