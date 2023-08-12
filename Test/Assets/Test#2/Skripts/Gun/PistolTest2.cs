using UnityEngine;

public class PistolTest2 : GunTest2
{
    void Start()
    {
        auto = false;
        cooldown = 0.1f;
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bulletPrefab);
        buf.transform.position = bulletStart.position;
        buf.transform.rotation = bulletStart.rotation;
        buf.GetComponent<BulletTest2>().SetDirection(bulletStart.forward);
    }
}
