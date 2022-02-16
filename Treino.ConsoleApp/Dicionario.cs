using System;
using System.Collections.Generic;
using Treino.ViewModels;

namespace Treino.ConsoleApp
{
    public class Dicionario
    {

        static void Main(string[] args)
        {
            //ListaTreino();
            //ListaNaoOrdenada();
            //ListaOrdenadaPorNome();
            //ListaOrdenadaPorIdade();

            //DicionarioTreino();
            //DicionarioPessoalModel();

            //HashSetTreino();
        }


        public static void DicionarioTreino()
        {
            Dictionary<string, int> dicionario = new Dictionary<string, int>();

            dicionario.Add("primeiro", 1);
            dicionario.Add("segundo", 2);
            dicionario.Add("terceiro", 3);

            //dicionario.Clear();
            //Console.WriteLine(dicionario.Count);
            //Console.WriteLine(dicionario.ContainsKey("primeiro"));
            //Console.WriteLine(dicionario.ContainsValue(1));
            //Console.WriteLine(dicionario.GetEnumerator());
            //Console.WriteLine(dicionario.GetType());
            //Console.WriteLine(dicionario.GetHashCode());
            //Console.WriteLine(dicionario.GetValueOrDefault("primeiro"));
            //Console.WriteLine(dicionario.TryAdd("quarto", 4));
            //Console.WriteLine(dicionario["primeiro"] = 8);

            foreach (KeyValuePair<string, int> items in dicionario)
            {
                if (dicionario.Count > 0)
                    Console.WriteLine(items.Key.ToString() + "  -  " + items.Value.ToString());
                //else if(dicionario.Count == 0)
                //    Console.WriteLine("Não há nenhum elemento no dicionário");

            }
        }
        public static void DicionarioPessoalModel()
        {
            Dictionary<string, PessoaModel> dicionarioPessoa = new Dictionary<string, PessoaModel>();

            dicionarioPessoa.Add("1", new PessoaModel() { id = "1" , name = "joao"});
            dicionarioPessoa.Add("2", new PessoaModel() { id = "2", name = "sa" });
            dicionarioPessoa.Add("3", new PessoaModel() { id = "3", name = "ds" });

            foreach (KeyValuePair<string, PessoaModel> items in dicionarioPessoa)
            {
                if (dicionarioPessoa.Count > 0)
                    Console.WriteLine("Chave: " + items.Key.ToString() + "  -  Id: " + items.Value.id.ToString() 
                        + " - Nome: " + items.Value.name.ToString());
            }

        }

        public static void DicionarioOrdenadoTreino()
        {
            SortedDictionary<string, int> dicionario = new SortedDictionary<string, int>();

            dicionario.Add("primeiro", 1);
            dicionario.Add("segundo", 2);
            dicionario.Add("terceiro", 3);

            //dicionario.Clear();
            //Console.WriteLine(dicionario.Count);
            //Console.WriteLine(dicionario.ContainsKey("primeiro"));
            //Console.WriteLine(dicionario.ContainsValue(1));
            //Console.WriteLine(dicionario.GetEnumerator());
            //Console.WriteLine(dicionario.GetType());
            //Console.WriteLine(dicionario.GetHashCode());
            //Console.WriteLine(dicionario.GetValueOrDefault("primeiro"));
            //Console.WriteLine(dicionario.TryAdd("quarto", 4));
            //Console.WriteLine(dicionario["primeiro"] = 8);

            foreach (KeyValuePair<string, int> items in dicionario)
            {
                if (dicionario.Count > 0)
                    Console.WriteLine(items.Key.ToString() + "  -  " + items.Value.ToString());
                //else if(dicionario.Count == 0)
                //    Console.WriteLine("Não há nenhum elemento no dicionário");

            }
        }

        public static void HashSetTreino()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);

                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }

            Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
            DisplaySet(evenNumbers);

            Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
            DisplaySet(oddNumbers);

            // Create a new HashSet populated with even numbers.
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(oddNumbers);

            Console.Write("numbers contains {0} elements: ", numbers.Count);
            DisplaySet(numbers);

            void DisplaySet(HashSet<int> collection)
            {
                Console.Write("{");
                foreach (int i in collection)
                {
                    Console.Write(" {0}", i);
                }
                Console.WriteLine(" }");
            }

        }
    }
}
