using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	setzt ein Gameobject aktiv
*/

public class GazeControl_SetGameObjectActive : MonoBehaviour {

	public Animator Anime;
	public float timePassed = 0;
	public Transform RadialProgress;
	public GameObject selectedObject;
	public int secondsPassed { get { return (int) timePassed; } }

	
	void Start () {
		Anime = GetComponent<Animator>();
		RadialProgress.GetComponent<Image>().fillAmount = timePassed;
	}

	
	
	
	public void Update () {
		timePassed += Time.deltaTime;

		RadialProgress.GetComponent<Image>().fillAmount = timePassed/2;


		if(secondsPassed == 2)
		{
			selectedObject.SetActive (true);


	}
	}

	public void Resetinator () {
		timePassed = 0;
		RadialProgress.GetComponent<Image>().fillAmount = timePassed;

	}



}
