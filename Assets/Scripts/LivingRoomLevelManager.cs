using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LivingRoomLevelManager : MonoBehaviour
{
    // Assign sockets in the Inspector
    public XRSocketInteractor coffeeTableSocket;
    public XRSocketInteractor lampSocket;
    public XRSocketInteractor sofaDoubleSocket;

    private bool levelComplete = false;

    void Update()
    {
        if (levelComplete)
            return;

        // All items must be correct
        bool coffeeCorrect = IsCorrect(coffeeTableSocket, "CoffeeTable");
        bool lampCorrect   = IsCorrect(lampSocket, "lamp_002");
        bool sofaCorrect   = IsCorrect(sofaDoubleSocket, "SofaDouble");


        if (coffeeCorrect && lampCorrect && sofaCorrect)
        {
            LevelPassed();
        }
    }

    bool IsCorrect(XRSocketInteractor socket, string expectedId)
    {
        if (socket == null)
            return false;

        var placed = socket.firstInteractableSelected;
        if (placed == null)
            return false;

        var placedComponent = placed as Component;
        if (placedComponent == null)
            return false;

        var itemId = placedComponent.GetComponent<ItemId>();
        if (itemId == null)
            return false;

        return itemId.id == expectedId;
    }


    void LevelPassed()
    {
        levelComplete = true;
        Debug.Log("Living room level complete! All items are in the correct sockets.");
    }
}
