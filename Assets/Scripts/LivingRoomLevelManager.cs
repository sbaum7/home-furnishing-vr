using UnityEngine;

public class LivingRoomLevelManager : MonoBehaviour
{
    // Assign both of these in the Inspector
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor coffeeTableSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor lampSocket;

    private bool levelComplete = false;

    void Update()
    {
        if (levelComplete)
            return;

        // Check if each required object is snapped into its socket
        bool coffeeTablePlaced = 
            coffeeTableSocket != null && coffeeTableSocket.firstInteractableSelected != null;

        bool lampPlaced = 
            lampSocket != null && lampSocket.firstInteractableSelected != null;

        // Only pass level when BOTH are placed
        if (coffeeTablePlaced && lampPlaced)
        {
            LevelPassed();
        }
    }

    void LevelPassed()
    {
        levelComplete = true;
        Debug.Log("Living room level complete! Coffee table and lamp placed correctly.");
        
        // TODO later: show "Good job!" UI, load next scene, etc.
    }
}
