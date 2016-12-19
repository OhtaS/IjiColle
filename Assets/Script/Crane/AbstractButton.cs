using UnityEngine;
using System.Collections;

public abstract class AbstractButton : MonoBehaviour{
	protected Color defaultColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	protected Color pushedColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	protected string audioSourceName = "button_click01";

	protected virtual void Initialize(){
		
	}

	protected virtual void ActionByPushed(){

	}

	protected virtual void OnMouseDown(){
		if (GameObject.Find("AudioManager")){
			GameObject.Find("AudioManager").GetComponent<Common.AudioManager>().PlayOnShot(audioSourceName);
		}
		GetComponent<SpriteRenderer>().color = pushedColor;
	}

	protected virtual void OnMouseUp(){
		GetComponent<SpriteRenderer>().color = defaultColor;
	}

	protected virtual void OnMouseUpAsButton(){
		GetComponent<SpriteRenderer>().color = defaultColor;
		ActionByPushed();
	}
}
