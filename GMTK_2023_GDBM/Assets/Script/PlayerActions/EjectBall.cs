using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectBall : MonoBehaviour
{
    [SerializeField] float force = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Eject(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Eject(collision.gameObject);
        }
    }

    private void Eject(GameObject ball)
    {
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        Vector2 dir = (ball.transform.position - transform.position).normalized;

        rb.AddForce(dir * force, ForceMode2D.Impulse);
    }
}
