using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawableLetterSpriteManager : MonoBehaviour
{
    public Sprite[] untracedLetterSprites = new Sprite[26];
    public Sprite[] tracedLetterSprite = new Sprite[26];
    public char[] alphabet = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    public int GetLetterIndex(char letter)
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            if(alphabet[i] == letter)
            {
                return i;
            }
        }

        return 0;
    }

    public Sprite GetUntracedSpriteOfLetter(char letter)
    {
        return untracedLetterSprites[GetLetterIndex(letter)];
    }
    public Sprite GetTracedSpriteOfLetter(char letter)
    {
        return tracedLetterSprite[GetLetterIndex(letter)];
    }
}
