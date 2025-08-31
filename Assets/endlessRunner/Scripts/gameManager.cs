using System.Collections;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    [Header("Speeds")]
    public float roadSpeed = 0.2f;
    public float obstacleSpeed = 5f;

    private float defaultRoadSpeed;
    private float defaultObstacleSpeed;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        defaultRoadSpeed = roadSpeed;
        defaultObstacleSpeed = obstacleSpeed;
    }

    public void StopGameForSeconds(float seconds)
    {
        StartCoroutine(StopRoutine(seconds));
    }

    IEnumerator StopRoutine(float seconds)
    {
        roadSpeed = 0f;
        obstacleSpeed = 0f;

        yield return new WaitForSeconds(seconds);

        roadSpeed = defaultRoadSpeed;
        obstacleSpeed = defaultObstacleSpeed;
    }
}
