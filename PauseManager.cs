using UnityEngine;
using UnityEngine.InputSystem; // Uses the New Input System package

public class PauseManager : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private GameObject pausePanel; // Connect your Pause Panel object here

    private bool isPaused = false;

    void Start()
    {
        // 1. Force the game time to run normally at startup so the car can move
        Time.timeScale = 1f;

        // 2. Automatically hide the pause menu UI when the game first boots up
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        isPaused = false;
    }

    void Update()
    {
        // Checks if the Escape key was pressed this frame
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(true); // Shows the pause menu UI
        }
        Time.timeScale = 0f; // Completely freezes game time/physics
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false); // Hides the pause menu UI
        }
        Time.timeScale = 1f; // Unfreezes game time/physics
        isPaused = false;
    }
}
