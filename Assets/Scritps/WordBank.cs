using UnityEngine;

public class WordBank : MonoBehaviour
{
    public Sprite penIcon;
    public Sprite mugIcon;
    public Sprite windowIcon;
    public Sprite scissorsIcon;

    public GameObject penObject;
    public GameObject mugObject;
    public GameObject windowObject;
    public GameObject scissorObject;


    public Word[] wordBank;

    void Awake()
    {
        wordBank = new Word[] {
            new Word("pen", penIcon, penObject),
            new Word("mug", mugIcon, mugObject),
            new Word("window", windowIcon, windowObject),          
            new Word("scissors", scissorsIcon, scissorObject), 
        };
    }
}
