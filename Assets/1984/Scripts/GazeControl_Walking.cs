using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	Das Script liegt auf dem Objekt start walking Poster und wird durch Anschauen
des Posters aktiviert.
Wenn der Kreis gefüllt ist, wird der state im Fly Script geändert
und damit die Bewegung gestartet oder gestoppt.
*/

public class GazeControl_Walking : MonoBehaviour {

	public Animator Anime;
	public float timePassed = 0;
	public Transform RadialProgress;
	public int secondsPassed { get { return (int) timePassed; } }
	public bool platzhalter;


	// Initialisierung

	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = timePassed;
		platzhalter = true;
	}

//platzhalter wird zurückgesetzt wenn der Cursor auf das Poster trifft

	public void Reset_platzhalter(){
		platzhalter = true;
	}
	
// Update wird ein mal pro Frame ausgeführt

	public void Update () {

		
		timePassed += Time.deltaTime;;
	
		RadialProgress.GetComponent<Image>().fillAmount = timePassed/2;

// wenn der Kreis gefüllt ist (nach 2 Sekunden) wird der State des Fly Scripts geändert

		if(secondsPassed == 2 && platzhalter == true) 
		{
		GetComponent<Fly>().changeState();
		platzhalter = false;
	}

		
	}

	// timePassed wird zurückgesetzt

	public void Resetinator () {
		timePassed = 0;
		RadialProgress.GetComponent<Image>().fillAmount = timePassed;

    }



}
