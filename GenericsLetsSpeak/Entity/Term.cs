namespace LetsSpeak.Entity
{
    internal class Term
    {
        public string Word { get; set; }
        public string Translation { get; set; }

        public Term(string word, string translation)
        {
            Word = word;
            Translation = translation;
        }
    }
}