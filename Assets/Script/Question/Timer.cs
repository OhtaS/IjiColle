using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	private float time = 6;
	private bool isPlaying = false;
	
	void Start () {
		GetComponent<Text>().text = "時間";
	}
	
	void Update (){
		if (Input.GetKeyDown(KeyCode.S)){
			isPlaying = true;
		}
		if(isPlaying == true){
			CountTime();
		}
	}

	void CountTime(){
		GetComponent<Text>().text = ((int)time).ToString ();
		time -= Time.deltaTime;

		if (time <= 1) {
			GetComponent<Text>().text = "終了！";
			isPlaying = false;
		}
	}
}