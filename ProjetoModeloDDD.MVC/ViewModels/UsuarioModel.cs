using ProjetoModeloDDD.MVC.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class UsuarioModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        public static UsuarioModel ValidarUsuario(string login, string senha)
        {
            UsuarioModel ret = null;
            using (var con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=DEL;Initial Catalog=NotaFiscalEletronicaDB;Integrated Security=True;Encrypt=False";
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from usuario where login = @login and senha = @senha";

                    cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelper.hashMD5(senha);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ret = new UsuarioModel
                        {
                            Usuario = (string)reader["Login"],
                            Senha = (string)reader["Senha"],
                            Nome = (string)reader["NOME"]
                        };
                    }
                }
            }
            return ret;
        }
    }
}