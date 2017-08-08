using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaProtheus
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Aperte <Enter> para iniciar");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Iniciando processamento...");

                    AcessaDados conexao = new AcessaDados();

                    if (conexao.conectaAoBanco())
                    {
                        String query = "select top 10 A1_NREDUZ from SA1020 order by R_E_C_N_O_ DESC";

                        SqlDataReader resultado = conexao.executaConsulta(query);

                        while (resultado.Read())
                        {
                            Console.WriteLine("Nome:{0}",resultado[0]);
                        }

                        conexao.desconectaDoBanco();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Um erro inesperado ocorreu. Log abaixo:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Aperte qualquer tecla para sair...");
                Console.ReadKey();
            }
        }
    }
}
