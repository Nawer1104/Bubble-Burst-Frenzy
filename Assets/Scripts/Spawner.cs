using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform[] spawnPoints;
    public float spawnInterval;

    void Start()
    {
        spawnInterval = GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].level_spawnInterval;
        // Start the spawning coroutine
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Spawn the GameObject at a random position within the spawn area
            
            Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position , Quaternion.identity);

            // Wait for the specified spawn interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
