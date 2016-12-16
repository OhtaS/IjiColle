using UnityEngine;
using System.Collections;

namespace Crane{
	public class Dialog : MonoBehaviour{
		const string imagePath = "Image/Ijin/";
		// Use this for initialization
		void Start(){
			int numberOfCorrect = 0;
			foreach (string ijinName in GameObject.Find("Ochimusha").GetComponent<Navigator.Ochimusha>().correctIjinList){
				transform.GetChild(numberOfCorrect).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + ijinName.ToLower());
				Debug.Log(transform.GetChild(numberOfCorrect).name);
				numberOfCorrect++;
			}
		}
	
		// Update is called once per frame
		void Update(){
	
		}
	}
}