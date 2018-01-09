// author zhizhen
// date 2018/01/08
// email zhzhzhen@gmail.com

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
	#region Members

	public Sprite upSprite;
	public Color upColor;

	public Sprite downSprite;
	public Color downColor;

	int mPointerId;

	enum State
	{
		Up,
		Down

	}

	State mState;

//	RPGCharacterController mTarget;

	#endregion

	#region MonoBehaviour

	void Start ()
	{
		mPointerId = -1;
		mState = State.Up;
//		mTarget = null;
	}

	void Update ()
	{
		StartCoroutine (UpdateButton ());
	}

	IEnumerator UpdateButton ()
	{
		yield return new WaitForEndOfFrame ();

		// unity axes
		if (Input.GetButton (name)) {
			if (mState != State.Down) {
				mState = State.Down;
				ActionControl (mState);
			}
		} else {
			if (mState != State.Up) {
				mState = State.Up;
				ActionControl (mState);
			}
		}
	}

	void ActionControl (State state)
	{
//		if (mTarget == null) {
//			GameObject go = GameObject.FindGameObjectWithTag ("RPG-Character");
//			if (go != null) {
//				mTarget = go.GetComponent<RPGCharacterController> ();
//			}
//		}
//		if (mTarget != null) {
//			if (name == "Jump") {
//				if (state == State.Down) {
//					//						mTarget.inputJump = True;
//				}
//			} else if (name == "Attack") {
//				if (state == State.Down) {
//					//                        mTarget.TestAction();
//				}
//			} else if (name == "Switch") {
//				if (state == State.Down) {
//					//                        mTarget.Switch();
//				}
//			} else {
//				Debug.Assert (false);
//			}
//		}
	}

	#endregion

	#region Pointer Handlers

	public void OnPointerEnter (PointerEventData eventData)
	{
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		mPointerId = eventData.pointerId;
		if (mState != State.Down) {
			mState = State.Down;
			ActionControl (mState);
		}
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		if (mPointerId == eventData.pointerId) {
			if (mState != State.Up) {
				mState = State.Up;
				ActionControl (mState);
			}
		}
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (mPointerId == eventData.pointerId) {
			if (mState != State.Up) {
				mState = State.Up;
				ActionControl (mState);
			}
		}
	}

	#endregion
}
