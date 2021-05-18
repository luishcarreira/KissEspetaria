using System;
using System.Data.SqlClient;

namespace Inter_KissEspataria.Data
{
    public abstract class Data : IDisposable
    {
        protected SqlConnection connectionDB;

        public Data()
        {
            try
            {
                //string de conexão como banco de dados
                string strConexao = @"Data Souce = localhost;
                            Initial Catalog = BDEcommerce;
                            User=SA; Password=Luis10072000";

                connectionDB = new SqlConnection(strConexao);
                //connectionDB.Open;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro do banco: " + ex);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}