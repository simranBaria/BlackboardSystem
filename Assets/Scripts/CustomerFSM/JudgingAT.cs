using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class JudgingAT : ActionTask {
		public BBParameter<int> customerFlavour;
		public BBParameter<bool> correctlyServed, served;
		public BBParameter<GameObject> vendor;
		private Blackboard vendorBlackboard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			// Get the vendor blackbaord
			vendorBlackboard = vendor.value.GetComponent<Blackboard>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			served.value = false;

			if (vendorBlackboard.GetVariableValue<int>("flavour") == customerFlavour.value)
			{
				correctlyServed.value = true;
				vendorBlackboard.SetVariableValue("correctlyServed", true);
			}

			// Text output
			Debug.Log("Customer: Hmm...");
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}