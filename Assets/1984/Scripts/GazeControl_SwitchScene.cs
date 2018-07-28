using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	je nachdem ob durch das Script playTimeToGoToWork die Variable Arbeit bereits
 auf true gesetzt wurde oder nicht wird entweder eine Ansage abgespielt oder
 durch SceneManager.LoadScene(SceneToSwitchTo) die Szene gewechselt
*/

public class GazeControl_SwitchScene : MonoBehaviour {

	public string SceneToSwitchTo = "";
	public Animator Anime;
	public float MyTime = 0f;

	public Transform RadialProgress;


	
	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;
	}
	
	
	public void Update () {
		MyTime += Time.deltaTime;

		RadialProgress.GetComponent<Image>().fillAmount = MyTime/3;


		if(MyTime >=3f && playTimeToGoToWork.Arbeit == true )
		{
		SceneManager.LoadScene(SceneToSwitchTo); }

		else if (MyTime >=3f && playTimeToGoToWork.Arbeit == false ){
			GetComponent<AudioSource>().Play();
			Resetinator();
		}
	
		
	}

	
	public void Resetinator () {
		MyTime = 0f;
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;

	}



}
