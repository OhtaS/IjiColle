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
		public int point;
		public string name;
		public string question_name;
		public Answer question_answer;

		public Vector3 default_position;
		public Vector3 default_rotate;
		protected SpriteRenderer spriteRenderer;

		protected virtual void Initialize(){
			default_position = transform.position;
			point = 100;
			name = "NONAME";
			question_name = "question";
			question_answer = Answer.Unanswered;
		}

		public void ConvertToPoint(){
			GameObject.Find("/Canvas/Score").GetComponent<Score.ScoreManager>().AddScore(point);
			transform.localPosition = new Vector3(0.0f, -9.0f, -0.5f);
        	transform.eulerAngles = new Vector3(0, 0, 0);
		}

		public virtual void Respone(){
			transform.position = default_position;
//			GameObject.Find("/AudioManager").GetComponent<AudioManager>().PlayRespone();
		}

		// void OnCollisionEnter2D(Collision2D coll){
		// 	if (coll.gameObject.name == "Arm_L" || coll.gameObject.name == "Arm_R"){
		// 		GameObject.Find("Crane").GetComponent<IIjinListener>().CheckTo(this);
		// 	}
		// }

		// void OnCollisionExit2D(Collision2D coll){
		// 	if (coll.gameObject.name == "Arm_L" || coll.gameObject.name == "Arm_R"){
		// 		GameObject.Find("Crane").GetComponent<IIjinListener>().CheckTo(null);
		// 	}
		// }
	}
}