using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public List<GameObject> asteroidPrefabs = new List<GameObject>();
    public int numberOfAsteroidsAtStart = 5;
    public float spawnRate = 5f;

    private float timer = 0f;
    private bool isSpawning = false;

    private void Update()
    {
        if (!isSpawning)
        {
            return;
        }

        // Spawn an asteroid every spawnRate seconds
        if (timer > spawnRate)
        {
            SpawnAsteroid();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    public void StartSpawn()
    {
        isSpawning = true;
        // Spawn the initial asteroids
        for (int i = 0; i < numberOfAsteroidsAtStart; i++)
        {
            SpawnAsteroid();
        }
    }

    public void StopSpawn()
    {
        Debug.Log("Stop Spawn");
        isSpawning = false;
        // Destroy all asteroids after 1 second
        Invoke(nameof(DestroyAllAsteroids), 1f);
    }

    private void DestroyAllAsteroids()
    {
        var asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (var asteroid in asteroids)
        {
            // Calling destroy directly will not trigger the score
            Destroy(asteroid);
        }
    }

    private void SpawnAsteroid()
    {
        // Get a random value for the x and y position either 0 or 1
        int randomX = Random.Range(0, 2);
        int randomY = Random.Range(0, 2);
        // Get a random position on the screen
        Vector3 randomPosition = Camera.main.ViewportToWorldPoint(
            new Vector3(randomX, randomY, Camera.main.transform.position.y)
        );

        SpawnAsteroid(randomPosition, true);
    }

    private void SpawnAsteroid(Vector3 position, bool isBig)
    {
        // Get a random asteroid prefab
        int randomIndex = Random.Range(0, asteroidPrefabs.Count);
        GameObject asteroidPrefab = asteroidPrefabs[randomIndex];

        // Spawn the asteroid
        GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
        asteroid.transform.position = position;
        asteroid.GetComponent<Asteroid>().isBig = isBig;
        asteroid
            .GetComponent<DestroyedHandler>()
            .OnDestroyed.AddListener(GameManager.Instance.AsteroidDestroyed);
    }

    public void SpawnSmallAsteroids(Vector3 position)
    {
        var count = Random.Range(2, 4);
        for (var i = 0; i < count; i++)
        {
            SpawnAsteroid(position, false);
        }
    }
}
