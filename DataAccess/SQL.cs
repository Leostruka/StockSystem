using MySql.Data.MySqlClient;
using StockSystem.DataAccess;
using StockSystem.Models;
using System;
using System.Data;
using System.Windows;

namespace CRUD_Forms.Data
{
    public class SQL
    {
        MySqlCommand sql;

        // Método para executar comandos SQL
        private void SQLConnection(string cmd)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            sql = new MySqlCommand(cmd, con.con);
            sql.ExecuteNonQuery();
            con.CloseConnection();
        }

        // Método para inserir usuário no banco de dados
        public DataTable Insert(UsuarioModel.User user)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            sql = new MySqlCommand("INSERT INTO employee (name, cpf, email, user, password) values(@name, @cpf, @email, @user, @password)", con.con);
            sql.Parameters.AddWithValue("@name", user.name);
            sql.Parameters.AddWithValue("@cpf", user.cpf);
            sql.Parameters.AddWithValue("@email", user.email);
            sql.Parameters.AddWithValue("@user", user.user);
            sql.Parameters.AddWithValue("@password", user.password);

            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.CloseConnection();
            return dt;
        }

        // Método para autenticar usuário no banco de dados
        public DataTable Authenticate(string user, string password)
        {
            Connection con = new Connection();
            con.AbrirConexao();

            var sql = new MySqlCommand("SELECT * FROM profile WHERE user = @user AND password = @password", con.con);
            sql.Parameters.AddWithValue("@user", user);
            sql.Parameters.AddWithValue("@password", password);

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);
            DataTable data = new DataTable();
            adapter.Fill(data);

            con.CloseConnection();
            return data;
        }

        // Método para atualizar usuário no banco de dados
        public void Update(int id, string name, string cpf, string email)
        {
            SQLConnection("UPDATE employee SET name = '" + name + "', cpf = '" + cpf + "' , email = '" + email + "' WHERE id = " + id);
        }

        // Método para remover usuário do banco de dados
        public void Remove(int id)
        {
            try
            {
                SQLConnection("DELETE FROM employee WHERE id =" + id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // Método para listar banco de dados no DataGridView
        public DataTable Listar()
        {
            // Cria uma instância da classe Connection para gerenciar a conexão com o banco de dados
            Connection con = new Connection();
            con.AbrirConexao(); // Abre a conexão com o banco de dados
            var listar = new MySqlCommand("SELECT id, name, cpf, email FROM employee", con.con); // Cria um comando MySqlCommand para selecionar todos os registros da tabela "profile"
            MySqlDataAdapter adapter = new MySqlDataAdapter(listar); // Cria um adaptador para executar o comando
            DataTable data = new DataTable(); // Cria um DataTable para armazenar os resultados
            adapter.Fill(data); // Preenche o DataTable com os resultados da consulta
            listar.ExecuteNonQuery(); // Executa o comando SQL
            con.CloseConnection(); // Fecha a conexão com o banco de dados

            return data; // Retorna o DataTable com os resultados
        }

        public DataTable ListarTemplate(int id)
        {
            // Cria uma instância da classe Connection para gerenciar a conexão com o banco de dados
            Connection con = new Connection();
            con.AbrirConexao(); // Abre a conexão com o banco de dados
            var sql = new MySqlCommand("SELECT id, name FROM employee WHERE id = '" + id + "'", con.con); // Cria um comando MySqlCommand para selecionar registros específicos da tabela "profile"
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql); // Cria um adaptador para executar o comando
            DataTable data = new DataTable(); // Cria um DataTable para armazenar os resultados
            adapter.Fill(data); // Preenche o DataTable com os resultados da consulta
            sql.ExecuteNonQuery(); // Executa o comando SQL
            con.CloseConnection(); // Fecha a conexão com o banco de dados
            return data; // Retorna o DataTable com os resultados
        }
    }
}
