using UnityEngine;

public class BounceTest3 : MonoBehaviour
{
    [SerializeField] private float force = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector3 hitDir = contact.normal;

                collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Impulse);
                return;
            }
        }
    }
}