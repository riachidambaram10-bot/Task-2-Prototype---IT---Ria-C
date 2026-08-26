using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    public float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;
    }
}