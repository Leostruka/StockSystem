using System.Windows;
using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace StockSystem.DataAccess
{
    public class Connection
    {
        readonly string connection = "SERVER=localhost; DATABASE=stocksystem; UID=root; PWD=";
        public MySqlConnection con = null;

        public void AbrirConexao()
        {
            try
            {
                con = new MySqlConnection(connection);
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fechar conexão: " + ex.Message);
            }
        }
    }
}

