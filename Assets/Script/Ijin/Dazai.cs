﻿using UnityEngine;
using System.Collections;

namespace Ijin{
	public class Dazai : AbstractIjin{
		void Start(){
			Initialize();
		}

		protected override void Initialize(){
			base.Initialize();
			name = "Dazai Osamu";
		}

		void Update(){	
			if (Input.GetKeyDown(KeyCode.R)){
				Respone();
			}
		}
	}
}