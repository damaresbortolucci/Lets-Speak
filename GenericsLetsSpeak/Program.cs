using LetsSpeak.Data;
using LetsSpeak.View;

namespace LetsSpeak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Let's Speak";

            var Menu = new Menu();
            Menu.LoadMenu();
        }
    }
}