using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Ijin;

namespace Navigator{
	public class Ochimusha : MonoBehaviour{
		public AbstractIjin catchedIjin;
		AbstractIjin questionedIjin;

		void Start(){
			catchedIjin = null;
		}

		void Update(){
	
		}

		public void Question(){
			if (SceneManager.GetSceneByName("Question").isLoaded == false){
				GameObject.Find("Button_left").GetComponent<BoxCollider2D>().enabled = false;
				GameObject.Find("Button_right").GetComponent<BoxCollider2D>().enabled = false;
				UnityEngine.SceneManagement.SceneManager.LoadScene("Question", LoadSceneMode.Additive);
				questionedIjin = catchedIjin;
			}
		}

		public bool Judge(Answer player_answer){
			if (questionedIjin.question_answer == player_answer){
				return true;
			} else{
				return false;
			}
		}

		public void ResponeIjin(){
			questionedIjin.Respone();
		}
	}
}