using UnityEngine;
using TMPro;

public class LapCounterUI : MonoBehaviour
{
    public TMP_Text lapText; // Text that displays the lap

    public void SetLap(int currentLap, int totalLaps)
    {
        if (lapText != null)
        {
            lapText.text = "LAP " + currentLap + "/" + totalLaps;
        }
    }

    void Start()
    {
        SetLap(1, 3); // Starts the display at LAP 1/3
    }
}