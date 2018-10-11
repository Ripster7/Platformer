using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {


    public ParticleSystem confetti;
    [Space(5)]
    public bool activated;
    [Space(5)]
    public bool triggerActive;

    public float triggerTimer;

	// Use this for initialization
	void Start ()
    {
        triggerActive = false;
        activated = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(triggerActive == true)
        {
            triggerTimer += Time.deltaTime;
        }
        if (triggerTimer >= 5)
        {

            activated = true;
            confetti.Play();
        }
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            triggerActive = true;
        }
        else triggerActive = false;
    }
}
