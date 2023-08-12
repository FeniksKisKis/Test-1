using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsTest2 : MonoBehaviour
{
    private GameObject player;

    public void Menu()
    {
        SceneManager.LoadScene(0);//SampleScene
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);//SampleScene
    }
    public void ReStart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);//SampleScene
    }
    public void Aftors()
    {
        SceneManager.LoadScene(2);//SampleScene
    }

    public void Save()
    {
        //player = FindObjectType<PlayerController>().gameObject;
        Vector3 posPlayer = player.transform.position;

        PlayerPrefs.SetFloat("posX", posPlayer.x);
        PlayerPrefs.SetFloat("posY", posPlayer.y);
        PlayerPrefs.SetFloat("posZ", posPlayer.z);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
