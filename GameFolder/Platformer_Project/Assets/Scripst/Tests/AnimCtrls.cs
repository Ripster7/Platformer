using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtrls : MonoBehaviour {

    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Base Layer.Run");


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");
        float yRot = Input.GetAxis("HorizontalRot");


        anim.SetFloat("FowardVelocity", move);
        anim.SetFloat("StrafeFloat", strafe);
        anim.SetFloat("RotationalBlend", yRot);


        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        /*if (Input.GetKeyDown(KeyCode.Space) && stateInfo.fullPathHash == runStateHash)
        {
            anim.SetFloat("FowardVelocity", 0.2f);
        }*/
    }
}