using UnityEngine;

public class PlayerMoveTest3 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private float boost = 5;
    [SerializeField] private float jump;
    [SerializeField] private float slideForce;
    private Vector3 direction;
    private bool isGrounded;
    private Animator animator;
    private bool isSlide;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (transform.position.y < -25)
        {
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
        }


        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        direction = transform.TransformDirection(moveX, 0, moveZ);

        if (direction.magnitude > 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(transform.up * jump, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += boost;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= boost;
        }
        if (isSlide == true)
        {
            rb.AddForce(direction * slideForce, ForceMode.VelocityChange);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        animator.SetBool("Jump", false);

        isGrounded = true;
        animator.SetBool("Jump", false);

        if (collision.gameObject.CompareTag("slide"))
        {
            isSlide = true;
        }
        else
        {
            isSlide = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        animator.SetBool("Jump", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Checkpoint"))
        {
            startPosition = startPosition = transform.position;
        }
    }
}