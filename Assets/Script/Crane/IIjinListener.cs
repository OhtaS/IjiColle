using UnityEngine;
using System.Collections;
using Ijin;

namespace Crane{
	public interface IIjinListener{
		void CheckTo(AbstractIjin ijin);
	}
}