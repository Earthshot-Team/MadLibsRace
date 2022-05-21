using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilLead : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        transform.SetParent(collision.transform);
    }
}
