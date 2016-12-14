using UnityEngine;
using System.Collections;

namespace Ijin{
	public class Ieyasu : AbstractIjin{
		void Awake(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
			name = "Ieyasu";
			question_name = "question_ieyasu01";
			question_answer = Answer.Incorrect;
		}

		void Update(){	
			if (Input.GetKeyDown(KeyCode.R)){
				Respone();
			}
		}
	}
}