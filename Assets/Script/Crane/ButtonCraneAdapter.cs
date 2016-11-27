using UnityEngine;
using System.Collections;

namespace Crane{
	public enum ButtonState{
		Neutral,
		Left,
		Right,
		Up}
	;

	public class ButtonCraneAdapter : MonoBehaviour,IButtonListener{
		Coroutine coroutine;

		public void PushedButton(ButtonState state){
			switch(state){
				case ButtonState.Left:
					coroutine = StartCoroutine(gameObject.GetComponent<Crane>().MoveLeft());
				break;

				case ButtonState.Right:
					coroutine = StartCoroutine(gameObject.GetComponent<Crane>().MoveRight());
				break;

				case ButtonState.Up:
					if (coroutine != null){
						StopCoroutine(coroutine);
						gameObject.GetComponent<Crane>().StopMovement();
					}
				break;
			}
		}

		public void ReleaseButton(){

		}
	}
}