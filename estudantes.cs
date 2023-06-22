using System;
using System.Collections.Generic;
//using System_IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Runtime.Remoting.Messaging;

namespace student_manager
{
    internal class Estudantes
    {
        MEU_BD meuBancoDeDados = new MEU_BD();

        //função para inserir o estudante
        public bool inserirEstudante(string nome, string sobrenome, DateTime nascimento, string telefone, string genero, string endereco, MemoryStream foto)
        {
             MySqlCommand comando = new MySqlCommand("INSERT INTO `estudantes`(`nome`, `sobrenome`, `nascimento`, `genero`, `telefone`, `endereco`, `foto`) VALUES (@nm,@snm,@nsc,@gen,@tel,@end,@ft)", meuBancoDeDados.getConexao);
            comando.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nome;
            comando.Parameters.Add("@snm", MySqlDbType.VarChar).Value = sobrenome;
            comando.Parameters.Add("@nsc", MySqlDbType.Date).Value = nascimento;
            comando.Parameters.Add("@gen", MySqlDbType.VarChar).Value = genero;
            comando.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telefone;
            comando.Parameters.Add("@end", MySqlDbType.Text).Value = endereco;
            comando.Parameters.Add("@ft", MySqlDbType.LongBlob).Value = foto.ToArray();

            meuBancoDeDados.abrirConexao();
            if (comando.ExecuteNonQuery() == 1)
            {
                meuBancoDeDados.fecharConexao();
                return true;
            }
            else
            {
                meuBancoDeDados.fecharConexao();
                return false;
            }

            

        }
    }
}
