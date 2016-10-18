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
