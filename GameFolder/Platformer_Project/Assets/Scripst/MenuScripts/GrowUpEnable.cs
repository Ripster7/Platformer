using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowUpEnable : MonoBehaviour {

    // Init for scaleWindowOverTime()
    public float maxSize;              // max scale
    public float growFactor;           // speed of scale
    public float waitTime;             // Time before returning size down

    public MenuButtonFuncs MenuHook;
    public Image img;

    public bool playOnce = true;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        if(playOnce == true)
        {
            scaleWindowOverTime();
        }


    }

    public void scaleWindowOverTime()
    {

        StartCoroutine(Scale());
        StartCoroutine(FadeImage(true));
    }

    IEnumerator Scale()
    {
        float timer = 0;

        if (playOnce == true)
        {
            playOnce = false;
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            // reset the timer

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);

        }

    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
