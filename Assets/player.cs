using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5.0f;
    public float gravity = 1.0f;
    public float jumpheight = 15.0f;
    private float yvelocity;
    private bool candoublejump = false;
 
 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0);
        Vector3 velocity = direction * speed;
        if (controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yvelocity = jumpheight;
                
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (candoublejump == true)
                {
                    yvelocity += jumpheight * 2;
                    candoublejump = false;
                }

            }

            yvelocity -= gravity;
        }
        velocity.y = yvelocity;
        controller.Move(velocity * Time.deltaTime);
    }

}
