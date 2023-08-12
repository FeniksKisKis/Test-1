using UnityEngine;

public class GunTest2 : MonoBehaviour
{
    [SerializeField] protected Transform bulletStart;
    [SerializeField] protected GameObject bulletPrefab;
    protected bool auto = false;
    protected float cooldown = 0;
    private float timer = 0;

    void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto == true)
        {
            if (timer > cooldown)
            {
                OnShoot();
                timer = 0;
            }
        }
    }

    protected virtual void OnShoot()
    {
    }
}