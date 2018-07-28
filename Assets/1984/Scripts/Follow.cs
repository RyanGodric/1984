using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ermöglicht zusammen mit dem Fly Skript die Bewegung unseres Player-Objekts 

public class Follow : MonoBehaviour {

    public GameObject target;
	private bool move;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void FixedUpdate(){
		move = target.GetComponent<Fly> ().getfly ();

	}

    void LateUpdate ()
    {
		if(move)
        	gameObject.transform.position = target.transform.position;
    }
}
