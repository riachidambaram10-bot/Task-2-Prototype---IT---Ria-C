using UnityEngine;

public class BoostPad : MonoBehaviour
{
    public float boostForce = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(
                    other.transform.forward * boostForce,
                    ForceMode.Impulse
                );
            }
        }
    }
}