using System.Collections;
using UnityEngine;

namespace BzKovSoft.ObjectSlicer.EventHandlers
{
	/// <summary>
	/// Reaplying velocity and angularVelocity from the original
	/// </summary>
	[DisallowMultipleComponent]
	class BzReaplyForce : MonoBehaviour, IBzObjectSlicedEvent
	{
		[SerializeField] private float forceImpact;  

		void Awake(){
				forceImpact = 2;
		}

		public void ObjectSliced(GameObject original, GameObject resultNeg, GameObject resultPos)
		{
			// we need to wait one fram to allow destroyed component to be destroyed.
			StartCoroutine(NextFrame(original, resultNeg, resultPos));
		}

		private IEnumerator NextFrame(GameObject original, GameObject resultNeg, GameObject resultPos)
		{
			yield return null;

			var oRigid = original.GetComponent<Rigidbody>();
			var aRigid = resultNeg.GetComponent<Rigidbody>();
			var bRigid = resultPos.GetComponent<Rigidbody>();

			if (oRigid == null)
				yield break;

			aRigid.angularVelocity = oRigid.angularVelocity * forceImpact;
			bRigid.angularVelocity = oRigid.angularVelocity * forceImpact;
			aRigid.velocity = oRigid.velocity * forceImpact;
			bRigid.velocity = oRigid.velocity * forceImpact;
		}
	}
}
