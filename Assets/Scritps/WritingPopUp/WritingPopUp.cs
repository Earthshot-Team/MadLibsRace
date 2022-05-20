using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingPopUp : MonoBehaviour
{
    public string word;
    public char[] characters;
    public DrawableLetter[] letters = new DrawableLetter[1] { new DrawableLetter('c')};

    public float letterSize = 100;
    public float bufferBtwLetters = 10;
    float totalSize;

    public GameObject letterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        characters = SplitWordIntoCharacters(word);
        letters = TurnCharacterArrayToDrawableCharacterArray(characters);
        totalSize = GetTotalDisplaySize();
        CreateLetterPrefabsForWord();
    }

    void CreateLetterPrefabsForWord()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            CreateTraceableLetterPrefab(letters[i]);
        }
    }
    void CreateTraceableLetterPrefab(DrawableLetter _letter)
    {
        GameObject curLetter = Instantiate(letterPrefab, Vector2.zero, Quaternion.identity);
        curLetter.transform.SetParent(transform.GetChild(0));

        curLetter.GetComponent<Image>().sprite = _letter.untracedSprite;
        RectTransform rect = curLetter.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(letterSize * (_letter.untracedSprite.rect.width / _letter.untracedSprite.rect.height), letterSize);
        rect.localScale = new Vector2(1 / rect.lossyScale.x, 1 / rect.lossyScale.y);

        transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(totalSize, 100);
        transform.GetChild(0).GetComponent<HorizontalLayoutGroup>().spacing = bufferBtwLetters;
    }

    DrawableLetter[] TurnCharacterArrayToDrawableCharacterArray(char[] _characters)
    {
        List<DrawableLetter> temporaryCharacterList = new List<DrawableLetter>();

        foreach (char character in _characters)
        {
            temporaryCharacterList.Add(new DrawableLetter(character));
            temporaryCharacterList[temporaryCharacterList.Count - 1].SetSprites();
        }

        return temporaryCharacterList.ToArray();
    }

    char[] SplitWordIntoCharacters(string _word)
    {
        string lowercaseWord = _word.ToLower();
        return lowercaseWord.ToCharArray();
    }

    float GetTotalDisplaySize()
    {
        float totalLength = 0;
        for (int i = 0; i < letters.Length; i++)
        {
            totalLength += letterSize * (letters[i].untracedSprite.rect.width / letters[i].untracedSprite.rect.height);
        }

        totalLength += bufferBtwLetters * (letters.Length - 1);

        return totalLength;
    }
}