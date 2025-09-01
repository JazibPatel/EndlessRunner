using System.Collections;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    [Header("Speeds")]
    public float roadSpeed = 0.2f;
    public float obstacleSpeed = 5f;
    public float increaseSpawn = 2f;
    public float treespeed = 2f;

    private float defaultRoadSpeed;
    private float defaultObstacleSpeed;
    private float defaultObstacleSpaw;
    private float defaultTreeSpeed;

    [Header("Difficulty Settings")]
    public float roadAcceleration = 0.01f;     
    public float obstacleAcceleration = 0.1f;          
    public float increaseSpawnAcceleration = 1f;
    public float increaseTreeSpeed = 1f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        defaultRoadSpeed = roadSpeed;
        defaultObstacleSpeed = obstacleSpeed;
        defaultObstacleSpaw = increaseSpawn;
        defaultTreeSpeed = increaseTreeSpeed;
    }

    public void StopGameForSeconds(float seconds)
    {
        StartCoroutine(StopRoutine(seconds));
        //StartCoroutine(IncreaseDifficultyOverTime());
    }

    private void Update()
    {
        roadSpeed += roadAcceleration * Time.deltaTime;
        obstacleSpeed += obstacleAcceleration * Time.deltaTime;
        increaseSpawn -= increaseSpawnAcceleration * Time.deltaTime;
        increaseSpawn = Mathf.Max(0.3f, increaseSpawn); // minimum 0.3s delay
        treespeed += increaseTreeSpeed * Time.deltaTime;

    }
    IEnumerator StopRoutine(float seconds)
    {
        roadSpeed = 0f;
        obstacleSpeed = 0f;
        increaseSpawn = 0f;
        treespeed = 0f;

        FindObjectOfType<obstacleSpawn>().PauseSpawning();

        yield return new WaitForSeconds(seconds);

        roadSpeed = defaultRoadSpeed;
        obstacleSpeed = defaultObstacleSpeed;
        increaseSpawn = defaultObstacleSpaw;
        treespeed *= defaultTreeSpeed;

        FindObjectOfType<obstacleSpawn>().ResumeSpawning();
    }
}
