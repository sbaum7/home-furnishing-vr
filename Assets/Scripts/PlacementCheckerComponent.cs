using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlacementChecker : MonoBehaviour
{
    [SerializeField] private GameObject expectedObject; // Assign the correct grabable object (e.g., toaster) in Inspector
    [SerializeField] private PlacementManager placementManager; // Assign the PlacementManager GameObject here (once, on any socket)

    private XRSocketInteractor socketInteractor;

    void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();

        if (socketInteractor == null)
        {
            Debug.LogError("No XRSocketInteractor found on " + gameObject.name);
        }

        if (placementManager == null)
        {
            Debug.LogError("PlacementManager not assigned on " + gameObject.name);
        }
    }

    void OnEnable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnObjectPlaced);
            socketInteractor.selectExited.AddListener(OnObjectRemoved);
        }
    }

    void OnDisable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnObjectPlaced);
            socketInteractor.selectExited.RemoveListener(OnObjectRemoved);
        }
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.gameObject == expectedObject)
        {
            placementManager.UpdatePlacement(this, true);
        }
    }

    private void OnObjectRemoved(SelectExitEventArgs args)
    {
        if (args.interactableObject.transform.gameObject == expectedObject)
        {
            placementManager.UpdatePlacement(this, false);
        }
    }
}