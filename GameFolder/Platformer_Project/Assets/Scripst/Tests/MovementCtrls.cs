using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCtrls : MonoBehaviour {
    public float move, strafe, yRot, rotSpeed;
    float speed = 0.1f;
    [Space(20)]

    public int jumpCounter = 0;
    public float jumpForce = 500;

    private Rigidbody rb_Player;

    // Use this for initialization
    void Start ()
    {
        jumpCounter = 0;
        rb_Player = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        move = (Input.GetAxis("Vertical") * speed);
        strafe = (Input.GetAxis("Horizontal") * speed);

        transform.localPosition += (transform.forward * move) + (transform.right * strafe);

        //transform.forward += new Vector3(strafe, 0, move);
        if (Input.GetAxis("HorizontalRot") > 0.1 || -0.1 > Input.GetAxis("HorizontalRot"))
        {
            yRot = (Input.GetAxis("HorizontalRot") * rotSpeed);
            //SoundManager.PlaySfx("");
        }
        else yRot = 0;

        if (Input.GetKeyDown("joystick 1 button 0") && jumpCounter <= 1)
        {
            print("up");
            jumpCounter = jumpCounter + 1;
            rb_Player.AddForce(Vector3.up * jumpForce);
            //play jump animation
        }
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(transform.position, -Vector3.up, out hit);
        {
            var distanceToGround = hit.distance;
            print(distanceToGround.ToString("F0"));
            if (distanceToGround < 0.001f ) jumpCounter = 0;
        }

        //shoot raycast, add force in vector of ray

        transform.localEulerAngles+= new Vector3(0,yRot,0);
    }
}
