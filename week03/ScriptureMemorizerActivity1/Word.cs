//Author : Diogo Rangel Dos Santos

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Word
{
    public string Original { get; }
    public string Hidden { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Original = text;
        Hidden = text;
        IsHidden = false;
    }

    public void Hide()
    {
        if (!IsHidden)
        {
            Hidden = new string('_', Original.Length);
            IsHidden = true;
        }
    }

    public override string ToString()
    {
        return Hidden;
    }
}