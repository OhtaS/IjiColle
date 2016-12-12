using UnityEngine;
using System;
using UnityEngine.UI;

namespace Score{
	public class ScoreManager : MonoBehaviour{
		public int score;

		void Start(){
			score = 0;
			GetComponent<Text>().text = score.ToString();
		}

		public void AddScore(){
			score += 10;
			GetComponent<Text>().text = score.ToString();
		}

		public void AddScore(int point){
			score += point;
			GetComponent<Text>().text = score.ToString();
		}
	}
}
