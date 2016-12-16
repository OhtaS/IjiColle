using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PictureBook{
	public class PictureBook : MonoBehaviour{
		const string imagePath = "Image/Ijin/";

		// Use this for initialization
		void Start(){
			foreach (string ijinName in GameObject.Find("DataManager").GetComponent<Common.SaveDataManager>().SavedIjinList){
				Debug.Log(ijinName.ToLower());
				GameObject.Find("Ijins" + ijinName).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + ijinName.ToLower());
			}
		}
	
		// Update is called once per frame
		void Update(){
	
		}
	}
}