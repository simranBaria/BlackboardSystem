using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class WaitingAT : ActionTask {
		public BBParameter<int> customerFlavour;
		public BBParameter<bool> correctlyServed;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// Pick a new flavour if served correctly
			if (correctlyServed.value)
			{
				customerFlavour.value = Random.Range(1, 4);
				correctlyServed.value = false;
			}

			// Text output
			string flavour = "nothing";
			switch(customerFlavour.value)
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
			Debug.Log($"Customer: I would like {flavour}, please.");
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