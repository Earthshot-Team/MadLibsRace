using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

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

    [HideInInspector]
    public Transform currentWordObject;

    public const int PHASE_HUNT_OBJECTS = 1;
    public const int PHASE_FIND_SURFACE = 2;
    public const int PHASE_TRACE_LETTERS = 3;
    public const int PHASE_STORYTIME = 4;
    public int currentPhase;

    public GameObject huntingPhaseCanvas;
    public GameObject arSessionOrigin;
    public GameObject arCursor;
    public GameObject storyObject;

    // Private Components
    WordBank wordBank;
    CameraEffects cameraEffects;

    ARPlaneManager planeManager;
    ARPointCloudManager pointCloudManager;

    // Start is called before the first frame update
    void Start()
    {
        wordBank = FindObjectOfType<WordBank>();
        cameraEffects = FindObjectOfType<CameraEffects>();

        planeManager = arSessionOrigin.GetComponent<ARPlaneManager>();
        pointCloudManager = arSessionOrigin.GetComponent<ARPointCloudManager>();

        words = GetXRandomWordsFromBank(numOfWords);
        StartHuntingPhase();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError("Current Phase is: " + currentPhase);
        cameraButtonImage.sprite = GetCurrentWord().icon;

        if (AllWordsCollected())
        {
            if (currentPhase != PHASE_STORYTIME)
            {
                StartStorytimePhase();
            }
        }
    }

    public void TakePicture()
    {
        cameraEffects.Flash();
        StartFindSurfacePhase();
    }
    public void CollectCurrentWord()
    {
        Word word = GetCurrentWord();
        word.Collect();
    }
    public void StartHuntingPhase()
    {
        currentPhase = PHASE_HUNT_OBJECTS;

        huntingPhaseCanvas.SetActive(true);
        planeManager.enabled = false;
        pointCloudManager.enabled = false;
        arCursor.SetActive(false);

        ARPlane[] objects = GameObject.FindObjectsOfType<ARPlane>();

        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i].gameObject);
        }
    }
    public void StartFindSurfacePhase()
    {
        currentPhase = PHASE_FIND_SURFACE;

        huntingPhaseCanvas.SetActive(false);
        planeManager.enabled = true;
        pointCloudManager.enabled = true;
        arCursor.SetActive(true);
    }
    public void StartStorytimePhase()
    {
        currentPhase = PHASE_STORYTIME;

        huntingPhaseCanvas.SetActive(false);
        planeManager.enabled = false;
        pointCloudManager.enabled = false;
        arCursor.SetActive(false);

        Instantiate(storyObject, currentWordObject.position, currentWordObject.rotation);
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
    public Word GetCurrentWord()
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

    bool AllWordsCollected()
    {
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].collected == false)
            {
                return false;
            }
        }

        return true;
    }
}