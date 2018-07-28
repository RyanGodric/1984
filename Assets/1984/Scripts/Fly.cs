using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ermöglicht die Bewegung unseres Player-Objekts in Verbindung mit dem Follow
//Skript. 

public class Fly : MonoBehaviour {
    public float acceleration;
    public float maxSpeed;
    public GameObject pointer;
	private bool fly;
	

	void Start () {
		fly = false;
	}
	
	
	void Update () {
		
	}

    public void initiateFly(bool x) { fly = x; }

	public void changeState(){
		fly = !fly;
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = Vector3.zero;
	}

	public bool getfly(){
		return fly;
	}

    void FixedUpdate()  {
		if (fly) {
			Rigidbody rb = GetComponent<Rigidbody> ();
			rb.AddForce (acceleration * pointer.transform.forward * Time.deltaTime);
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);
		} 
    }
}
