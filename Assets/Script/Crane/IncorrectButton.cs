using UnityEngine;
using System.Collections;

namespace Crane{
	public class IncorrectButton : AbstractButton{
		void Start(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
		}

		protected override void ActionByPushed(){
			base.ActionByPushed();
			GameObject.Find("Crane").GetComponent<CraneStateMachine>().player_answer = Ijin.Answer.Incorrect;
		}
	}
}