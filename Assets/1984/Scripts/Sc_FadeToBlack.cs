using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    /*
        Dieses Skript steigert zehn Sekunden, nachdem es aktiviert wurde die Sichtbarkeit eines Images und erzeugt so
        einen Fade to Black. Danach wird die Introszene erneut geladen.
    */

public class Sc_FadeToBlack : MonoBehaviour {
    [Range(0.001f,1f)]
    public float speed;
    public Image myImage;
    float time;
    public bool fade;
    Color actualColor;
	// Use this for initialization
	void Start () {
        time = 0f;

        fade = false;
        actualColor = new Color(0f,0f,0f,0f);
        speed = .30f;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 10f)
        {
            fade = true;
        }
        if (fade)
        {
            actualColor.a += (Time.deltaTime*speed);
            myImage.color = actualColor;
            //time = 0f;
            if(actualColor.a >= 1f)
            {
                SceneManager.LoadScene("IntroRoom");
                fade = false;
            }
        }
        

    }
}
