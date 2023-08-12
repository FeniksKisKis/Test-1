using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControllerTest2 : MonoBehaviour
{
    private int health;
    [SerializeField] private Text healthText;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletStart;
    [SerializeField] private Animator animatorPistol;

    void Start()
    {
        ChangeHealth(100);
    }

    public void ChangeHealth(int value)
    {
        health += value;
        healthText.text = "Health: " + health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HP"))
        {
            ChangeHealth(50);
            Destroy(other.gameObject);
        }
    }
}