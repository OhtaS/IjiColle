using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	Vector3 default_position;
	bool isMoving;

	void Start () {
		default_position = transform.position;
		isMoving = false;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			ZoomOut();
		}else if (Input.GetKeyDown(KeyCode.DownArrow)){
			StartCoroutine(ZoomInHusuma());
		}
	}

	public IEnumerator ZoomInHusuma(){
		if (isMoving){
			yield break;
		}

		isMoving = true;
	    yield return new WaitForSeconds(1.0f);

		while (transform.position.y >= -0.5){
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
			GetComponent<Camera>().orthographicSize -= 0.07f;
			yield return null;
		}

		isMoving = false;
	}

	public void ZoomOut(){
		transform.position = default_position;
		GetComponent<Camera>().orthographicSize = 3.0f;
	}
}
