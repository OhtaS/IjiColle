using UnityEngine;
using System.Collections;

namespace Common
{
	public class AudioManager : MonoBehaviour
	{
		AudioSource sound01;
		// Use this for initialization
		void Start ()
		{
			sound01 = GetComponent<AudioSource>();
		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}

		public void PlayRespone(){
			sound01.PlayOneShot(sound01.clip);
		}
	}
}