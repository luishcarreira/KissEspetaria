using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Inter_KissEspataria.Models;

namespace Inter_KissEspataria.Data
{
    public class ComandaData : Data
    {
        public void Create(Comanda comanda)
        {
            SqlTransaction transaction = base.connectionDB.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.Transaction = transaction;
                cmd.CommandText = @"INSERT INTO Comandas
                                        (AtendenteId, GarconId, DataEmissao, ValorTotal, [Status], Observacao)
                                    VALUES(@AtendenteId, @GarconId, @DataEmissao, @ValorTotal, @Status, @Observacao);
                                    SELECT @@IDENTITY;";

                //@AtendenteId, @GarconId, @DataEmissao, @Status, @Observacao
                cmd.Parameters.AddWithValue("@AtendenteId", comanda.AtendenteId);
                cmd.Parameters.AddWithValue("@GarconId", comanda.GarconId);
                cmd.Parameters.AddWithValue("@DataEmissao", comanda.DataEmissao);
                cmd.Parameters.AddWithValue("@ValorTotal", comanda.valorTotal);
                cmd.Parameters.AddWithValue("@Status", comanda.Status);
                cmd.Parameters.AddWithValue("@Observacao", comanda.Observacao);

                //ExecuteScalar: executa a consula e retorna a primeira coluna da primeira linha
                // no conjunto de resultados retornado pela consulta
                //colunas ou linhas adicionais são ignorados

                int IdComanda = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (var item in comanda.Itens)
                {
                    SqlCommand cmdItem = new SqlCommand();
                    cmdItem.Connection = connectionDB;
                    cmdItem.Transaction = transaction;
                    cmdItem.CommandText = @"INSERT INTO ProdutoComandaItem
                                            VALUES(@ProdutoId, @ComandaId, @Quantidade, @ValorUnitario)";

                    cmdItem.Parameters.AddWithValue("@ProdutoId", item.Produto.ProdutoId);
                    cmdItem.Parameters.AddWithValue("@ComandaId", IdComanda);
                    cmdItem.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                    cmdItem.Parameters.AddWithValue("@ValorUnitario", item.Valor);

                    cmdItem.ExecuteNonQuery();
                }

                //Executa as inserções da transação nas tabelas
                transaction.Commit();
            }
            catch (Exception ex)
            {
                //desfaz as operações de insert caso dê algum problema e elas não
                //possam ser executadas
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }

        public List<Comanda> Read()
        {
            List<Comanda> lista = new List<Comanda>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"SELECT
                                        c.ComandaId Comanda,
                                        c.AtendenteId Atendente,
                                        c.GarconId Garçom,
                                        c.DataEmissao
                                    FROM Comandas C";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comanda comanda = new Comanda();

                    comanda.ComandaId = (int)reader["Comanda"];
                    comanda.AtendenteId = (int)reader["Atendente"];
                    comanda.GarconId = (int)reader["Garçom"];
                    comanda.DataEmissao = (DateTime)reader["DataEmissao"];

                    lista.Add(comanda);
                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro: " + sqlerror);
            }

            return lista;
        }
    }
}