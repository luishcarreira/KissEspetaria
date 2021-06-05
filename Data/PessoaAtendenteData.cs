using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Inter_KissEspataria.Models;

namespace Inter_KissEspataria.Data
{
    public class PessoaAtendenteData : Data
    {
        public void Create(PessoaAtendente atendente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = @"exec sp_atendente_create @Nome, @CPF, 
                                    @Telefone, @Login, @Senha, @Salario, @Admin";

                cmd.Parameters.AddWithValue("@Nome", atendente.Nome);
                cmd.Parameters.AddWithValue("@CPF", atendente.CPF);
                cmd.Parameters.AddWithValue("@Telefone", atendente.Telefone);
                cmd.Parameters.AddWithValue("@Login", atendente.Login);
                cmd.Parameters.AddWithValue("@Senha", atendente.Senha);
                cmd.Parameters.AddWithValue("@Salario", atendente.Salario);
                cmd.Parameters.AddWithValue("@Admin", atendente.Admin);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }
        }

        public List<PessoaAtendente> Read()
        {
            List<PessoaAtendente> lista = new List<PessoaAtendente>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Select * From vw_atendente";

                //execução do Select no BD
                //o reader vai receber o retorno do Select
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())//percorrendo a table até o EOF (End of File)
                {
                    PessoaAtendente atendente = new PessoaAtendente();

                    atendente.PessoaId = (int)reader["Codigo"];
                    atendente.Nome = (string)reader["Nome"];
                    atendente.CPF = (string)reader["CPF"];
                    atendente.Telefone = (string)reader["Telefone"];
                    atendente.Login = (string)reader["Login"];
                    atendente.Salario = (decimal)reader["Salario"];
                    atendente.Admin = (string)reader["Administrador"];

                    lista.Add(atendente);
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return lista;
        }

        public PessoaAtendente Read(int id)
        {
            PessoaAtendente atendente = null;

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = @"EXEC sp_atendente_id @id";
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    atendente = new PessoaAtendente
                    {
                        PessoaId = (int)reader["Codigo"],
                        Nome = (string)reader["Nome"],
                        CPF = (string)reader["CPF"],
                        Telefone = (string)reader["Telefone"],
                        Login = (string)reader["Login"],
                        Salario = (decimal)reader["Salario"],
                        Admin = (string)reader["Administrador"]
                    };
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return atendente;
        }

        public void Update(PessoaAtendente atendente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "EXEC sp_atendente_update @pessoaid, @nome, @cpf, @telefone, @login, @senha, @salario, @admin";

                cmd.Parameters.AddWithValue("@pessoaid", atendente.PessoaId);
                cmd.Parameters.AddWithValue("@nome", atendente.Nome);
                cmd.Parameters.AddWithValue("@cpf", atendente.CPF);
                cmd.Parameters.AddWithValue("@telefone", atendente.Telefone);
                cmd.Parameters.AddWithValue("@login", atendente.Login);
                cmd.Parameters.AddWithValue("@senha", atendente.Senha);
                cmd.Parameters.AddWithValue("@salario", atendente.Salario);
                cmd.Parameters.AddWithValue("@admin", atendente.Admin);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }
        }

        public void Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = @"exec sp_atendente_delete @id";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }
        }

        public PessoaAtendente Read(PessoaAtendenteViewModel model)
        {
            PessoaAtendente atendente = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;//conexão com o Banco de Dados

                cmd.CommandText = @"SELECT  P.PessoaId AS Codigo,
                                            P.Nome,
                                            P.CPF,
                                            P.Telefone,
                                            PA.[Login],
                                            PA.Senha,
                                            PA.Salario,
                                            CASE PA.Admin
                                                    WHEN 1 THEN 'TRUE'
                                                    ELSE 'FALSE'
                                                END Administrador
                                        FROM Pessoas as P
                                            INNER JOIN PessoasAtendente AS PA
                                            ON P.PessoaId = PA.AtendenteId
                                        WHERE [Login] = @login AND Senha = @senha ";

                cmd.Parameters.AddWithValue("@login", model.Login);
                cmd.Parameters.AddWithValue("@senha", model.Senha);

                SqlDataReader reader = cmd.ExecuteReader();

                //verificando se, após a consulta, retornou um registro
                if (reader.Read())
                {
                    atendente = new PessoaAtendente
                    {
                        PessoaId = (int)reader["Codigo"],
                        Nome = (string)reader["Nome"],
                        CPF = (string)reader["CPF"],
                        Telefone = (string)reader["Telefone"],
                        Login = (string)reader["Login"],
                        Senha = (string)reader["Senha"],
                        Salario = (decimal)reader["Salario"],
                        Admin = (string)reader["Administrador"]
                    };
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return atendente;
        }
    }
}