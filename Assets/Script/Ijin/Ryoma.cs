using UnityEngine;
using System.Collections;
using Common;

namespace Ejin
{
	public class Ryoma : MonoBehaviour
	{
		Vector3 default_position;
		// Use this for initialization
		void Start ()
		{
			default_position = transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{	
			if (Input.GetKeyDown (KeyCode.R)) {
				transform.position = default_position;
				GameObject.Find ("SoundManager").GetComponent<SoundManager> ().PlayRespone ();
			}
		}
	}
}
