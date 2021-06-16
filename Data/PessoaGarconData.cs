using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Inter_KissEspataria.Models;

namespace Inter_KissEspataria.Data
{
    public class PessoaGarconData : Data
    {
        public void Create(PessoaGarcon garcon)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_garcon_create", base.connectionDB);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@Nome", garcon.Nome);
                cmd.Parameters.AddWithValue("@CPF", garcon.CPF);
                cmd.Parameters.AddWithValue("@Telefone", garcon.Telefone);
                cmd.Parameters.AddWithValue("@ValorDia", garcon.valorDia);
                cmd.Parameters.AddWithValue("@Comissao", garcon.Comissao);
                cmd.Parameters.AddWithValue("@Ativo", garcon.Ativo);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }
        }

        public List<PessoaGarcon> Read()
        {
            List<PessoaGarcon> lista = new List<PessoaGarcon>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Select * From vw_garcon";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())//percorrendo a table até o EOF (End of File)
                {
                    PessoaGarcon garcon = new PessoaGarcon();

                    garcon.PessoaId = (int)reader["PessoaId"];
                    garcon.Nome = (string)reader["Nome"];
                    garcon.CPF = (string)reader["CPF"];
                    garcon.Telefone = (string)reader["Telefone"];
                    garcon.valorDia = (decimal)reader["ValorDia"];
                    garcon.Comissao = (decimal)reader["Comissao"];
                    garcon.Ativo = (string)reader["Ativo"];

                    lista.Add(garcon);
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return lista;
        }

        public PessoaGarcon Read(int id)
        {
            PessoaGarcon garcon = null;

            try
            {

                SqlCommand cmd = new SqlCommand("sp_garcon_id", base.connectionDB);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PessoaId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    garcon = new PessoaGarcon
                    {
                        PessoaId = (int)reader["PessoaId"],
                        Nome = (string)reader["Nome"],
                        CPF = (string)reader["CPF"],
                        Telefone = (string)reader["Telefone"],
                        valorDia = (decimal)reader["ValorDia"],
                        Comissao = (decimal)reader["Comissao"],
                        Ativo = (string)reader["Ativo"]
                    };
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return garcon;
        }

        public List<PessoaGarcon> ReadName()
        {
            List<PessoaGarcon> lista = new List<PessoaGarcon>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Select PessoaId, Nome From vw_garcon";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())//percorrendo a table até o EOF (End of File)
                {
                    PessoaGarcon garcon = new PessoaGarcon();

                    garcon.PessoaId = (int)reader["PessoaId"];
                    garcon.Nome = (string)reader["Nome"];

                    lista.Add(garcon);
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return lista;
        }

        public void Update(PessoaGarcon garcon)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_garcon_update", base.connectionDB);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PessoaId", garcon.PessoaId);
                cmd.Parameters.AddWithValue("@Nome", garcon.Nome);
                cmd.Parameters.AddWithValue("@CPF", garcon.CPF);
                cmd.Parameters.AddWithValue("@Telefone", garcon.Telefone);
                cmd.Parameters.AddWithValue("@ValorDia", garcon.valorDia);
                cmd.Parameters.AddWithValue("@Comissao", garcon.Comissao);
                cmd.Parameters.AddWithValue("@Ativo", garcon.Ativo);

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
                SqlCommand cmd = new SqlCommand("sp_garcon_delete", base.connectionDB);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GarconId", id);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }
        }
    }
}