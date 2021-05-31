using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Inter_KissEspataria.Models;
using Inter_KissEspataria.Models.ViewModel;

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

        public List<PessoaAtendente> Read()
        {
            List<PessoaAtendente> lista = new List<PessoaAtendente>();

            //criando cmd (comando) para exucetar query SQL
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

                lista.Add(atendente);
            }

            return lista;
        }

        public PessoaAtendente Read(PessoaAtendenteViewModel model)
        {
            //declarando um objeto cliente e inicializando como null

            PessoaAtendente cliente = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;//conexão com o Banco de Dados

            //string SQL para ser executada no Banco de Dados
            cmd.CommandText = @"Select * from PessoasAtendente Where Login = @login and Senha = @senha";

            //inserindo o valor do id recebido a string SQL
            cmd.Parameters.AddWithValue("@login", model.Login);
            cmd.Parameters.AddWithValue("@senha", model.Senha);

            //Executando o comando SQL no Banco de Dados
            SqlDataReader reader = cmd.ExecuteReader();

            //verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                PessoaAtendente atendente = new PessoaAtendente
                {
                    PessoaId = (int)reader["PessoaId"],
                    Nome = (string)reader["Nome"],
                    CPF = (string)reader["CPF"],
                    Telefone = (string)reader["Telefone"],
                    Login = (string)reader["Login"],
                    Senha = (string)reader["Senha"],
                    Salario = (decimal)reader["Salario"],
                };
            }

            //retornando o objeto cliente, que pode ser null ou com as informações
            //recebidas na consulta
            return cliente;
        }
    }
}