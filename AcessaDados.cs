using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaProtheus
{
    public class AcessaDados
    {
        private String connectionStringWindows ="Data Source=192.168.0.12;" +
                                                "Initial Catalog=P11_SQA;" +
                                                "Integrated Security=SSPI;";

        private String connectionString =   "Data Source=192.168.0.12;" +
                                            "Initial Catalog=P11_SQA;" +
                                            "User id=sa;" +
                                            "Password=sa#sigla;";

        private SqlConnection connection;
        public AcessaDados()
        {

        }

        public void desconectaDoBanco()
        {
            this.connection.Close();
            Console.WriteLine("Desconexão bem sucedida.");
        }

        public bool conectaAoBanco(){
            bool resultado = false;
            this.connection = new SqlConnection();

            this.connection.ConnectionString = this.connectionString;
            try
            {
                this.connection.Open();
                resultado = true;
                Console.WriteLine("Conexao bem sucedida.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Conexao falhou:");
                Console.WriteLine(e.Message);
            }
            return resultado;
            
        }

        public SqlDataReader executaConsulta(String consulta)
        {
            Console.WriteLine("Consultando...");
            return new SqlCommand(consulta,this.connection).ExecuteReader();
        }
    }
}
