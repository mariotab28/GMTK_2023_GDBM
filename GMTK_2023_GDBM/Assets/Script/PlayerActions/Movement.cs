using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetDirection(Vector2 value)
    {
        direction = value;
    }
}
