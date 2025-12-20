using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class RestorePhysics : MonoBehaviour
{
    private Rigidbody rb;
    private bool defaultUseGravity;
    private bool defaultIsKinematic;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        defaultUseGravity = rb.useGravity;
        defaultIsKinematic = rb.isKinematic;

        var grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grab.selectExited.AddListener(_ => Restore());
    }

    private void Restore()
    {
        rb.useGravity = defaultUseGravity;
        rb.isKinematic = defaultIsKinematic;
        rb.WakeUp();
    }
}
