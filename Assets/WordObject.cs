using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordObject : MonoBehaviour
{
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Camera>().transform;
        transform.LookAt(target, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
