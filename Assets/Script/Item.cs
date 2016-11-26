using UnityEngine;
using System.Collections;
using Common;
using Crane;

namespace Item{
	public class Item : MonoBehaviour{
		public string name;
		public Vector3 default_position;
		public Vector3 default_rotate;
		protected SpriteRenderer spriteRenderer;

		protected void Initialize(){
			default_position = transform.position;
			name = "NONAME";
			this.tag = "Item";
		}

		public void Respone(){
			transform.position = default_position;
//			GameObject.Find("/AudioManager").GetComponent<AudioManager>().PlayRespone();
		}

		void OnCollisionEnter2D(Collision2D coll){
			if (coll.gameObject.name == "Arm_L" || coll.gameObject.name == "Arm_R"){
				this.tag = "CatchedItem";
			}
		}

		void OnCollisionExit2D(Collision2D coll){
			if (coll.gameObject.name == "Arm_L" || coll.gameObject.name == "Arm_R"){
				this.tag = "Item";
			}
		}
	}
}