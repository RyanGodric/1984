using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Setzt die Intensität aller Lichter herab. Erzeugt so einen "Fade to Black" , der auch mit Cardboard funktioniert.
     */

public class Sc_FadeToBlackTortureRoom : MonoBehaviour {
    public List<Light> lights;
    public float speed;
    public bool fade;
    private float time;

    // Use this for initialization
    void Start()
    {
        speed = .035f;
        time = 0.0f;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (fade)
        {
            foreach (Light l in lights){
                l.intensity -= l.intensity * speed;
                if(l.intensity <= 0.0001f)
                {
                    fade = false;
                    SceneManager.LoadScene("IntroRoom");
                }
            }
        }
	}

    public void Fade()
    {
        fade = true;
    }
}
