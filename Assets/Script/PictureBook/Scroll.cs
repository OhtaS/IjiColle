using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour{
	Vector3 mapHalfSize;
	private Vector3 screenPoint;
	private Vector3 offset;

	void Start(){
		mapHalfSize = gameObject.GetComponent<SpriteRenderer>().bounds.extents;	
	}

	void SetMousePosition(){
		this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
		                                                                              Input.mousePosition.y,
		                                                                              screenPoint.z));
	}

	void MoveX(){
		Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
		if (Camera.main.ViewportToWorldPoint(Vector3.zero).x >= transform.position.x - mapHalfSize.x
		    || Camera.main.ViewportToWorldPoint(Vector3.one).x <= transform.position.x + mapHalfSize.x){
			transform.position = new Vector3(currentPosition.x, transform.position.y, transform.position.z);
		}
		if (Camera.main.ViewportToWorldPoint(Vector3.zero).x < transform.position.x - mapHalfSize.x){
			transform.position = new Vector3(Camera.main.ViewportToWorldPoint(Vector3.zero).x + mapHalfSize.x,
			                                 transform.position.y,
			                                 transform.position.z);
		} else if (Camera.main.ViewportToWorldPoint(Vector3.one).x > transform.position.x + mapHalfSize.x){
			transform.position = new Vector3(Camera.main.ViewportToWorldPoint(Vector3.one).x - mapHalfSize.x,
			                                 transform.position.y,
			                                 transform.position.z);
		}
	}

	void MoveY(){
		Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
		if (Camera.main.ViewportToWorldPoint(Vector3.zero).y >= transform.position.y - mapHalfSize.y
		    || Camera.main.ViewportToWorldPoint(Vector3.one).y <= transform.position.y + mapHalfSize.y){
			transform.position = new Vector3(transform.position.x, currentPosition.y, transform.position.z);
		}
		if (Camera.main.ViewportToWorldPoint(Vector3.zero).y < transform.position.y - mapHalfSize.y){
			transform.position = new Vector3(transform.position.x,
			                                 Camera.main.ViewportToWorldPoint(Vector3.zero).y + mapHalfSize.y,
			                                 transform.position.z);
		} else if (Camera.main.ViewportToWorldPoint(Vector3.one).y > transform.position.y + mapHalfSize.y){
			transform.position = new Vector3(transform.position.x,
			                                 Camera.main.ViewportToWorldPoint(Vector3.one).y - mapHalfSize.y,
			                                 transform.position.z);
		}
	}

	void OnMouseDown(){
		SetMousePosition();
	}

	void OnMouseDrag(){
		MoveY();
	}
}
