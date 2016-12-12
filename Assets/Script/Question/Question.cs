using UnityEngine;
using System.Collections;
using Navigator;

public class Question : MonoBehaviour{

	// Use this for initialization
	void Start(){
		SetQuestion(GameObject.Find("/Object/Ochimusha").GetComponent<Ochimusha>().catchedIjin.question_name);
	}
	
	// Update is called once per frame
	void Update(){
	}

	public void SetQuestion(string question_name){
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Question/" + question_name);
	}
}
