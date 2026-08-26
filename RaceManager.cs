using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public int totalCheckpoints = 4;
    public int totalLaps = 3;

    private int nextCheckpoint = 1;
    private int currentLap = 1;

    public void CheckpointPassed(int checkpointNumber)
    {
        if (checkpointNumber == nextCheckpoint)
        {
            nextCheckpoint++;

            if (nextCheckpoint > totalCheckpoints)
            {
                nextCheckpoint = 1;
                currentLap++;

                Debug.Log("Lap " + currentLap);
            }
        }
    }
}