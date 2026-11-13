using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
               int randomIndex = Random.Range(0, enemyPrefabs.Length); // Get a random index for the enemy prefab
        GameObject enemyPrefab = enemyPrefabs[randomIndex]; // Get the selected enemy prefab
        Instantiate(enemyPrefab, transform.position, Quaternion.identity); // Spawn the enemy at the current position
    }
}
