using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string text;
    public Sprite icon;
    public bool collected;

    public GameObject wordPrefab;

    public Word(string _word, Sprite _icon, GameObject _wordPrefab)
    {
        text = _word;
        icon = _icon;
        wordPrefab = _wordPrefab;
        collected = false;
    }

    public void Collect()
    {
        collected = true;
    }

    public string toString()
    {
        return text + " " + collected;
    }
}
