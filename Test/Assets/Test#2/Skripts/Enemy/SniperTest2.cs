using UnityEngine;
public class SniperTest2 : EnemyTest2
{
    [SerializeField] private float areaAttack = 10;
    [SerializeField] private float timerAttack = 2;
    private float timeAttack;
    [SerializeField] private float angleRotate = 18;
    [SerializeField] private float timerRotate = 1;
    private float timeRotate;
    private float speed = 10;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletStart;
    enum Firing
    {
        Wait,
        Prepare,
        Shoot
    }
    private Firing fire = Firing.Wait;

    protected override void Move()
    {
        if (fire == Firing.Wait)
        {
            timeRotate += Time.deltaTime;
            if (timeRotate > timerRotate)
            {
                transform.Rotate(0, angleRotate, 0);
                timeRotate = 0;
            }
        }
        GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * speed);
    }

    protected override void Attack()
    {
        {
            switch (fire)
            {
                case Firing.Wait:
                    if (Vector3.Distance(player.transform.position, transform.position) < areaAttack)
                    {
                        fire = Firing.Prepare;
                    }
                    break;

                case Firing.Prepare:
                    transform.LookAt(player.transform);
                    timeAttack += Time.deltaTime;
                    if (timeAttack > timerAttack)
                    {
                        fire = Firing.Shoot;
                    }
                    break;

                case Firing.Shoot:
                    GameObject buf = Instantiate(bulletPrefab);
                    buf.transform.position = bulletStart.position;
                    buf.transform.rotation = bulletStart.rotation;
                    buf.GetComponent<BulletTest2>().SetDirection(bulletStart.forward);
                    timeAttack = 0;
                    fire = Firing.Wait;
                    break;

            }
        }
    }
}