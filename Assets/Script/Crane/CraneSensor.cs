using UnityEngine;
using System.Collections;

namespace Crane{
	public class CraneSensor : MonoBehaviour {
		Crane crane;

		void Start(){
			crane = gameObject.GetComponent<Crane>();
		}

		public void OnTriggerEnter2D(Collider2D other){
			crane.reachedObj = other;
		}
	}
}