using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor takes the Reference object and the raw text string
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text by spaces and create a Word object for each
        string[] splitText = text.Split(' ');
        foreach (string wordString in splitText)
        {
            _words.Add(new Word(wordString));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Exceeding Requirements logic: Only pick from words that are NOT already hidden.
        List<Word> unhiddenWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                unhiddenWords.Add(word);
            }
        }

        // If all words are hidden, we don't need to do anything
        if (unhiddenWords.Count == 0) return;

        Random random = new Random();
        
        // Ensure we don't try to hide more words than are available
        int wordsToHide = Math.Min(numberToHide, unhiddenWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index); // Remove it from our temporary list so we don't pick it twice
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        // Combine the reference and the compiled scripture text
        return $"{_reference.GetDisplayText()} {scriptureText.TrimEnd()}";
    }

    public bool IsCompletelyHidden()
    {
        // Check if there are ANY words that are still visible
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}