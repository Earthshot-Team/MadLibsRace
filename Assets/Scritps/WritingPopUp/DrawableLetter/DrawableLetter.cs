using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DrawableLetter
{
    DrawableLetterSpriteManager spriteManager;

    public Vector2[] points;
    public Sprite untracedSprite;
    public Sprite tracedSprite;
    public char letter;

    public DrawableLetter(char _letter)
    {
        letter = _letter;
    }

    public void SetSprites()
    {
        spriteManager = GameObject.FindObjectOfType<DrawableLetterSpriteManager>();

        untracedSprite = spriteManager.GetUntracedSpriteOfLetter(letter);
        tracedSprite = spriteManager.GetTracedSpriteOfLetter(letter);
    }

}
