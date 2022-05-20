using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    public Sprite icon;
    public bool collected;

    public Word(string _word, Sprite _icon)
    {
        word = _word;
        icon = _icon;
        collected = false;
    }

    public void Collect()
    {
        collected = true;
    }

    public string toString()
    {
        return word + " " + collected;
    }
}
