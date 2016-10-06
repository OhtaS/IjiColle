using UnityEngine;
using System.Collections;
using Common;
using Crane;

namespace Ijin{
	public abstract class AbstractIjin : MonoBehaviour{
		public string name;
		protected Vector3 default_position;
		protected SpriteRenderer spriteRenderer;

		protected virtual void Initialize(){
			default_position = transform.position;
			name = "NONAME";
		}

		protected void Respone(){
			transform.position = default_position;
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayRespone();
		}

		void OnTriggerStay2D(Collider2D collider){
			if (collider.name == "Arm_L" || collider.name == "Arm_R"){
				GameObject.Find("Crane").GetComponent<IIjinListener>().CheckTo(this);
			}
		}

		void OnTriggerExit2D(Collider2D collider){
			if (collider.name == "Arm_L" || collider.name == "Arm_R"){
				GameObject.Find("Crane").GetComponent<IIjinListener>().CheckTo(null);
			}
		}
	}
}