using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotCam : MonoBehaviour {

    public float xRot, rotSpeed;
    public int calmpNeg = -45, viewRange = 35;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetAxis("VerticalRot") > 0.1 || -0.1 > Input.GetAxis("VerticalRot"))
        {
            xRot = (Input.GetAxis("VerticalRot") * rotSpeed);
            //SoundManager.PlaySfx("");
        }
        else xRot = 0;
        */

        xRot += Input.GetAxis("VerticalRot") * rotSpeed * Time.deltaTime;

        transform.localEulerAngles = new Vector3(xRot % 360, 0, 0);
        xRot = Mathf.Clamp(xRot, -viewRange, viewRange);

        transform.localEulerAngles += new Vector3(xRot, 0, 0);
        //transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, -180, 180), transform.localEulerAngles.y, transform.localEulerAngles.z);
        //transform.localEulerAngles = new Vector3(Mathf.Clamp(xRot,-viewRange, viewRange), 0, 0);




        /*
        if (transform.localEulerAngles.x > viewRange)
        {
            transform.localEulerAngles = new Vector3(viewRange, 0, 0);
        }
        else
        {
            if (transform.localEulerAngles.x < -viewRange)
            {
                transform.localEulerAngles = new Vector3(-viewRange, 0, 0);
            }
        }
        */
    }
}
