
using UnityEngine;

public class PredatorTest2 : EnemyTest2
{
    [SerializeField] private float speed;
    [SerializeField] private float areaMove;
    [SerializeField] private float areaAttack;

    protected override void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < areaMove)
        {
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * speed);
        }
    }

    protected override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < areaAttack)
        {
            player.GetComponent<PlayerControllerTest2>().ChangeHealth(-100);
        }
    }

}