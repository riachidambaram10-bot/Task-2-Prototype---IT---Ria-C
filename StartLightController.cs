using UnityEngine;

public class StartLightController : MonoBehaviour
{
    public GameObject[] lights; 
    public float delayBetweenLights = 1f; // Time between each light

    void Start()
    {
        StartCoroutine(StartSequence());
    }

    System.Collections.IEnumerator StartSequence()
    {
        // Checks00 that the lights have been assigned
        if (lights == null || lights.Length == 0)
        {
            Debug.LogWarning("No start lights assigned!");
            yield break;
        }

        foreach (GameObject lightObject in lights)
        {
            if (lightObject != null)
                lightObject.SetActive(true);

            yield return new WaitForSeconds(delayBetweenLights);
        }

        yield return new WaitForSeconds(1f);

        foreach (GameObject lightObject in lights)
        {
            if (lightObject != null)
                lightObject.SetActive(false);
        }

        Debug.Log("GO!");
    }
}