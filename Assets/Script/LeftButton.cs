using UnityEngine;
using System.Collections;
using Crane;

public class LeftButton : AbstractButton {
	void Start () {
		Initialize ();
	}
	
	protected override void Initialize(){
		base.Initialize ();
	}

	protected override void ActionByPushed(){
		base.ActionByPushed ();
	}

	protected virtual void OnMouseDown(){
		base.OnMouseDown ();
		Crane.Crane.buttonState = ButtonState.Left;
	}
	
	protected virtual void OnMouseUp(){
		base.OnMouseUp ();
		Crane.Crane.buttonState = ButtonState.Up;
	}
	
	protected virtual void OnMouseUpAsButton(){
		base.OnMouseUpAsButton ();
		Crane.Crane.buttonState = ButtonState.Up;
	}
}
