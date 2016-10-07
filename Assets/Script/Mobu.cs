using UnityEngine;
using System.Collections;
using Common;
using Crane;

namespace Ejin
{
	public class Mobu : MonoBehaviour
	{
		Vector3 default_position;

		void Start ()
		{
			default_position = transform.position;
		}

		void Update ()
		{	
			if (Input.GetKeyDown (KeyCode.R)) {
				transform.position = default_position;
			}
		}

		void OnTriggerStay2D(Collider2D collider) {
			if(Crane.Crane.isCatched == false && collider.tag == "Arm" && Crane.Crane.state == State.Closed){
				Crane.Crane.isCatched = true;
				Debug.Log("Catch!!");
			}
		}
	}
}
