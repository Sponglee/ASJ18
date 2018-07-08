using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	private _PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<_PlayerController> ();	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			thePlayer.hurt ();	 
		}

	}
}
