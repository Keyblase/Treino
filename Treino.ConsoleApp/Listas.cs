using System;
using System.Collections.Generic;
using Treino.ViewModels;

namespace Treino.ConsoleApp
{
    public class Listas
    {
        static List<PessoaModel> pessoas;

        public static void ListaTreino()
        {
            pessoas = new List<PessoaModel>();
            pessoas.Add(new PessoaModel() { id = "1", name = "joao", age = "12", idade = 12 });
            pessoas.Add(new PessoaModel() { id = "2", name = "maria", age = "9", idade = 9 });
            pessoas.Add(new PessoaModel() { id = "3", name = "rodolfo", age = "17", idade = 17 });
            pessoas.Add(new PessoaModel() { id = "4", name = "ana", age = "11", idade = 11 });


            foreach (PessoaModel p in pessoas)
            {
                Console.WriteLine(p.id + " " + p.name);
            }
        }
        public static void ListaNaoOrdenada()
        {
            Console.WriteLine("Lista não ordenada");
            pessoas.ForEach(delegate (PessoaModel p)
            {
                Console.WriteLine(string.Format("{0} {1}", p.id, p.name));
            });
        }
        public static void ListaOrdenadaPorNome()
        {
            Console.WriteLine("Lista Ordenada por Nome");
            pessoas.Sort(delegate (PessoaModel p1, PessoaModel p2)
            {
                return p1.name.CompareTo(p2.name);
            });
            pessoas.ForEach(delegate (PessoaModel p)
            {
                Console.WriteLine(string.Format("{0} {1}", p.id, p.name));
            });
        }
        public static void ListaOrdenadaPorIdade()
        {
            Console.WriteLine("Lista Ordenada por Idade");
            pessoas.Sort(delegate (PessoaModel p1, PessoaModel p2)
            {
                return p1.idade.CompareTo(p2.idade);
            });
            pessoas.ForEach(delegate (PessoaModel p)
            {
                Console.WriteLine(value: string.Format("{0} {1}", p.age, p.name));
            });
        }
    }
}
