using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControllerTest3 : MonoBehaviour
{
    [SerializeField] private List<GameObject> plates = new List<GameObject>();
    [SerializeField] private List<GameObject> doors = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < plates.Count; i += 3)
        {
            plates[Random.Range(i, i + 3)].GetComponent<Collider>().isTrigger = true;
        }
        for (int i = 0; i < doors.Count; i += 4)
        {
            doors[Random.Range(i, i + 4)].AddComponent<Rigidbody>();
        }
        //plates[Random.Range(0, 3)].GetComponent<Collider>().isTrigger = true;
        //plates[Random.Range(3, 6)].GetComponent<Collider>().isTrigger = true;
        //plates[Random.Range(6, 9)].GetComponent<Collider>().isTrigger = true;
        //doors[Random.Range(0, 4)].AddComponent<Rigidbody>();
        //doors[Random.Range(4, 8)].AddComponent<Rigidbody>();
        //doors[Random.Range(8, 12)].AddComponent<Rigidbody>();
    }
}