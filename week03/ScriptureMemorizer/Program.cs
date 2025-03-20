//Author : Diogo Rangel Dos Santos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
         ScriptureReference reference = new ScriptureReference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";

        // Criando o objeto Scripture com o texto
        Scripture scripture = new Scripture(reference, text);

        // Loop principal do programa
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Oculta 3 palavras a cada rodada
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Memorization complete!");
    }
}

// Classe que representa a referência bíblica
class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int VerseEnd { get; }

    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = verse;
    }

    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        return VerseStart == VerseEnd ?
            $"{Book} {Chapter}:{VerseStart}" :
            $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
    }
}

// Classe que representa uma palavra no versículo
class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

// Classe que representa o versículo completo
class Scripture
{
    private ScriptureReference Reference { get; }
    private List<Word> Words { get; }
    private Random random = new Random();

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetDisplayText()
    {
        return $"{Reference}\n{string.Join(" ", Words)}";
    }

    public void HideRandomWords(int count)
    {
        var availableWords = Words.Where(word => !word.IsHidden).ToList();
        if (availableWords.Count == 0) return;

        for (int i = 0; i < count && availableWords.Count > 0; i++)
        {
            int index = random.Next(availableWords.Count);
            availableWords[index].Hide();
            availableWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }
}