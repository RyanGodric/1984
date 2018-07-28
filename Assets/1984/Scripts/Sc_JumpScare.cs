using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
        Spielt nach einer zufälligen Zeit zwischen 10 und 30 Sekunden eine Animation ab und aktiviert
        das Canvas Element für ein FadeToBlack
     */

public class Sc_JumpScare : MonoBehaviour {
    public Animation ratScare;
    public float time;
    public bool played;
    public GameObject hasFadeToBlack;

	// Use this for initialization
	void Start () {
        played = false;
        time = Random.Range(10f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 9.5f && time >= 9.0f)
        {
            hasFadeToBlack.SetActive(true);
            hasFadeToBlack.GetComponent<Sc_FadeToBlack>().speed = .5f;
        }
        if (time <= 0 && !played)
        {
            ratScare.Play();
            played = true;
        }
	}
}
