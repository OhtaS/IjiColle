using UnityEngine;
using System.Collections;
using Common;
using Crane;
using Score;


namespace Item{
	public class ItemManager : MonoBehaviour{
		public int point;
		public string name;
		public Vector3 default_position;
		public Vector3 default_rotate;
		public Texture2D texture;
		protected SpriteRenderer spriteRenderer;

		void Start(){
			spriteRenderer = GetComponent<SpriteRenderer>();
			texture = Resources.Load<Texture2D>("Image/Item/star");
			default_position = transform.position;
			name = "NONAME";
			this.tag = "Item";
			point = 10;
		}

		public void Respone(){
			transform.position = default_position;
//			GameObject.Find("/AudioManager").GetComponent<AudioManager>().PlayRespone();
		}

		public void ChangeAfterglow(){
			this.tag = "Item";
			spriteRenderer.sprite = SpriteManager.GetSprite(texture);
			Destroy(this.GetComponent<Rigidbody2D>());
			Destroy(this.GetComponent<CircleCollider2D>());
			GameObject.Find("/Canvas/Score").GetComponent<ScoreManager>().AddScore(point);
		}

		// void OnCollisionEnter2D(Collision2D coll){
		// 	if (coll.gameObject.name == "Arm_L" || coll.gameObject.name == "Arm_R"){
		// 		this.tag = "CatchedItem";
		// 	}
		// }

		// void OnCollisionExit2D(Collision2D coll){
		// 	if (coll.gameObject.name == "Arm_L" || coll.gameObject.name == "Arm_R"){
		// 		this.tag = "Item";
		// 	}
		// }
	}
}