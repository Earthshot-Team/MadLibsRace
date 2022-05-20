using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Words
    [Header("Words")]
    public int numOfWords = 4;
    public Word[] words;

    // Assigned Components
    [Header("Camera Button")]
    public Button cameraButton;
    public Image cameraButtonImage;

    // Private Components
    WordBank wordBank;
    CameraEffects cameraEffects;

    // Start is called before the first frame update
    void Start()
    {
        wordBank = FindObjectOfType<WordBank>();
        cameraEffects = FindObjectOfType<CameraEffects>();
        words = GetXRandomWordsFromBank(numOfWords);
    }

    // Update is called once per frame
    void Update()
    {
        cameraButtonImage.sprite = GetCurrentWord().icon;
    }

    public void TakePicture()
    {
        cameraEffects.Flash();
        CollectCurrentWord();
    }
    public void CollectCurrentWord()
    {
        Word word = GetCurrentWord();
        word.Collect();
    }

    Word[] GetXRandomWordsFromBank(int x)
    {
        List<Word> temporaryWordsList = new List<Word>();
        
        while (x > 0)
        {
            Word word = GetRandomWordFromBank();

            if (temporaryWordsList.Contains(word) == false)
            {
                x--;
                temporaryWordsList.Add(word);
            }
        }

        return temporaryWordsList.ToArray();
    }
    Word GetRandomWordFromBank()
    {
        return wordBank.wordBank[Random.Range(0, wordBank.wordBank.Length)];
    }
    Word GetCurrentWord()
    {
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].collected == false) {
                return words[i];
            }
        }

        // This should never happen
        Debug.LogError("All Words Have Been Collected But GetCurrentWord Was Still Called \nLINE 62, \nGAMEMANAGER.CS, \nGetCurrentWord Method, \n");
        return words[words.Length - 1];
    }
}