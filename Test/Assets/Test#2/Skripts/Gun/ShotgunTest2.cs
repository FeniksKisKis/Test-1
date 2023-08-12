using UnityEngine;

public class ShotgunTest2 : GunTest2
{
    void Start()
    {
        auto = false;
        cooldown = 0.5f;
    }

    protected override void OnShoot()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject buf = Instantiate(bulletPrefab);
            buf.transform.position = bulletStart.position;
            buf.transform.rotation = bulletStart.rotation;
            float x = Random.Range(-30, 30);
            float y = Random.Range(-10, 10);
            buf.GetComponent<BulletTest2>().SetDirection(transform.forward + new Vector3(x / 500, y / 500, 0));
        }
    }
}