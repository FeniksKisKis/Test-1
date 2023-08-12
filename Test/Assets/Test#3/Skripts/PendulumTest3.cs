using UnityEngine;

public class PendulumTest3 : MonoBehaviour
{
    [SerializeField] private float limit = 30f;
    [SerializeField] private float speed = 1.75f;

    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time * speed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}