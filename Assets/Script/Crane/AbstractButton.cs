using UnityEngine;
using System.Collections;

public abstract class AbstractButton : MonoBehaviour{
	protected Color defaultColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	protected Color pushedColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);

	protected virtual void Initialize(){
		
	}

	protected virtual void ActionByPushed(){

	}

	protected virtual void OnMouseDown(){
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
