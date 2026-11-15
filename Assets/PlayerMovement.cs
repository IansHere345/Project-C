using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public bool WASD; //Checked for player 1 and unchecked for player 2
    Rigidbody rb;
    movingPlatform currentPlatform;
    Vector3 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMove = 0f;
        float VerticalMove = 0f;

        if (WASD)
        {
            if (Input.GetKey(KeyCode.W))
            {
                VerticalMove = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                VerticalMove = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                HorizontalMove = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                HorizontalMove = 1f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                VerticalMove = 1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                VerticalMove = -1f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                HorizontalMove = -1f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                HorizontalMove = 1f;
            }
        }
        // This makes it so one player uses WASD and the other uses arrow keys with the press of a button in the inspector
        
        moveDirection = new Vector3(HorizontalMove, 0, VerticalMove);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = toRotate;

            //Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);

            //The Quaternion skips the rotation so the player faces the direction they want to insantly.
        }
    }
    void FixedUpdate()
    {
    Vector3 velocity = moveDirection * speed;

    if (currentPlatform != null)
        {
            velocity += currentPlatform.Velocity;
        }

    rb.linearVelocity = new Vector3
        (
        velocity.x,
        rb.linearVelocity.y,
        velocity.z
        );
    }   
    void OnCollisionStay(Collision collision)
    {
    if (collision.gameObject.TryGetComponent(out movingPlatform platform))
        {
        foreach (ContactPoint contact in collision.contacts)
            {
            if (contact.normal.y > 0.5f)
                {
                currentPlatform = platform;
                break;
                }
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (currentPlatform != null && collision.gameObject == currentPlatform.gameObject)
        {
            currentPlatform = null;
        }
        //Helps the player stay on the platform without just sliding off.
    }
    public void ActiveSpeedBoost()
    {
        speed = speed + 1;
        //Speed is increased by 1 when collecting an item.
    }
}
//Sources Used: https://www.youtube.com/watch?v=F7bdwOFofLk&list=PLkp23zg4CAMV8fcsUYX1EwihX7WXhFH6N&index=1
        // https://www.youtube.com/watch?v=v6Kh748AwJU&list=PLkp23zg4CAMV8fcsUYX1EwihX7WXhFH6N&index=2
