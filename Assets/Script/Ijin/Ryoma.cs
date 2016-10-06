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
		}

		void Update(){	
			if (Input.GetKeyDown(KeyCode.R)){
				Respone();
			}
		}
	}
}
