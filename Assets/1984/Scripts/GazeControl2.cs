using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	Nachdem sich der Kreis gefüllt hat wird durch 
SceneManager.LoadScene(SceneToSwitchTo)
die Szene zu "WinstonsRoom" gewechselt
*/

public class GazeControl2 : MonoBehaviour {

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


		if(MyTime >=3f) 
		{
		SceneManager.LoadScene("WinstonsRoom");
	}
	}

	public void Resetinator () {
		MyTime = 0f;
		RadialProgress.GetComponent<Image>().fillAmount = MyTime;

	}



}
