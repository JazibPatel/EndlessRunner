using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float obstacleYPosition;
    public float destroyZ = -20f;


    void Update()
    {
        // Move tree backward along world Z
        transform.Translate(Vector3.back * gameManager.Instance.obstacleSpeed * Time.deltaTime, Space.World);

        // Lock Y so it never sinks
        transform.position = new Vector3(transform.position.x, obstacleYPosition, transform.position.z);

        // Destroy when out of view
        if (transform.position.z <= destroyZ)
        {
            Destroy(gameObject);
        }
    }

}


//    public float fixedY = 0.5f;
//    private Rigidbody rb;
//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        rb.useGravity = false;   // no falling
//        rb.isKinematic = false;  // physics active
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector3 move = Vector3.back * gameManager.Instance.obstacleSpeed * Time.deltaTime;
//        rb.MovePosition(rb.position + move);

//        if (rb.position.z <= destroyZ)
//        {
//            Destroy(gameObject);
//        }
//    }
//}
