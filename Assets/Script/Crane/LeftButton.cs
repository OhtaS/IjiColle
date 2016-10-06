using UnityEngine;
using System.Collections;
using Crane;

public class LeftButton : AbstractButton{

	void Start(){
		Initialize();
	}

	protected override void Initialize(){
		base.Initialize();
	}

	protected override void ActionByPushed(){
		base.ActionByPushed();
	}

	protected override void OnMouseDown(){
		base.OnMouseDown();
		GameObject.Find("Crane").GetComponent<IButtonListener>().PushedButton(ButtonState.Left);
	}

	protected override void OnMouseUp(){
		base.OnMouseUp();
		GameObject.Find("Crane").GetComponent<IButtonListener>().PushedButton(ButtonState.Up);
	}

	protected override void OnMouseUpAsButton(){
		base.OnMouseUpAsButton();
		GameObject.Find("Crane").GetComponent<IButtonListener>().PushedButton(ButtonState.Up);
	}
}
