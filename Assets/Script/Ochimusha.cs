using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Navigator{
	public class Ochimusha : MonoBehaviour{

		void Start(){
	
		}

		void Update(){
	
		}

		public void Question(){
			if (SceneManager.GetSceneByName("Question").isLoaded == false){
				GameObject.Find("Button_left").GetComponent<BoxCollider2D>().enabled = false;
				GameObject.Find("Button_right").GetComponent<BoxCollider2D>().enabled = false;
				UnityEngine.SceneManagement.SceneManager.LoadScene("Question", LoadSceneMode.Additive);
			}
		}
	}
}