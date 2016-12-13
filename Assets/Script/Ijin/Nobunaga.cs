using UnityEngine;
using System.Collections;

namespace Ijin{
	public class Nobunaga : AbstractIjin{
		void Awake(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
			name = "Nobunaga";
			question_name = "question_nobunaga01";
			question_answer = Answer.Correct;
		}

		void Update(){	
			if (Input.GetKeyDown(KeyCode.R)){
				Respone();
			}
		}
	}
}