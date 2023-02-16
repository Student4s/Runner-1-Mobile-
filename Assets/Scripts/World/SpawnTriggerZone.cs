using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggerZone : MonoBehaviour
{
    [SerializeField] private GameObject[] roads;
    [SerializeField] private GameObject spawnPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("spawn new section");
            Vector3 pointToSpawn = spawnPoint.transform.position + new Vector3(0, 0, 90);
            GameObject newRoad = roads[Random.Range(0,roads.Length-1)];
            Instantiate(newRoad, pointToSpawn, Quaternion.identity);
        }
    }
}
