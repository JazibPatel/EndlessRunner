using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public float destroyZ = -20f;
    public float fixedY = 0f; // ground height

    void Update()
    {
        // Move tree backward along Z only
        transform.Translate(Vector3.back * gameManager.Instance.obstacleSpeed * Time.deltaTime, Space.World);

        // Lock Y so it never sinks
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);

        // Destroy when out of view
        if (transform.position.z <= destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
