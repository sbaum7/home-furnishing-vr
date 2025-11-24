using UnityEngine;


public class CoffeeTableLevel : MonoBehaviour
{
    // Assign this in the Inspector
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor coffeeTableSocket;

    private bool levelComplete = false;

    void Update()
    {
        if (levelComplete)
            return;

        // Check if something is currently snapped into the socket
        var selected = coffeeTableSocket.firstInteractableSelected;
        if (selected != null)
        {
            // Because we filtered by Interaction Layer ("CoffeeTable"),
            // we know this is our coffee table.
            LevelPassed();
        }
    }

    void LevelPassed()
    {
        levelComplete = true;
        Debug.Log("Coffee table placed correctly! Level passed.");
        
    }
}
