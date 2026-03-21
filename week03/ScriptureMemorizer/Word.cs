using System;

public class Word
{
    // Private member variables (_underscoreCamelCase)
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Words are visible by default
    }

    // Behaviors (TitleCase)
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Creates a string of underscores equal to the length of the word
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}