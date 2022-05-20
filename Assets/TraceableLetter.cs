using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TraceableLetter : MonoBehaviour
{
    public char letter;

    public bool isTraced;

    SpriteRenderer spriteRenderer;
    DrawableLetterSpriteManager spriteManager;

    // Start is called before the first frame update
    void Start()
    {
        spriteManager = FindObjectOfType<DrawableLetterSpriteManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isTraced)
        {
            spriteRenderer.sprite = spriteManager.GetTracedSpriteOfLetter(letter);
        }
        else
        {
            spriteRenderer.sprite = spriteManager.GetUntracedSpriteOfLetter(letter);
        }
    }
}
