using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	Vector3 default_position;
	bool isMoving;

	void Start () {
		default_position = transform.position;
		Debug.Log(default_position);
		isMoving = false;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			transform.position = default_position;
			GetComponent<Camera>().orthographicSize = 3.0f;
		}else if (Input.GetKeyDown(KeyCode.DownArrow)){
			StartCoroutine(ZoomInHusuma());
		}
	}

	IEnumerator ZoomInHusuma(){
		if (isMoving){
			yield break;
		}

		isMoving = true;
		while (transform.position.y >= -0.5){
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
			GetComponent<Camera>().orthographicSize -= 0.07f;
			yield return null;
		}
		isMoving = false;
	}
}
