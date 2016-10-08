using UnityEngine;
using System.Collections;
using Common;
using Crane;

namespace Ijin{
	public enum Answer{
		Unanswered,
		Correct,
		Incorrect}
	;

	public abstract class AbstractIjin : MonoBehaviour{
		public string name;
		public string question_name;
		public Answer question_answer;

		protected Vector3 default_position;
		protected SpriteRenderer spriteRenderer;

		protected virtual void Initialize(){
			default_position = transform.position;
			name = "NONAME";
			question_name = "question";
			question_answer = Answer.Unanswered;
		}

		public void Respone(){
			transform.position = default_position;
//			GameObject.Find("/AudioManager").GetComponent<AudioManager>().PlayRespone();
		}

		void OnCollisionStay2D(Collision2D coll){
			if (coll.gameObject.name == "Arm_L" || coll.gameObject.name == "Arm_R"){
				GameObject.Find("Crane").GetComponent<IIjinListener>().CheckTo(this);
			}
		}

		void OnCollisionExit2D(Collision2D coll){
			if (coll.gameObject.name == "Arm_L" || coll.gameObject.name == "Arm_R"){
				GameObject.Find("Crane").GetComponent<IIjinListener>().CheckTo(null);
			}
		}
	}
}