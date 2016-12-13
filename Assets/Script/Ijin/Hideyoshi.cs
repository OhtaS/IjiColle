using UnityEngine;
using System.Collections;

namespace Ijin{
	public class Hideyoshi : AbstractIjin{
		void Awake(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
			name = "Hideyoshi";
			question_name = "question_hideyoshi01";
			question_answer = Answer.Correct;
		}

		void Update(){	
			if (Input.GetKeyDown(KeyCode.R)){
				Respone();
			}
		}
	}
}