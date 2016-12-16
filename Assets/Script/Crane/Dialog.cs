using UnityEngine;
using System.Collections;

namespace Crane{
	public class Dialog : MonoBehaviour{
		const string imagePath = "Image/Ijin/";
		// Use this for initialization
		void Start(){
			int numberOfCorrect = 0;
			for (int i = 0; i < GameObject.Find("Ochimusha").GetComponent<Navigator.Ochimusha>().correctIjinList.Count; i++){
				string ijinName = GameObject.Find("Ochimusha").GetComponent<Navigator.Ochimusha>().correctIjinList[i];
				transform.GetChild(numberOfCorrect).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + ijinName.ToLower());
			}
		}
	
		// Update is called once per frame
		void Update(){
	
		}
	}
}