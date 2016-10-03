using UnityEngine;
using System.Collections;
using Crane;

public class Charactor : MonoBehaviour {
	void Start () {

	}
	
	void OnTriggerStay2D(Collider2D collider) {
		if(Crane.Crane.isCatched == false && collider.tag == "Crane" && Crane.Crane.state == State.Closed){
			Crane.Crane.isCatched = true;
			Debug.Log("Catch!!");
		}
	}
}
