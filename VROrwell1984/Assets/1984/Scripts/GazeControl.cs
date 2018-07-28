using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	Das Grundgerüst-Skript für alle GazeControl Skripte.
Auf dem Canvas Element dass ein Unterelement von MainCamera ist, wird das Bild
des Kreises dass sich unter Image befindet, wenn das Skript aktiv ist, durch
"RadialProgress.GetComponent<Image>().fillAmount = MyTime/3;"" gefüllt
*/

public class GazeControl : MonoBehaviour {

	public Animator Anime;
	public float MyTime = 0f; //Start Wert 0, da Kreis zunächst ungefüllt sein soll
	public Transform RadialProgress;

	
	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = MyTime; 
		//MyTime wird die verstrichene Zeit zugewiesen
	}
	
	
	public void Update () {
		MyTime += Time.deltaTime;

		RadialProgress.GetComponent<Image>().fillAmount = MyTime/3;


		if(MyTime >=3f) 
		{
			
		// do stuff
	}
	}

	
	public void Resetinator () {
		MyTime = 0f;
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;

	}



}
