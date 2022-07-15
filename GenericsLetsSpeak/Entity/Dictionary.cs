using System;
using System.Collections.Generic;
using BetterConsoleTables;
using LetsSpeak.Data;

namespace LetsSpeak.Entity
{
    public static class Dictionary
    {

        public static void Include(string word, string translation)
        {
            if (word.Contains("?"))
                Console.WriteLine("\nO caracter '?' não é aceito.\n");
            else if (word.Contains("*"))
                Console.WriteLine("\nO caracter '*' não é aceito.\n");
            else if (Database.Dictionary.ContainsKey(word))
                Console.WriteLine("Termo já registrado no seu dicionário.");
            else
                Database.Include(word, translation);
        }


        public static void Search(string word)
        {
            var count = 0;
            foreach (var term in Database.Dictionary)
            {
                if (term.Key.Contains(word, StringComparison.InvariantCultureIgnoreCase))
                {
                    count++;
                    Console.WriteLine($"{term.Key}: {term.Value}");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Nenhum termo encontrado.");
            }
        }


        public static void ReadAll()
        {
            List<Term> dictionary = new List<Term>();

            //converte o Dictionary do BD p/ List para poder usar o BetterConsoleTables
            foreach (var item in Database.Dictionary)
            {
                dictionary.Add(new Term(item.Key, item.Value));
            }

            var table = new Table(TableConfiguration.MySql());
            table.From(dictionary);
            Console.WriteLine(table.ToString());
        }
    }
}
