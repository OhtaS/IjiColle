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
				if (count < 2){
					Respone();
				} else{
					GameObject.Find("Ryoma").transform.position = default_position;
					GameObject.Find("Ryoma").GetComponent<Ryoma>().default_position = default_position;
					Destroy(gameObject);
				}
			}
		}

		public override void Respone(){
			count++;
			if (count < 2){
				transform.position = default_position;
//				Respone();
			} else{
				GameObject.Find("Ryoma").transform.position = default_position;
				GameObject.Find("Ryoma").GetComponent<Ryoma>().default_position = default_position;
				Destroy(gameObject);
			}
		}
	}
}