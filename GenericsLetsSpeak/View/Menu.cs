using System;
using System.Collections.Generic;
using BetterConsoleTables;
using LetsSpeak.Entity;
using Sharprompt;

namespace LetsSpeak.View
{
    public class Menu
    {
        private Dictionary<string, Action> MainMenu = new Dictionary<string, Action>();


        public void LoadMenu()
        {
            MainMenu.Clear();
            MainMenu.Add("Ver dicionário", Dictionary.ReadAll);
            MainMenu.Add("Adicionar termo", RenderSubmenuNewTerm);
            MainMenu.Add("Buscar termo", RenderSubmenuSearch);
            MainMenu.Add("Sair", () => { return; });

            //criada lista para poder usar no Sharprompt
            List<string> menuPrompt = new List<string>();
            foreach (var item in MainMenu)
            {
                menuPrompt.Add(item.Key);
            }

            var option = Prompt.Select("* MY LET'S DICTIONARY *", menuPrompt);
            SelectOption(option);
        }


        private void SelectOption(string option)
        {
            foreach (var item in MainMenu)
            {
                if(item.Key == option)
                {
                    item.Value.Invoke();
                }
            }

            if(option != "Sair")
                ReturnMainMenu();
        }


        private void ReturnMainMenu()
        {
            var answer = Prompt.Confirm("Voltar ao Menu Principal?");
            if (answer)
            {
                Console.Clear();
                LoadMenu();
            }
        }


        private void RenderSubmenuNewTerm()
        {
            Console.Clear();
            var word = Prompt.Input<string>("Digite o novo termo");
            var translation = Prompt.Input<string>("Digite a tradução");

            Dictionary.Include(word, translation);
        }


        private void RenderSubmenuSearch()
        {
            Console.Clear();
            var term = Prompt.Input<string>("Digite o termo que deseja buscar");

            Dictionary.Search(term);
        }
    }
}
