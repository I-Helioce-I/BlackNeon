using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
        public bool addAction;
        public bool substractAction;
        public bool multiplyAction;
        public bool divideAction;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAddAction(InputValue value)
		{
			AddActionInput(value.isPressed);
		}

        public void OnSubstractAction(InputValue value)
        {
            SubstractActionInput(value.isPressed);
        }

        public void OnMultiplyAction(InputValue value)
        {
            MultiplyActionInput(value.isPressed);
        }

        public void OnDivideAction(InputValue value)
        {
            DivideActionInput(value.isPressed);
        }


#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void AddActionInput(bool newAddActionState)
		{
			addAction = newAddActionState;
		}

        public void SubstractActionInput(bool newSubstractActionState)
        {
            substractAction = newSubstractActionState;
        }

        public void MultiplyActionInput(bool newMultiplyActionState)
        {
            multiplyAction = newMultiplyActionState;
        }

        public void DivideActionInput(bool newDivideActionState)
        {
            divideAction = newDivideActionState;
        }

		

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}