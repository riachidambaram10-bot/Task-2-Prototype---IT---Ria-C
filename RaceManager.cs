using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    [Header("Race Settings")]
    public int totalCheckpoints = 4;
    public int totalLaps = 3;

    [Header("Race Progress")]
    public int currentLap = 1;
    public int nextCheckpoint = 1;
    public bool raceFinished = false;

    [Header("UI")]
    public TMP_Text lapText;
    public TMP_Text finishText;

    private KartController playerKart;
    private Rigidbody kartRigidbody;

    void Start()
    {
        currentLap = 1;
        nextCheckpoint = 1;
        raceFinished = false;

        // Find the player's kart
        playerKart = FindFirstObjectByType<KartController>();

        if (playerKart != null)
        {
            kartRigidbody = playerKart.GetComponent<Rigidbody>();
        }

        UpdateLapUI();

        // Hide finish message at the beginning
        if (finishText != null)
        {
            finishText.gameObject.SetActive(false);
        }
    }

    public void CheckpointPassed(int checkpointNumber)
    {
        // Dosen't accept checkpoints after the race is finished
        if (raceFinished)
            return;

        // Only accepts the checkpoint we are currently expecting
        if (checkpointNumber != nextCheckpoint)
        {
            Debug.Log(
                "Wrong checkpoint! Expected: " +
                nextCheckpoint +
                " | Received: " +
                checkpointNumber
            );

            return;
        }

        Debug.Log("Checkpoint " + checkpointNumber + " passed!");

        // Moves to the next checkpoint
        nextCheckpoint++;

        // Makes sure Player has passed all four checkpoints
        if (nextCheckpoint > totalCheckpoints)
        {
            CompleteLap();
        }
    }

    void CompleteLap()
    {
        Debug.Log("All checkpoints passed!");

        // Checks if this was the final lap
        if (currentLap >= totalLaps)
        {
            FinishRace();
            return;
        }

        // Moves to the next lap
        currentLap++;

        // Starts checkpoint sequence again
        nextCheckpoint = 1;

        Debug.Log("Lap completed! Current lap: " + currentLap);

        UpdateLapUI();
    }

    void UpdateLapUI()
    {
        if (lapText != null)
        {
            lapText.text = "LAP " + currentLap + "/" + totalLaps;
        }
    }

    void FinishRace()
    {
        raceFinished = true;

        Debug.Log("RACE FINISHED!");

        // STOPS THE KART
        if (kartRigidbody != null)
        {
            kartRigidbody.linearVelocity = Vector3.zero;
            kartRigidbody.angularVelocity = Vector3.zero;
        }

        // DISABLES KART CONTROLS
        if (playerKart != null)
        {
            playerKart.enabled = false;
        }

        // Changes lap counter to FINISH
        if (lapText != null)
        {
            lapText.text = "FINISH!";
        }

        // Shows finish message
        if (finishText != null)
        {
            finishText.gameObject.SetActive(true);
            finishText.text = "RACE FINISHED!";
        }
    }
}