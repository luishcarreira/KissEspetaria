using System.Data;
using System.Data.SqlClient;
using Inter_KissEspataria.Models;

namespace Inter_KissEspataria.Data
{
    public class PessoaAtendenteData : Data
    {
        public void Create(PessoaAtendente atendente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"exec sp_atendente_create @Nome, @CPF, 
                                @Telefone, @Login, @Senha, @Salario";

            cmd.Parameters.AddWithValue("@Nome", atendente.Nome);
            cmd.Parameters.AddWithValue("@CPF", atendente.CPF);
            cmd.Parameters.AddWithValue("@Telefone", atendente.Telefone);
            cmd.Parameters.AddWithValue("@Login", atendente.Login);
            cmd.Parameters.AddWithValue("@Senha", atendente.Senha);
            cmd.Parameters.AddWithValue("@Salario", atendente.Salario);

            cmd.ExecuteNonQuery();
        }
    }
}