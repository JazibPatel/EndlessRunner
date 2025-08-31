using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    [Header("Obstacle Prefabs")]
    public GameObject roadBarrierPrefab;
    public GameObject roadBollardPrefab;
    public GameObject speedBumpPrefab;

    [Header("Spawn Points")]
    public Transform leftLane;
    public Transform rightLane;
    public Transform centerLane;

    [Header("Spawn Settings")]
    public float spawnDelay = 2f; // time (seconds) between spawns

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            // pick random obstacle type
            int type = Random.Range(0, 3); // 0 = barrier, 1 = bollard, 2 = bump

            if (type == 2) // speed bump → always center
            {
                Instantiate(speedBumpPrefab, centerLane.position, centerLane.rotation);
            }
            else
            {
                // barrier or bollard → random left or right
                Transform lane = (Random.value < 0.5f) ? leftLane : rightLane;

                if (type == 0)
                    Instantiate(roadBarrierPrefab, lane.position, lane.rotation);
                else
                    Instantiate(roadBollardPrefab, lane.position, lane.rotation);
            }
        }
    }
}
