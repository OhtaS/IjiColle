using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Ijin;

namespace Navigator{
	public class Ochimusha : MonoBehaviour{
		public AbstractIjin catchedIjin;
		AbstractIjin questionedIjin;
		bool isQuestioning;
		List<string> correctIjinList;

		void Start(){
			isQuestioning = false;
			catchedIjin = null;
			correctIjinList = new List<string>();
		}

		void Update(){
	
		}

		public IEnumerator Question(){
			if (isQuestioning){
				yield break;
			}
			isQuestioning = true;
			questionedIjin = catchedIjin;

			yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Question", LoadSceneMode.Additive);

			GameObject.Find("LeftButton").GetComponent<BoxCollider2D>().enabled = false;
			GameObject.Find("RightButton").GetComponent<BoxCollider2D>().enabled = false;
		}

		public bool Judge(Answer player_answer){
			isQuestioning = false;
			if (questionedIjin.question_answer == player_answer){
				AddIjin(questionedIjin.name);
				MoveIjinInHusuma();
				return true;
			} else{
				return false;
			}
		}

		public void AddIjin(string ijinName){
			if (correctIjinList.Exists(x => x.Equals(name)) == false){
				correctIjinList.Add(ijinName);
			}
		}

		public void MoveIjinInHusuma(){
			questionedIjin.transform.localPosition = new Vector3(0.0f, -25f, -3.5f);
			questionedIjin.transform.eulerAngles = new Vector3(0, 0, 0);
		}

		public void ShowGotIjin(){
			questionedIjin.ConvertToPoint();
			questionedIjin.transform.localPosition = new Vector3(0.0f, -25f, -6.0f);
		}

		public void DestroyGotIjin(){
			Destroy(questionedIjin.gameObject);
		}

		public void ResponeIjin(){
			questionedIjin.Respone();
		}

		public void ActionOfPlayerClear(){
			foreach (string correctIjin in correctIjinList){
				GameObject.Find("DataManager").GetComponent<Common.DataManager>().AddIjin(correctIjin);
			}
			GameObject.Find("DataManager").GetComponent<Common.DataManager>().SaveData();
		}
	}
}