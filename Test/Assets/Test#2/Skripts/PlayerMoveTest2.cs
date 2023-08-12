using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveTest2 : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private float boost = 10;
    [SerializeField] private float jump = 10;
    [SerializeField] private float gravity = 10;
    private Vector3 direction;
    private int Points = 0;
    [SerializeField] private Text TextPoints;
    [SerializeField] private GameObject burstPrefab;
    [SerializeField] private AudioSource soundJump;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pauseUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            gameOver.SetActive(true);
            GetComponent<CharacterController>().enabled = false;
            GetComponent<PlayerLookTest2>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        if (other.tag == "Crystal")
        {
            Instantiate(burstPrefab, transform.position, transform.rotation);

            GetComponent<AudioSource>().Play();

            Destroy(other.gameObject);
            Points++;//Увеличеть Points на 1
            TextPoints.text = "Кол-во поинтов: " + Points.ToString();
            GetComponent<AudioSource>().Play();
        }
    }










    private void Start()
    {
        if (PlayerPrefs.HasKey("posX"))
        {
            float posX = PlayerPrefs.GetFloat("posX");
            float posY = PlayerPrefs.GetFloat("posY");
            float posZ = PlayerPrefs.GetFloat("posZ");

            transform.position = new Vector3(posX, posY, posZ);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            pauseUI.SetActive(!pauseUI.activeInHierarchy);
            if (pauseUI.activeInHierarchy)
            {
                Time.timeScale = 0;
                GetComponent<PlayerLookTest2>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                GetComponent<PlayerLookTest2>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + boost;
            //speed += 10;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed - boost;
            //speed -= 10;
        }

        if (controller.isGrounded)
        {
            float movX = Input.GetAxis("Horizontal");
            float movZ = Input.GetAxis("Vertical");
            direction = transform.TransformDirection(new Vector3(movX, 0, movZ) * speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jump;
            }
        }

        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }
}