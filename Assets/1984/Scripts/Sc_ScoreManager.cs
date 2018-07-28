using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    /*
        Dieses Script bleibt durch die ganze App aktiv und speichert Interaktionen und Ergebnisse des Spielers.
        Dazu werden die Variablen der Klasse von anderen Scripten gesetzt und verändert.
     */

public class Sc_ScoreManager : MonoBehaviour {

    private bool created;
    
    public List<float> Rotations;
    public List<Vector3> Positions;

    public bool workout;

    public int workoutCount;

    public int booksSorted;

    public int booksWrong;

    public int Notes;

    // Use this for initialization
    void Start () {
        workout = false;
        workoutCount = 0;
        booksSorted = 0;
        booksWrong = 0;
        Notes = 0;

        
	}

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this);
            created = true;
        }
    }
}
