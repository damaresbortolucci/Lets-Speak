using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LetsSpeak.Data
{
    public class Database
    {
        private static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _dictionaryDb = Path.Combine(_rootDirectory, "dictionary.json");

        public static Dictionary<string, string> Dictionary = new Dictionary<string, string>();


        static Database()
        {
            InitializeDatabase();
        }


        public static void InitializeDatabase()
        {
            if (!File.Exists(_dictionaryDb))
            {
                Save();
            }
            Load();
        }


        public static void Load()
        {
            Dictionary<string, string> dicionaryDatabase = new Dictionary<string, string>();

            using (StreamReader file = File.OpenText(_dictionaryDb))
            {
                JsonSerializer serializer = new JsonSerializer();
                dicionaryDatabase = (Dictionary<string, string>)serializer.Deserialize(file, typeof(Dictionary<string, string>));
            }
            Dictionary.Clear();
            Dictionary = dicionaryDatabase;
        }


        public static void Save()
        {
            var path = _dictionaryDb;
            var contents = JsonConvert.SerializeObject(Dictionary, Formatting.Indented);
            File.WriteAllText(path, contents);

            Console.WriteLine("Dicionário atualizado.\n");
        }


        public static void Include(string word, string translation)
        {
            Dictionary.Add(word, translation);
            Save();
            Load();
        }
    }
}
