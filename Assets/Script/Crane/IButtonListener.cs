using UnityEngine;
using System.Collections;

namespace Crane{
	public interface IButtonListener{
		void PushedButton(KindOfButton kind);

		void ReleaseButton();
	}
}