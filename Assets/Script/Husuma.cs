using UnityEngine;
using System.Collections;

public class Husuma : MonoBehaviour {
	GameObject husuma_L;
	GameObject husuma_R;
	Vector3 default_position_L;
	Vector3 default_position_R;
	bool isMoving;

	void Start () {
		husuma_L = transform.FindChild ("Husuma_L").gameObject;
		husuma_R = transform.FindChild ("Husuma_R").gameObject;
		default_position_L = husuma_L.transform.position;
		default_position_R = husuma_R.transform.position;
		isMoving = false;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.O)){
			StartCoroutine(OpenHusuma());
		}else if(Input.GetKeyDown(KeyCode.C)){
			CloseHusuma();
		}
	}

	public IEnumerator OpenHusuma(){
		if (isMoving){
			yield break;
		}

		isMoving = true;
		while (husuma_L.transform.position.x >= -0.5){
			husuma_L.transform.position = new Vector3(husuma_L.transform.position.x - 0.05f, husuma_L.transform.position.y, husuma_L.transform.position.z);
			husuma_R.transform.position = new Vector3(husuma_R.transform.position.x + 0.05f, husuma_R.transform.position.y, husuma_R.transform.position.z);
			yield return null;
		}
		isMoving = false;
	}

	public void CloseHusuma(){
		husuma_L.transform.position = default_position_L;
		husuma_R.transform.position = default_position_R;
	}
}
