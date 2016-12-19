using UnityEngine;
using System.Collections;

namespace Crane{
	public class IncorrectButton : AbstractButton{
		void Start(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
			audioSourceName = "button_click03";
		}

		protected override void ActionByPushed(){
			base.ActionByPushed();
			GameObject.Find("Crane").GetComponent<IButtonListener>().PushedButton(KindOfButton.Incorrect);
		}
	}
}