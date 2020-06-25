using System;

namespace RegisterReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string opt;
            do
            {
                Console.WriteLine("\t\t\tEscolha uma opção:\n1 - Lista de estações.\n2 - Lista de usuários.\n\nPressione ESC para sair!");
                opt = Console.ReadLine().Trim();

                if (opt.Equals("1"))
                {
                    StationRegisters.GetStations();
                    Console.WriteLine("Arquivos gerados com sucesso!");
                }
                else if (opt.Equals("2"))
                {
                    LerRegUser.GetUsers();
                    Console.WriteLine("Arquivos gerados com sucesso!");
                }
                else
                {
                    Console.WriteLine("Opção inexistente.");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
           
            Console.ReadKey();
        }
    }
}
