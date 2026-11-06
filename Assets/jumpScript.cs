using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
public class JumpScript : MonoBehaviour
{
    public bool WASD; //This is needed for the script to work with both players, not just one
    private Rigidbody rb;
    private bool isJumping;
    public float fallMultiplier = 3.5f;
    public float jumpSpeedMultiplier = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.y > 0)
        {
            rb.AddForce(Physics.gravity * (jumpSpeedMultiplier - 1.0f), ForceMode.Acceleration);
        }
        else if (rb.linearVelocity.y < 0)
        {
            rb.AddForce(Physics.gravity * (fallMultiplier - 1.0f), ForceMode.Acceleration);
        }

        if (WASD)
        {
            if (isJumping == false && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
            rb.linearVelocity = new Vector3(0, 50, 0);
            isJumping = true;
            }
        }
        else
        {
            if (isJumping == false && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
            rb.linearVelocity = new Vector3(0, 50, 0);
            isJumping = true;
            }
        }
        //isJumping is used first in the if statement since it was not being identified when it was listed last.
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
//Sources Used: https://www.codespeedy.com/jump-in-unity-3d-c/
//https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/rigidbody/addforce
