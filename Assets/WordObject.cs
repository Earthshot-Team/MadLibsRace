using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordObject : MonoBehaviour
{
    Transform target;
    public TraceableLetter[] letters;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Camera>().transform;
        gameManager = FindObjectOfType<GameManager>();

        letters = GetComponentsInChildren<TraceableLetter>();

        transform.LookAt(target, Vector3.up);
        transform.Rotate(-90f, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        if (AllLettersTraced())
        {
            gameManager.CollectCurrentWord();
            gameManager.StartHuntingPhase();

            GameObject[] leftOverLead = GameObject.FindGameObjectsWithTag("PencilLead");
            foreach (var item in leftOverLead)
            {
                Destroy(item);
            }

            Destroy(this.gameObject);
        }
    }

    bool AllLettersTraced()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i].isTraced == false)
            {
                return false;
            }
        }

        return true;
    }
}
