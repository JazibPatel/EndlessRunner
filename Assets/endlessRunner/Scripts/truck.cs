using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truck : MonoBehaviour
{
    public float laneDistance = 3f; // distance between lanes
    public float laneChangeSpeed = 5f; // how smooth to move
    public float jumpForce = 7f; // jump height
    private bool isGrounded = true;

    private int currentLane = 0; // 0 = center, -1 = left, +1 = right
    private Rigidbody rb;

    public AudioClip ObsticalHitSound;
    private AudioSource audioSource;

    [Header("Puse time on hit")]
    public float HoldTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Lane change input
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > -1)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 1)
        {
            currentLane++;
        }

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Smooth lane movement
        Vector3 targetPos = new Vector3(currentLane * laneDistance, rb.position.y, rb.position.z);
        Vector3 newPos = Vector3.Lerp(rb.position, targetPos, Time.deltaTime * laneChangeSpeed);
        rb.MovePosition(newPos);
    }

    IEnumerator KnockbackWorld()
    {
        float originalRoad = gameManager.Instance.roadSpeed;
        float originalObs = gameManager.Instance.obstacleSpeed;

        gameManager.Instance.roadSpeed = -originalRoad * 0.5f;
        gameManager.Instance.obstacleSpeed = -originalObs * 0.5f;

        yield return new WaitForSeconds(HoldTime);

        gameManager.Instance.roadSpeed = originalRoad;
        gameManager.Instance.obstacleSpeed = originalObs;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(ObsticalHitSound, 0.3f);
            StartCoroutine(KnockbackWorld());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

