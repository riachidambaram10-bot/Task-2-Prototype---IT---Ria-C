using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Checkpoint Settings")]
    public int checkpointNumber;

    [Header("Race Manager")]
    public RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        // Checks that the player entered this checkpoint
        if (!other.CompareTag("Player"))
            return;

        // Makes sure the Race Manager is connected
        if (raceManager == null)
        {
            Debug.LogError("Race Manager is not assigned to " + gameObject.name);
            return;
        }

        // Tells the Race Manager which checkpoint was passed
        raceManager.CheckpointPassed(checkpointNumber);

        Debug.Log(
            "Player passed Checkpoint " +
            checkpointNumber
        );
    }
}