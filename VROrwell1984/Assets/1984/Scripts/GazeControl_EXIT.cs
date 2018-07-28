using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//	Beendet die App

public class GazeControl_EXIT : MonoBehaviour {

	public Animator Anime;
	public float timePassed = 0;
	public Transform RadialProgress;
	public int secondsPassed { get { return (int) timePassed; } }

	
	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = timePassed;

	}	
	
	
	public void Update () {
		timePassed += Time.deltaTime;

		RadialProgress.GetComponent<Image>().fillAmount = timePassed/5;


		if(secondsPassed == 5 )
		{
			Application.Quit();

	}
	}

	public void Resetinator () {
		timePassed = 0;
		RadialProgress.GetComponent<Image>().fillAmount = timePassed;

	}



}
