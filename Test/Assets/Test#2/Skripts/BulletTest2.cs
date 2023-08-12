using UnityEngine;

public class BulletTest2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage = 20;
    private Vector3 direction;

    public void SetDirection(Vector3 value)
    {
        direction = value;
    }

    void Start()
    {
        Destroy(gameObject, 30);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enime"))
        {
            other.GetComponent<EnemyTest2>().OnDead();
            Destroy(other.gameObject, 10);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerTest2>().ChangeHealth(-damage);
        }

        Destroy(gameObject);
    }
}