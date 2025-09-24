using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.1f; // Fixed movement speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.drag = 0f;
        rb.angularDrag = 0f;

        // Set initial velocity in a random XZ direction
        rb.velocity = GetRandomDirection() * speed;
    }

    void FixedUpdate()
    {
        // Maintain fixed speed and current direction
        rb.velocity = rb.velocity.normalized * speed;
    }

    Vector3 GetRandomDirection()
    {
        Vector3 dir;
        do
        {
            dir = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        } while (dir.magnitude < 0.1f); // Avoid near-zero direction

        return dir.normalized;
    }
}