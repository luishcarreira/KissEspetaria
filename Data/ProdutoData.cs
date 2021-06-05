using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Inter_KissEspataria.Models;

namespace Inter_KissEspataria.Data
{
    public class ProdutoData : Data
    {
        public void Create(Produto produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = @"exec sp_produto_create @Descricao, @QtdEstoque, @Valor";

                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@QtdEstoque", produto.QtdEstoque);
                cmd.Parameters.AddWithValue("@Valor", produto.Valor);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }
        }

        public void Update(Produto produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "EXEC sp_produto_update @ProdutoId, @Descricao, @QtdEstoque, @Valor";

                cmd.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@QtdEstoque", produto.QtdEstoque);
                cmd.Parameters.AddWithValue("@Valor", produto.Valor);

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

                cmd.CommandText = @"exec sp_produto_delete @id";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }
        }

        public List<Produto> Read()
        {
            List<Produto> lista = new List<Produto>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"SELECT ProdutoId Id, Descricao, QtdEstque Estoque, Valor FROM Produtos";

                //execução do Select no BD
                //o reader vai receber o retorno do Select
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())//percorrendo a table até o EOF (End of File)
                {
                    Produto produto = new Produto();

                    produto.ProdutoId = (int)reader["Id"];
                    produto.Descricao = (string)reader["Descricao"];
                    produto.QtdEstoque = (int)reader["Estoque"];
                    produto.Valor = (decimal)reader["Valor"];

                    lista.Add(produto);
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return lista;
        }

        public Produto Read(int id)
        {
            Produto produto = null;

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;

                cmd.CommandText = @"SELECT ProdutoId Id, Descricao, QtdEstque Estoque, Valor
                                    FROM Produtos
                                    WHERE ProdutoId = @ProdutoId";

                cmd.Parameters.AddWithValue("@ProdutoId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    produto = new Produto
                    {
                        ProdutoId = (int)reader["Id"],
                        Descricao = (string)reader["Descricao"],
                        QtdEstoque = (int)reader["Estoque"],
                        Valor = (decimal)reader["Valor"]

                    };
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return produto;
        }
    }
}