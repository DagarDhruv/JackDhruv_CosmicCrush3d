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
        SetColorBySize();
    }

    void FixedUpdate()
    {
        // Maintain fixed speed and current direction
        rb.velocity = rb.velocity.normalized * speed;
    }


    void SetColorBySize()
    {
        // Assume size is based on localScale.x (assuming uniform scaling)
        float size = transform.localScale.x;

        // Map size to color (you can customize this)
        // Example: size 0.5 -> blue, size 2.0 -> red
        float t = Mathf.InverseLerp(0.5f, 2f, size); // Normalized 0 to 1
        Color color = Color.Lerp(Color.blue, Color.red, t);

        // Apply color to material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = new Material(renderer.material); // Avoid shared material issues
            renderer.material.color = color;
        }
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