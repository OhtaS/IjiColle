using UnityEngine;
using System.Collections;

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
			if (Input.GetKey (KeyCode.R)) {
				transform.position = default_position;
			}
		}
	}
}
