using GerenciamentoCursoSimplificadoAPI.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursoSimplificadoAPI.Connector
{
    public class Conn
    {
        private string connstring;

        public Conn()
        {
            connstring = @"server=localhost;userid=root;password=06190424av;database=sistemagerenciamentocursos";
        }

        public Aluno RealizarLogin(string email)
        {
            Aluno aluno = null;

            using (MySqlConnection connMySql = new MySqlConnection(connstring))
            {
                using (MySqlCommand cmdMySql = connMySql.CreateCommand())
                {
                    cmdMySql.CommandText = $"SELECT * from aluno where email = '{email}';";
                    cmdMySql.CommandType = System.Data.CommandType.Text;
                    cmdMySql.Connection = connMySql;

                    connMySql.Open();

                    using (MySqlDataReader reader = cmdMySql.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aluno = new Aluno() { Nome = reader.GetString(reader.GetOrdinal("nome")), Senha = reader.GetString(reader.GetOrdinal("senha")) };
                        }
                    }
                }

                connMySql.Close();
            }

            return aluno;
        }
    }
}
