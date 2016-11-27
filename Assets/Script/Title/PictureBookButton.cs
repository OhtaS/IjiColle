using UnityEngine;
using System.Collections;

namespace Title{
	public class PictureBookButton : AbstractButton{
		protected override void ActionByPushed(){
			StartCoroutine(Common.MySceneManager.LoadScene("PictureBook"));
		}
	}
}