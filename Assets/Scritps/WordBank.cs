using UnityEngine;

public class WordBank : MonoBehaviour
{
    public Sprite penIcon;
    public Sprite mugIcon;
    public Sprite windowIcon;
    public Sprite scissorsIcon;

    public Word[] wordBank;

    void Awake()
    {
        wordBank = new Word[] {
            new Word("pen", penIcon),
            new Word("mug", mugIcon),
            new Word("window", windowIcon),          
            new Word("scissors", scissorsIcon), 
        };
    }
}
