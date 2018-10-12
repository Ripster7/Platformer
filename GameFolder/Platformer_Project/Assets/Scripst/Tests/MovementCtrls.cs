using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCtrls : MonoBehaviour {
    public float move, strafe, yRot, rotSpeed;
    float speed = 0.1f;
    // Use this for initialization
    void Start () {
		
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
        }
        else yRot = 0;
        
        
        //shoot raycast, add force in vector of ray

        transform.localEulerAngles+= new Vector3(0,yRot,0);
    }
}
