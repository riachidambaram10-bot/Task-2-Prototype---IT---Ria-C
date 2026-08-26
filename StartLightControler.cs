using System.Collections;
using UnityEngine;

public class StartLightController : MonoBehaviour
{
    public Renderer lightA;
    public Renderer lightB;
    public Renderer lightC;

    public KartController playerKart;

    private void Start()
    {
        playerKart.enabled = false;

        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        // All lights off
        SetLights(Color.black, Color.black, Color.black);
        yield return new WaitForSeconds(1f);

        // Red
        SetLights(Color.red, Color.black, Color.black);
        yield return new WaitForSeconds(1f);

        // Orange
        SetLights(Color.red, new Color(1f, 0.5f, 0f), Color.black);
        yield return new WaitForSeconds(1f);

        // Green
        SetLights(Color.black, Color.black, Color.green);

        // Allow the player to drive
        playerKart.enabled = true;
    }

    private void SetLights(Color a, Color b, Color c)
    {
        lightA.material.color = a;
        lightB.material.color = b;
        lightC.material.color = c;
    }
}