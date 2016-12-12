using UnityEngine;
using System.Collections;

namespace Ijin{
	public class Ryoma : AbstractIjin{
		void Awake(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
			point = 40;
			name = "Sakamoto Ryoma";
			question_name = "question_ryoma01";
			question_answer = Answer.Incorrect;
		}

		void Update(){
			if (Input.GetKeyDown(KeyCode.R)){
				Respone();
			}
		}
	}
}
