using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
  
    public Vector3 spawnPosition = new Vector3(0, 1, 0); 

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            SpawnObject();
        }
    }

    void SpawnObject() 
    {
       
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
