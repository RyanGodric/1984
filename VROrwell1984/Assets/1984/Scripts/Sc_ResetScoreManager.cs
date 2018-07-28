using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
        Dieses Script sucht nach dem ScoreManager und zerstört das Objekt.
     */

public class Sc_ResetScoreManager : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        try
        {
            Destroy(GameObject.Find("ScoreManager"));
        }
        catch
        {
            Debug.Log("Could not destroy ScoreManager");
        }
	}
	
}
