using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TO-DO: Inventarse una forma chula de darle una dirección inicial a la bola

public class RandomInitialVelocity : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 initialDir = Random.insideUnitCircle.normalized;
        //print("Initial dir: " + initialDir);

        rb.velocity = initialDir * speed;
    }
}
