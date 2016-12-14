using UnityEngine;
using System.Collections;

namespace SelectStand{
	public class DecisionButton : AbstractButton{
		public string stand = "Adutimomoyama";

		protected override void ActionByPushed(){
			if (gameObject.name == "SelectEdoButton"){
				stand = "Edo";
			}else if (gameObject.name == "SelectAdutimomoyamaButton"){
				stand = "Adutimomoyama";
			}else if (gameObject.name == "Button_replay"){
				stand = "Replay"; 
			}
			StartCoroutine(Common.MySceneManager.LoadStandScene(stand));
		}
	}
}
