using UnityEngine;

public class EnemyTest2 : MonoBehaviour
{
    protected GameObject player;
    protected int damage;
    private bool isDead;


    private void Start()
    {
        player = FindObjectOfType<PlayerMoveTest2>().gameObject;
    }

    private void Update()
    {
        if (isDead == false)
        {
            Move();
            Attack();
        }
    }

    protected virtual void Move()
    {

    }

    protected virtual void Attack()
    {

    }

    public void OnDead()
    {
        isDead = true;
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<CharacterController>().enabled = false;
    }
}