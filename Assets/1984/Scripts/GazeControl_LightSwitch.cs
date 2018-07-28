using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	Ermöglicht es in Verbindung mit dem Skript Sc_LightsOut
 das Licht in WinstonsRoom an und aus zuschalten
*/

public class GazeControl_LightSwitch : MonoBehaviour {

	public Animator Anime;
	public float timePassed = 0;
	public Transform RadialProgress;
	public int secondsPassed { get { return (int) timePassed; } }
	public bool platzhalter;

	
	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = timePassed;
		platzhalter = true;

	}

	public void Reset_platzhalter(){
		platzhalter = true;
	}
	
	
	
	public void Update () {
		timePassed += Time.deltaTime;

		RadialProgress.GetComponent<Image>().fillAmount = timePassed/2;


		if(secondsPassed == 2 && platzhalter == true)
		{
			GetComponent<Sc_LightsOut>().ToogleLights();
			platzhalter = false;

	}
	}

	public void Resetinator () {
		timePassed = 0;
		RadialProgress.GetComponent<Image>().fillAmount = timePassed;

	}



}
