using UnityEngine;
using System.Collections;
using Ijin;
using Navigator;

namespace Crane{
	public class IjinCraneAdapter : MonoBehaviour, IIjinListener{
		public void CheckTo(AbstractIjin ijin){
			if (ijin == null){
				gameObject.GetComponent<Crane>().isCatched = false;
			} else{
				gameObject.GetComponent<Crane>().isCatched = true;
			}
			GameObject.Find("Ochimusha").GetComponent<Ochimusha>().catchedIjin = ijin;
		}
	}
}