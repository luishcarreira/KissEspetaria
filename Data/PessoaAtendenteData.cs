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
                SqlCommand cmd = new SqlCommand("sp_atendente_create", base.connectionDB);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@Nome", atendente.Nome);
                cmd.Parameters.AddWithValue("@CPF", atendente.CPF);
                cmd.Parameters.AddWithValue("@Telefone", atendente.Telefone);
                cmd.Parameters.AddWithValue("@Salario", atendente.Salario);
                cmd.Parameters.AddWithValue("@Login", atendente.Login);
                cmd.Parameters.AddWithValue("@Senha", atendente.Senha);
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
                    atendente.Salario = (decimal)reader["Salario"];
                    atendente.Login = (string)reader["Login"];
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
                cmd.Connection = base.connectionDB;//conexão com o Banco de Dados

                cmd.CommandText = @"SELECT  P.PessoaId,
                                            P.Nome,
                                            P.CPF,
                                            P.Telefone,
                                            P.Salario,
                                            PA.[Login],
                                            PA.Senha,
                                            CASE PA.Admin
                                                    WHEN 1 THEN 'TRUE'
                                                    ELSE 'FALSE'
                                                END Administrador
                                        FROM Pessoas as P
                                            INNER JOIN PessoasAtendente AS PA
                                            ON P.PessoaId = PA.AtendenteId
                                        WHERE P.PessoaId = @PessoaId";

                cmd.Parameters.AddWithValue("@PessoaId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    atendente = new PessoaAtendente
                    {
                        PessoaId = (int)reader["PessoaId"],
                        Nome = (string)reader["Nome"],
                        CPF = (string)reader["CPF"],
                        Telefone = (string)reader["Telefone"],
                        Salario = (decimal)reader["Salario"],
                        Login = (string)reader["Login"],
                        Senha = (string)reader["Senha"],
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

        public List<PessoaViewModel> ReadName()
        {
            List<PessoaViewModel> lista = new List<PessoaViewModel>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Select Codigo, Nome From vw_atendente";

                //execução do Select no BD
                //o reader vai receber o retorno do Select
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())//percorrendo a table até o EOF (End of File)
                {
                    PessoaViewModel atendente = new PessoaViewModel();

                    atendente.PessoaId = (int)reader["Codigo"];
                    atendente.Nome = (string)reader["Nome"];

                    lista.Add(atendente);
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return lista;
        }

        public void Update(PessoaAtendente atendente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_atendente_update", base.connectionDB);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", atendente.Nome);
                cmd.Parameters.AddWithValue("@CPF", atendente.CPF);
                cmd.Parameters.AddWithValue("@Telefone", atendente.Telefone);
                cmd.Parameters.AddWithValue("@Salario", atendente.Salario);
                cmd.Parameters.AddWithValue("@Login", atendente.Login);
                cmd.Parameters.AddWithValue("@Senha", atendente.Senha);
                cmd.Parameters.AddWithValue("@Admin", atendente.Admin);

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
                SqlCommand cmd = new SqlCommand("sp_atendente_delete", base.connectionDB);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AtendenteId", id);

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
                                            P.Salario,
                                            PA.[Login],
                                            PA.Senha,
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
                        Salario = (decimal)reader["Salario"],
                        Login = (string)reader["Login"],
                        Senha = (string)reader["Senha"],
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