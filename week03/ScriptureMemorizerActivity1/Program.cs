//Author : Diogo Rangel Dos Santos

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Scripture Memorizer Program!");

        List<Scripture> scriptures = LoadScripturesFromFile("cse210-projects/week03/ScriptureMemorizer/scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in file.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            scripture.Display();
            Console.WriteLine("\nPress ENTER to hide words, or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input?.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
            if (scripture.IsFullyHidden())
            {
                scripture.Display();
                Console.WriteLine("\nAll words are hidden. Program ending...");
                break;
            }
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        if (!File.Exists(filename)) return scriptures;

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length != 2) continue;

            string referenceText = parts[0].Trim();
            string scriptureText = parts[1].Trim();

            string[] refParts = referenceText.Split(' ');
            string book = refParts[0];
            string[] chapterVerse = refParts[1].Split(':');
            int chapter = int.Parse(chapterVerse[0]);
            int startVerse, endVerse = 0;

            if (chapterVerse[1].Contains('-'))
            {
                string[] verses = chapterVerse[1].Split('-');
                startVerse = int.Parse(verses[0]);
                endVerse = int.Parse(verses[1]);
                scriptures.Add(new Scripture(new Reference(book, chapter, startVerse, endVerse), scriptureText));
            }
            else
            {
                startVerse = int.Parse(chapterVerse[1]);
                scriptures.Add(new Scripture(new Reference(book, chapter, startVerse), scriptureText));
            }
        }
        return scriptures;
    }
}