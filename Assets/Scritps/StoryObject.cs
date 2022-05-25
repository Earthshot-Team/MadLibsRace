using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject : MonoBehaviour
{
    Transform target;
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Camera>().transform;

        transform.position = target.position;
        transform.position += transform.forward * 3;

        transform.LookAt(target, Vector3.up);
        transform.Rotate(-90f, 0, 180);

        canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = FindObjectOfType<Camera>();
    }
}
