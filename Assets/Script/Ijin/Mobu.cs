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
		}

		void Update(){	
			if (Input.GetKeyDown(KeyCode.R)){
				Respone();
			}
		}
	}
}