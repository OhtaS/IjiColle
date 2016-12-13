using UnityEngine;
using System.Collections;
using Crane;
using Ijin;

public class Sensor : MonoBehaviour {
	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Ijin"){
			GameObject.Find("Crane").GetComponent<IIjinListener>().CheckTo(other.gameObject.GetComponent<AbstractIjin>());
		}else if(other.gameObject.tag == "Item"){
			other.gameObject.tag = "CatchedItem";
		}
	}

	public void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Ijin"){
			GameObject.Find("Crane").GetComponent<IIjinListener>().CheckTo(null);
		}
	}
}
