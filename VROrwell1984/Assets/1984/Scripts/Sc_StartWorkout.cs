using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    Diese Script regelt, wann das Workout in WinstonsRoom beginnt. Hierzu werden zwei Phasen erzeugt.
    Phase 1) die Zeit ist zum ersten mal abgelaufen -> Spiele den Sound ab
    Phase 2) die Zeit ist zum zweiten mal abgelaufen -> Rufe die Funktion WorkOutGame() auf dem Objekt "Workoutgame" auf.
     */

public class Sc_StartWorkout : MonoBehaviour {
    public float timed;
    public float timed1;
    public AudioSource sound;
    private bool first;
    private bool second;
    public GameObject Workoutgame;

	// Use this for initialization
	void Start () {
        //timed = 60f;
        first = true;
        second = true;
        sound.SetScheduledStartTime(10d);
        
	}

    // Update is called once per frame
    void Update () {
        if (first)
        {
            timed -= Time.deltaTime;
        }
        else
        {
            timed1 -= Time.deltaTime;
        }
        if(timed <= 0 && first)
        {
            sound.Play();
            first = false;
        }
        if(timed1 <= 0f && second)
        {
            Workoutgame.SetActive(true);
            Workoutgame.GetComponent<Sc_Workout>().WorkOutGame();
            second = false;
        }
    }
}
