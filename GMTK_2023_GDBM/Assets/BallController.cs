using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float secondsFromResetToStartMoving = 1f;
    Vector3 startingPosition;
    Quaternion startingRotation;
    Rigidbody2D rb;
    TrailRenderer trailRenderer;

    [SerializeField]
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        AddVelocityInRandomDirection();
    }

    public void ResetStartingPosition()
    {
        trailRenderer.enabled = false;
        transform.position = startingPosition;
        transform.rotation = transform.rotation;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = 0f;
        StartCoroutine(EnableAndAddVelocityAfterSeconds(secondsFromResetToStartMoving));
    }

    private void AddVelocityInRandomDirection()
    {
        Vector2 initialDir = Random.insideUnitCircle.normalized;
        rb.velocity = initialDir * speed;
    }

    IEnumerator EnableAndAddVelocityAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        trailRenderer.enabled = true;
        AddVelocityInRandomDirection();
    }
}
