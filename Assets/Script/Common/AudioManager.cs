using UnityEngine;
using System.Collections;

namespace Common{
	public class AudioManager : MonoBehaviour{
		static bool isCreated = false;

		AudioSource sound;
		AudioSource bgm;

		void Awake(){
			if (!isCreated){
				DontDestroyOnLoad(this.gameObject);
				isCreated = true;
			} else{
				Destroy(this.gameObject);
			}
		}

		void Start(){
			
			sound = GetComponents<AudioSource>()[0];
			bgm = GetComponents<AudioSource>()[1];
		}
	
		// Update is called once per frame
		void Update(){
			
		}

		public void PlayRespone(){
			sound.clip = Resources.Load<AudioClip>("Audio/button02");
			sound.PlayOneShot(sound.clip);
		}

		public void PlayOnShot(string fileName){
			sound.clip = Resources.Load<AudioClip>("Audio/" + fileName);
			sound.PlayOneShot(sound.clip);
		}

		public void StopBGM(){
			bgm.Stop();
		}

		public void PlayBGM(){
			bgm.loop = true;
			bgm.Play();
		}
	}
}