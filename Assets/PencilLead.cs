using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilLead : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Letter"))
        {
            transform.SetParent(collision.transform);
        }
    }
}
