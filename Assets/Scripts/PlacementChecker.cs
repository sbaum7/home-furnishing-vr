using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlacementChecker : MonoBehaviour
{
    [Header("Expected Item")]
    [Tooltip("The ID value that should be placed in this socket (must match ItemId on the prefab).")]
    [SerializeField] private string expectedId;

    [SerializeField] private PlacementManager placementManager; // Assign once per socket (or all sockets)

    private XRSocketInteractor socketInteractor;

    void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();

        if (socketInteractor == null)
            Debug.LogError("No XRSocketInteractor found on " + gameObject.name);

        if (placementManager == null)
            Debug.LogError("PlacementManager not assigned on " + gameObject.name);
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

    private bool MatchesExpected(Transform placed)
    {
        // Handles cases where ItemId is on a parent of the grabbed collider mesh, etc.
        ItemId idComp = placed.GetComponentInParent<ItemId>();
        if (idComp == null) return false;

        // 🔻 IMPORTANT: replace `idComp.id` with your real field/property name if different
        return idComp.id == expectedId;
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        if (MatchesExpected(args.interactableObject.transform))
            placementManager.UpdatePlacement(this, true);
    }

    private void OnObjectRemoved(SelectExitEventArgs args)
    {
        if (MatchesExpected(args.interactableObject.transform))
            placementManager.UpdatePlacement(this, false);
    }
}
