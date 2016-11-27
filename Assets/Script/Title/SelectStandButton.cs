using UnityEngine;
using System.Collections;

namespace Title{
	public class SelectStandButton : AbstractButton{
		protected override void ActionByPushed(){
			StartCoroutine(Common.MySceneManager.LoadScene("SelectStand"));
		}
	}
}