using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber;
    public RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            raceManager.CheckpointPassed(checkpointNumber);
        }
    }
}
