using UnityEngine;
using System.Collections;

namespace Crane{
	public class CorrectButton : AbstractButton{
		void Start(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
		}

		protected override void ActionByPushed(){
			base.ActionByPushed();
			GameObject.Find("Crane").GetComponent<IButtonListener>().PushedButton(KindOfButton.Correct);
		}
	}
}