using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Vector3 startingPosition;
    Quaternion startingRotation;
    Rigidbody2D rb;
    [SerializeField] private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        AddVelocityInRandomDirection();
    }

    public void ResetStartingPosition()
    {
        transform.position = startingPosition;
        transform.rotation = transform.rotation;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = 0f;
        AddVelocityInRandomDirection();
    }

    private void AddVelocityInRandomDirection()
    {
        Vector2 initialDir = Random.insideUnitCircle.normalized;
        rb.velocity = initialDir * speed;
    }

}
