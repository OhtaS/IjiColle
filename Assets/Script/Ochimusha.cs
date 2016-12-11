using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Ijin;

namespace Navigator{
	public class Ochimusha : MonoBehaviour{
		public AbstractIjin catchedIjin;
		AbstractIjin questionedIjin;
		bool isQuestioning;

		void Start(){
			isQuestioning = false;
			catchedIjin = null;
		}

		void Update(){
	
		}

		public IEnumerator Question(){
			if (isQuestioning){
				yield break;
			}
			isQuestioning = true;

			if (SceneManager.GetSceneByName("Question").isLoaded == false){
				while (UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Question", LoadSceneMode.Additive).isDone){
					yield return null;
				}
				questionedIjin = catchedIjin;
			} else{
				yield break;
			}
			GameObject.Find("LeftButton").GetComponent<BoxCollider2D>().enabled = false;
			GameObject.Find("RightButton").GetComponent<BoxCollider2D>().enabled = false;
		}

		public bool Judge(Answer player_answer){
			isQuestioning = false;
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