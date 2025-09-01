//using UnityEngine;

//public class TreeScroller : MonoBehaviour
//{
//    //public float speed = 2f;        // scroll speed
//    public float resetZ = 40f;      // position to reset tree ahead
//    public float minZ = -20f;       // when tree goes below this, reset

//    void Update()
//    {
//        // Move tree backward
//        transform.Translate(Vector3.back * gameManager.Instance.treespeed * Time.deltaTime);

//        // If tree goes behind camera, reset forward
//        if (transform.position.z < minZ)
//        {
//            transform.position = new Vector3(transform.position.x, transform.position.y, resetZ);
//        }
//    }
//}


using UnityEngine;

public class TreeScroller : MonoBehaviour
{
    public float resetZ = 40f;   // position to reset tree ahead
    public float minZ = -20f;    // when tree goes below this, reset
    public float fixedY;        // locked Y position

    void Start()
    {
        fixedY = transform.position.y; // remember starting height
    }

    void Update()
    {
        // Move only on Z axis
        transform.Translate(Vector3.back * gameManager.Instance.treespeed * Time.deltaTime, Space.World);

        // Force Y
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);

        // Debug print
        Debug.Log(gameObject.name + " Y = " + transform.position.y);

        // Reset on minZ
        if (transform.position.z < minZ)
        {
            transform.position = new Vector3(transform.position.x, fixedY, resetZ);
        }
    }

}
