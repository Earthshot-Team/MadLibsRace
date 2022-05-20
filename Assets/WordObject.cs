using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordObject : MonoBehaviour
{
    Transform target;
    public TraceableLetter[] letters;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Camera>().transform;
        letters = GetComponentsInChildren<TraceableLetter>();

        transform.LookAt(target, Vector3.up);
        transform.Rotate(-90f, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
