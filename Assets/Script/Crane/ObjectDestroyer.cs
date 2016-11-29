using UnityEngine;
using System.Collections;
using Item;

namespace Crane{
	public class ObjectDestroyer : MonoBehaviour {
		public void ObstacleDestroy() {
			GameObject[] obstacles = GameObject.FindGameObjectsWithTag("CatchedItem");
			foreach(GameObject obs in obstacles) {
				StartCoroutine("DestroyItem", obs);
			}
		}

		public IEnumerator DestroyItem(GameObject obs){
			obs.GetComponent<ItemManager>().ChangeAfterglow();
			yield return new WaitForSeconds(0.5f);
			Destroy(obs);
		}
	}
}
