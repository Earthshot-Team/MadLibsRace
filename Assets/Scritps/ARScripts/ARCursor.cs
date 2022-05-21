using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    public const int PHASE_HUNT_OBJECTS = 1;
    public const int PHASE_FIND_SURFACE = 2;
    public const int PHASE_TRACE_LETTERS = 3;

    public LayerMask letterLayer;

    public GameObject cursorChildObject;

    public GameObject pencilLead;

    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;

    public bool useCursor;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cursorChildObject.SetActive(useCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentPhase == PHASE_FIND_SURFACE)
        {
            useCursor = true;
            cursorChildObject.SetActive(true);
            objectToPlace = gameManager.GetCurrentWord().wordPrefab;
        }
        else if (gameManager.currentPhase == PHASE_TRACE_LETTERS)
        {
            useCursor = false;
            cursorChildObject.SetActive(false);
            objectToPlace = pencilLead;
        }

        if (useCursor)
        {
            UpdateCursor();
        }

        if (!(Input.touchCount > 0))
        {
            // If player is not touching screen, don't go further
            return;
        }

        if (gameManager.currentPhase == PHASE_FIND_SURFACE)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                HandleObjectPlacement();
            }
        }else if(gameManager.currentPhase == PHASE_TRACE_LETTERS)
        {
            HandleLeadPlacement();
        }

    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.All);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
    void HandleObjectPlacement()
    {
        if (useCursor)
        {
            gameManager.currentPhase = PHASE_TRACE_LETTERS;
            GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
        }
    }

    void HandleLeadPlacement()
    { 
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.GetTouch(0).position, hits);
            if (hits.Count > 0)
            {
                GameObject dot = GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
            }
    }
}
