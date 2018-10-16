using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGlow : MonoBehaviour {

    float floor = 0.3f;
    float ceiling = 1.0f;
    public float addTime = 0.0f;
    private bool starter = true;

    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {

        if (starter == true)
        {
            Renderer renderer = GetComponent<Renderer>();
            Material mat = renderer.material;

            float emission = Mathf.PingPong(Time.time * addTime, ceiling - floor);
            Color baseColor = Color.yellow;

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
        }


    }



}
