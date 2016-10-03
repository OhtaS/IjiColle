using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Crane
{
	public enum State {Ready, MoveX, Opening, Opened, Closing, Closed, WaitingJudgement, Return};
	public enum AnswerState {Unanswered, Correct, Incorrect};
	public enum ButtonState {Neutral, Left, Right, Up};	

	public class Crane : MonoBehaviour
	{
		Transform arm_l;
		Transform arm_r;
		Vector3 open_angle_l;
		Vector3 open_angle_r;
		Vector3 close_angle_l;
		Vector3 close_angle_r;
		Vector3 default_position;
		public static State state;
		public static AnswerState answerState;
		public static ButtonState buttonState;
		public static bool isCatched;

		void Start ()
		{
			state = State.Ready;
			answerState = AnswerState.Unanswered;
			buttonState = ButtonState.Neutral;
			isCatched = false;
			default_position = transform.position;
			arm_l = transform.GetChild (0);
			open_angle_l = new Vector3(arm_l.eulerAngles.x, arm_l.eulerAngles.y, arm_l.eulerAngles.z+40);
			arm_r = transform.GetChild (1);
			open_angle_r = new Vector3(arm_r.eulerAngles.x, arm_r.eulerAngles.y, arm_r.eulerAngles.z+40);
			close_angle_l = arm_l.eulerAngles;
			close_angle_r = arm_r.eulerAngles;
		}

		void Update ()
		{
			Debug.Log(buttonState);

			if (SceneManager.GetActiveScene().name == "MultipleChoice"){
				PlayMultipleChoice();
			}
			else{
				PlayDefoultCraneGame();	
			}
		}

		void PlayDefoultCraneGame ()
		{
			if(Input.GetKeyUp (KeyCode.RightArrow)){
				state = State.Opening;
			}else if (Input.GetKey (KeyCode.RightArrow) && state == State.Ready) {
				transform.position = new Vector3 (transform.position.x+0.01f, transform.position.y, transform.position.z);
			}
			if (Input.GetKey (KeyCode.Space) && state == State.MoveX) {
				state = State.Opening;
			}

			switch (state) {
				case State.Ready:
				if (Mathf.Abs (Mathf.DeltaAngle (arm_l.eulerAngles.z, close_angle_l.z)) < 0.1f && Mathf.Abs (Mathf.DeltaAngle (arm_r.eulerAngles.z, close_angle_r.z)) < 0.1f) {
				} else {
					arm_l.Rotate (0f, 0f, -1f);
					arm_r.Rotate (0f, 0f, -1f);
				}
				break;

				case State.Opening:
				if (Mathf.DeltaAngle (arm_l.eulerAngles.z, open_angle_l.z) < 0.1f && Mathf.DeltaAngle (arm_r.eulerAngles.z, open_angle_r.z) < 0.1f) {
					state = State.Opened;
				} else {
					arm_l.Rotate (0f, 0f, 1f);
					arm_r.Rotate (0f, 0f, 1f);
				}
				break;

				case State.Opened:
				if (transform.position.y >= default_position.y - 0.4f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - 0.01f, transform.position.z);
				} else {
					state = State.Closing;
				}
				break;

				case State.Closing:
				if (Mathf.Abs (Mathf.DeltaAngle (arm_l.eulerAngles.z, close_angle_l.z)) < 0.1f && Mathf.Abs (Mathf.DeltaAngle (arm_r.eulerAngles.z, close_angle_r.z)) < 0.1f) {
					state = State.Closed;
				} else {
					arm_l.Rotate (0f, 0f, -1f);
					arm_r.Rotate (0f, 0f, -1f);
				}
				break;

				case State.Closed:
				if (transform.position.y >= default_position.y) {
					state = State.Return;
				} else {
					transform.position = new Vector3 (transform.position.x, transform.position.y + 0.01f, transform.position.z);
				}
				break;

				case State.Return:
				if (transform.position.x > default_position.x) {
					transform.position = new Vector3 (transform.position.x - 0.01f, transform.position.y, transform.position.z);
				}else{
					arm_l.Rotate (0f, 0f, 1f);
					arm_r.Rotate (0f, 0f, 1f);
					if (Mathf.DeltaAngle (arm_l.eulerAngles.z, open_angle_l.z) < 0.1f && Mathf.DeltaAngle (arm_r.eulerAngles.z, open_angle_r.z) < 0.1f) {
						state = State.Ready;
					}
				}
				break;
			}
		}

		void PlayMultipleChoice ()
		{
			if(buttonState == ButtonState.Up){
				state = State.Opening;
				buttonState = ButtonState.Neutral;
			}else if (buttonState == ButtonState.Left && state == State.Ready) {
				transform.position = new Vector3 (transform.position.x-0.01f, transform.position.y, transform.position.z);
			}else if (buttonState == ButtonState.Right && state == State.Ready) {
				transform.position = new Vector3 (transform.position.x+0.01f, transform.position.y, transform.position.z);
			}
			
			if (Input.GetKey (KeyCode.Space) && state == State.MoveX) {
				state = State.Opening;
			}

			switch (state) {
				case State.Ready:
				if (Mathf.Abs (Mathf.DeltaAngle (arm_l.eulerAngles.z, close_angle_l.z)) < 0.1f && Mathf.Abs (Mathf.DeltaAngle (arm_r.eulerAngles.z, close_angle_r.z)) < 0.1f) {
				} else {
					arm_l.Rotate (0f, 0f, -1f);
					arm_r.Rotate (0f, 0f, -1f);
				}
				break;

				case State.Opening:
				OpenArms (State.Opened);
				break;

				case State.Opened:
				if (transform.position.y >= default_position.y - 0.4f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - 0.01f, transform.position.z);
				} else {
					state = State.Closing;
				}
				break;

				case State.Closing:
				if (Mathf.Abs (Mathf.DeltaAngle (arm_l.eulerAngles.z, close_angle_l.z)) < 0.1f && Mathf.Abs (Mathf.DeltaAngle (arm_r.eulerAngles.z, close_angle_r.z)) < 0.1f) {
					state = State.Closed;
				} else {
					arm_l.Rotate (0f, 0f, -1f);
					arm_r.Rotate (0f, 0f, -1f);
				}
				break;

				case State.Closed:
				if (transform.position.y >= default_position.y) {
					if(isCatched == true){
						state = State.WaitingJudgement;
					}else{
						state = State.Return;
					}				
				} else {
					transform.position = new Vector3 (transform.position.x, transform.position.y + 0.01f, transform.position.z);
				}
				break;

				case State.WaitingJudgement:
				
				break;

				case State.Return:
				if (transform.position.x - default_position.x > 0.01) {
					transform.position = new Vector3 (transform.position.x - 0.01f, transform.position.y, transform.position.z);
				}else if (transform.position.x - default_position.x < -0.01) {
					transform.position = new Vector3 (transform.position.x + 0.01f, transform.position.y, transform.position.z);
				}else{
					OpenArms (State.Ready);
				}
				break;
			}
		}

		void OpenArms(State next_state){
			if (Mathf.DeltaAngle (arm_l.eulerAngles.z, open_angle_l.z) < 0.1f && Mathf.DeltaAngle (arm_r.eulerAngles.z, open_angle_r.z) < 0.1f) {
				state = next_state;
			} else {
				arm_l.Rotate (0f, 0f, 1f);
				arm_r.Rotate (0f, 0f, 1f);
			}
		}
	}
}