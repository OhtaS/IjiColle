using UnityEngine;
using System.Collections;

namespace SelectStand{
	public class DecisionButton : AbstractButton{
		protected override void ActionByPushed(){
			StartCoroutine(Common.MySceneManager.LoadScene("MultipleChoice2"));
		}
	}
}
