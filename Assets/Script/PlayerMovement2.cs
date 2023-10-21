using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;

    Vector3 velocity, desiredVelocity;

    Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 direction;
        direction.x = Input.GetAxis("Horizontal"); //has value 1 or -1
        direction.y = Input.GetAxis("Vertical"); //has value 1 or -1

        Debug.Log(direction);

        direction = Vector2.ClampMagnitude(direction, 1f);

        desiredVelocity = new Vector3(direction.x,direction.y, 0f) * maxSpeed;

    }

    void LateUpdate()
    {
        velocity = body.velocity;
        float acceleration = maxAcceleration;

        float maxSpeedChange = acceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);

        body.velocity = velocity;
    }
}