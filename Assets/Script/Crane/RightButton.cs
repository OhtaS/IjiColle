using UnityEngine;
using System.Collections;
using Crane;

public class RightButton : AbstractButton{
	void Start(){
		Initialize();
	}

	protected override void Initialize(){
		base.Initialize();
		audioSourceName = "button_click03";
	}

	protected override void OnMouseDown(){
		base.OnMouseDown();
		GameObject.Find("Crane").GetComponent<IButtonListener>().PushedButton(KindOfButton.Right);
	}

	protected override void OnMouseUp(){
		base.OnMouseUp();
		GameObject.Find("Crane").GetComponent<IButtonListener>().ReleaseButton();
	}

	protected override void OnMouseUpAsButton(){
		base.OnMouseUpAsButton();
		GameObject.Find("Crane").GetComponent<IButtonListener>().ReleaseButton();
	}
}
