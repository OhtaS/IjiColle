using UnityEngine;
using System.Collections;

namespace Ijin{
	public class Ryoma : AbstractIjin{
		void Start(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
			name = "Sakamoto Ryoma";
			question_name = "question_mobu01";
			question_answer = Answer.Correct;
		}

		void Update(){	
			if (Input.GetKeyDown(KeyCode.R)){
				Respone();
			}
		}
	}
}
