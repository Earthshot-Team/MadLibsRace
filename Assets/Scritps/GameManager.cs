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

    public GameObject writingPopUp;

    public const int PHASE_HUNT_OBJECTS = 1;
    public const int PHASE_FIND_SURFACE = 2;
    public const int PHASE_TRACE_LETTERS = 3;
    public int currentPhase;

    public GameObject arSessionOrigin;
    public GameObject arCursor;

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
    public void CreateWritingPopUp(Transform _transform)
    {
        GameObject popUp = Instantiate(writingPopUp, _transform.position, _transform.rotation);
        popUp.transform.parent = _transform;
        popUp.GetComponent<WritingPopUp>().word = GetCurrentWord().word;
    }
    public void StartHuntingPhase()
    {
        currentPhase = PHASE_HUNT_OBJECTS;

        planeManager.enabled = false;
        pointCloudManager.enabled = false;
        arCursor.SetActive(false);
    }
    public void StartFindSurfacePhase()
    {
        currentPhase = PHASE_FIND_SURFACE;

        planeManager.enabled = true;
        pointCloudManager.enabled = true;
        arCursor.SetActive(true);
        CreateWritingPopUp(arCursor.transform.GetChild(0).transform);
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