using UnityEngine;
using System.Collections;

namespace Crane{
	public enum KindOfButton{
		Empty,
		Left,
		Right,
		Correct,
		Incorrect}

	;

	public class ButtonCraneAdapter : MonoBehaviour,IButtonListener{
		public void PushedButton(KindOfButton kind){
			switch(kind){
				case KindOfButton.Left:
					gameObject.GetComponent<Crane>().state = State.MoveLeft;
				break;

				case KindOfButton.Right:
					gameObject.GetComponent<Crane>().state = State.MoveRight;
				break;

				case KindOfButton.Correct:
					gameObject.GetComponent<Crane>().state = State.MoveCorrect;

				break;

				case KindOfButton.Incorrect:
					gameObject.GetComponent<Crane>().state = State.MoveIncorrect;

				break;
			}
		}

		public void ReleaseButton(){
			gameObject.GetComponent<Crane>().state = State.Stop;
		}
	}
}