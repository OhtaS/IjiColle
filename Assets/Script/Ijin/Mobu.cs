using UnityEngine;
using System.Collections;

namespace Ijin{
	public class Mobu : AbstractIjin{
		void Start(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
			name = "Mobu";
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