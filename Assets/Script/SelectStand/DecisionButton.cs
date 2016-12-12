using UnityEngine;
using System.Collections;

namespace SelectStand{
	public class DecisionButton : AbstractButton{
		public string stand = "MultipleChoice2";

		protected override void ActionByPushed(){
			if (gameObject.name == "SelectEdoButton"){
				stand = "Edo";
			}else if (gameObject.name == "SelectAzutimomoyamaButton"){
				stand = "MultipleChoice2";
			}else if (gameObject.name == "Button_replay"){
				stand = "Replay"; 
			}
			StartCoroutine(Common.MySceneManager.LoadStandScene(stand));
		}
	}
}
