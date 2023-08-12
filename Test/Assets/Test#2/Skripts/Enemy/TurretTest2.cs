using UnityEngine;

public class TurretTest2 : EnemyTest2
{
    [SerializeField] private float area = 10;
    [SerializeField] private float timer = 2;
    private float time;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletStart;

    protected override void Attack()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < area)
        {
            transform.LookAt(player.transform);
            time += Time.deltaTime;
            if (time > timer)
            {
                GameObject buf = Instantiate(bulletPrefab);
                buf.transform.position = bulletStart.position;
                buf.transform.rotation = bulletStart.rotation;
                buf.GetComponent<BulletTest2>().SetDirection(bulletStart.forward);
                time = 0;
            }
        }
    }
}