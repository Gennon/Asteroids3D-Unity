using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AsteroidSpawner))]
public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public UnityEvent OnGameOver;
    public UnityEvent OnGameStarted;
    public UnityEvent<int> OnScoreUpdated;

    private static AsteroidSpawner asteroidSpawner;

    public static GameManager Instance { get; private set; }
    public static int Score { get; private set; }
    public static int ShotsFired { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Destroy the game object this script is attached to
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Player Died");
        OnGameOver?.Invoke();
        asteroidSpawner.StopSpawn();
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        OnGameStarted?.Invoke();
        Score = 0;
        ShotsFired = 0;
        OnScoreUpdated?.Invoke(Score);
        asteroidSpawner = GetComponent<AsteroidSpawner>();
        asteroidSpawner.StartSpawn();

        // Instantiate the player
        var player = Instantiate(Player);
        player.GetComponent<DestroyedHandler>().OnDestroyed.AddListener((_) => PlayerDied());
        player.GetComponent<PlayerActions>().OnFire.AddListener(() => ShotFired());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AsteroidDestroyed(GameObject asteroid)
    {
        Score += 1;
        OnScoreUpdated?.Invoke(Score);
        var isBig = asteroid.GetComponent<Asteroid>().isBig;
        if (isBig)
        {
            asteroidSpawner.SpawnSmallAsteroids(asteroid.transform.position);
        }
    }

    public void ShotFired()
    {
        ShotsFired += 1;
    }
}
