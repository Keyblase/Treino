using System;
using System.IO;

namespace Treino.ConsoleApp
{
    public class EditorText
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Selecione uma opção");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");

            short op = short.Parse(Console.ReadLine());

            switch (op)
            {
                case 0: Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;               
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            var path = Console.ReadLine();
            using(var file = new StreamReader(path))
            {
                string txt = file.ReadToEnd();
                Console.WriteLine(txt);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto na tela");
            Console.WriteLine("=========================");

            string txt = "";
            do
            {
                txt += Console.ReadLine();
                txt += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(txt);
        }

        static void Salvar(string txt)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho voce deseja salvar?");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path))
            {
                file.Write(txt);
            }

            Console.WriteLine($"Arquivo {path} Salvo com Sucesso!");
            Menu();
        }
    }
}
