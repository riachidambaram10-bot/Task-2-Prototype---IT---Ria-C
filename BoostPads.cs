using UnityEngine;

public class BoostPad : MonoBehaviour
{
    public float boostForce = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(
                other.transform.forward * boostForce,
                ForceMode.Impulse
            );

            Debug.Log("BOOST!");
        }
    }
}