using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    /*
    Durch dieses Script werden in der OfficeRoom Szene die im ScoreManager gespeicherten Ergebnisse
    auf einem Canvas-Element dargestellt.
     */

public class Sc_Scoreboard : MonoBehaviour {
    
    public Sc_ScoreManager ScoreManager;
    public Text Books;
    public Text Workout;

	// Use this for initialization
	void Start () {
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<Sc_ScoreManager>();
        Books.text = ScoreManager.booksSorted.ToString();
        Workout.text = ScoreManager.workoutCount.ToString();
	}

}
