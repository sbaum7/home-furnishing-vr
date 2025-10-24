using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleFP_NewInput : MonoBehaviour
{
    [Header("Input (drag from .inputactions)")]
    public InputActionReference moveAction;   // Player/Move (Vector2)
    public InputActionReference lookAction;   // Player/Look (Vector2: Mouse Delta)

    [Header("Refs")]
    public Transform cameraTransform;         // assign PlayerCamera

    [Header("Movement")]
    public float moveSpeed = 4f;
    public float gravity   = -9.81f;

    [Header("Look")]
    public float mouseSensitivity = 3f;   // tune 1–5
    public float baseMouseScale   = 0.05f; // tune 0.02–0.08
    public float maxLookAngle     = 80f;
    public bool  invertY          = false;

    CharacterController controller;
    float pitch = 0f;
    Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (!cameraTransform && Camera.main) cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
    }

    void OnEnable()
    {
        moveAction?.action.Enable();
        lookAction?.action.Enable();
    }

    void OnDisable()
    {
        moveAction?.action.Disable();
        lookAction?.action.Disable();
    }

    void Update()
    {
        // ----- Look (mouse) -----
        Vector2 look = lookAction?.action.ReadValue<Vector2>() ?? Vector2.zero;

        // If the active control is a Mouse, treat values as per-frame deltas (NO deltaTime).
        bool isMouse = lookAction != null &&
                       lookAction.action.activeControl != null &&
                       lookAction.action.activeControl.device is Mouse;

        float yawDelta, pitchDelta;

        if (isMouse)
        {
            float scale = mouseSensitivity * baseMouseScale; // finely tunable pair
            yawDelta   = look.x * scale;
            pitchDelta = look.y * scale * (invertY ? 1f : -1f);
        }
        else
        {
            // (Future-proof: if you later bind a gamepad stick to Look, this keeps it stable.)
            float stickSensitivity = mouseSensitivity; // reuse for now
            yawDelta   = look.x * stickSensitivity * Time.deltaTime;
            pitchDelta = look.y * stickSensitivity * Time.deltaTime * (invertY ? 1f : -1f);
        }

        pitch = Mathf.Clamp(pitch + pitchDelta, -maxLookAngle, maxLookAngle);
        if (cameraTransform) cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        transform.Rotate(Vector3.up * yawDelta);

        // ----- Move -----
        Vector2 mv = moveAction?.action.ReadValue<Vector2>() ?? Vector2.zero;
        Vector3 moveVec = (transform.right * mv.x + transform.forward * mv.y).normalized;
        controller.Move(moveVec * moveSpeed * Time.deltaTime);

        // ----- Gravity -----
        if (controller.isGrounded && velocity.y < 0f) velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Optional: unlock with Esc
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
