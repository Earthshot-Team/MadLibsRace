using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPoint : MonoBehaviour
{
    public bool drawnOver;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PencilLead"))
        {
            drawnOver = true;
        }
    }
}
