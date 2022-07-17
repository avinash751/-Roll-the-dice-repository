using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController controller;
    public static float speed = 5.0f;
    public static float gravity = 0.75f;
    public float jumpheight = 15.0f;
    private float yvelocity;
    public static bool move = true;
    public static bool jump = true;

 
 
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
            if (Input.GetKeyDown(KeyCode.Space) && jump == true)
            {
                yvelocity = jumpheight;              
            }

        }
        else
        {
            yvelocity -= gravity;
        }

        velocity.y = yvelocity;

        if (move == true)
        {
            controller.Move(velocity * Time.deltaTime);
        }
        
    }

}
