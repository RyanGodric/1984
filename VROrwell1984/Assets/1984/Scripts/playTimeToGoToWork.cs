using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*	spielt nach einer festgelegten Zeit die Tondurchsage
 "it is time to go to work ab" und setzt die Variable Arbeit anschließend
 auf true 
*/

public class playTimeToGoToWork : MonoBehaviour {


	public float timePassed = 0;
	public static bool Arbeit = false;
	


	public int SecondsPassed { get { return (int) timePassed; } }
	
	public void Update () {
		
		timePassed += Time.deltaTime;

		if(SecondsPassed == 120 ) 
		{
			GetComponent<AudioSource>().Play();
			Arbeit = true;
	}

		
	}




}
		




