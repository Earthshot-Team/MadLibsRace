using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class TraceableLetter : MonoBehaviour
{
    public char letter;

    public bool isTraced;

    public LetterPoint[] points;

    SpriteRenderer spriteRenderer;
    DrawableLetterSpriteManager spriteManager;
    BoxCollider boxCollider;
    Animator anim;

    public GameObject completionEffect;

    // Start is called before the first frame update
    void Start()
    {
        isTraced = false;
        spriteManager = FindObjectOfType<DrawableLetterSpriteManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllPointsDrawnOver())
        {
            if(isTraced == false)
            {
                anim.SetTrigger("complete");
            }
            isTraced = true;
            DestroyAllChildren();
        }

        if (isTraced)
        {
            spriteRenderer.sprite = spriteManager.GetTracedSpriteOfLetter(letter);
        }
        else
        {
            spriteRenderer.sprite = spriteManager.GetUntracedSpriteOfLetter(letter);
        }
    }

    bool AllPointsDrawnOver()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].drawnOver == false)
            {
                return false;
            }
        }

        return true;
    }
    void DestroyAllChildren()
    {
        Transform[] children = GetComponentsInChildren<Transform>();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
