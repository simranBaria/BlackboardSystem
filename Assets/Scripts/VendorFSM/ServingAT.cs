using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ServingAT : ActionTask {
		public BBParameter<int> servedFlavour;
		public BBParameter<GameObject> customer;
		private Blackboard customerBlackboard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			// Get the customer blackbaord
			customerBlackboard = customer.value.GetComponent<Blackboard>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            customerBlackboard.SetVariableValue("served", true);

			// Text output
			string flavour = "nothing";
			switch (servedFlavour.value)
			{
				case 1:
					flavour = "vanilla";
					break;
				case 2:
					flavour = "chocolate";
					break;
				case 3:
					flavour = "strawberry";
					break;
			}

			// Text output
			Debug.Log($"Vendor: Here is some {flavour} ice cream!");
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