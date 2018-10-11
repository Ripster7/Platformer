using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonFuncs : MonoBehaviour {

    // Opthide is the "options panel" under "MenuCanvas". It should be OptHideINT number from 0 down.
    GameObject OptHide;
    int optHideINT = 4;                 // the number "options panel" is down

    // put in panels to grow
    public GrowUpEnable Rgrow;

    // Use this for initialization
    void Start () {

        OptHide = this.gameObject.transform.GetChild(optHideINT).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// MAIN MENU
    /// </summary>
    // The main menu Play Button
    public void button_PlayButtonMainMenu()
    {
        SceneManager.LoadScene("SOMEONE_PUTSCENEHERE");
    }

    // The main menu Options Button
    public void button_OptionsButtonMainMenu()
    {

        OptHide.SetActive(true);
    }

    // The main menu Exit Button
    public void button_ExitButtonMainMenu()
    {
        Application.Quit();
    }

    /// <summary>
    /// Options Buttons
    /// </summary>
    public void button_CloseOptionsX()
    {
        OptHide.SetActive(false);
        Rgrow.playOnce = true;
    }



    
}
