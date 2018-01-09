// author zhizhen
// date 2018/01/08
// email zhzhzhen@gmail.com

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	#region Members

	int mPointerId;
	float mRadius;
	RectTransform mThumbRectTransform;
	Vector2 mBakPos;
	Vector2 mThumbPos;

	// move control
	AnimationCurve mMoveCurve;
	Vector2 mMoveVec;
//	RPGCharacterController mTarget;

	#endregion

	#region MonoBehaviour

	void Start ()
	{
		mPointerId = -1;
		mRadius = (transform.Find ("background") as RectTransform).sizeDelta.x * 0.5f - 10.0f;
		mThumbRectTransform = transform.Find ("thumb").GetComponent<RectTransform> ();
		mBakPos = (transform as RectTransform).position;
//
//		mMoveCurve = AnimationCurve.EaseInOut (0.0f, 0.0f, 1.0f, 1.0f);
//		mMoveCurve.postWrapMode = WrapMode.PingPong;
//		mMoveCurve.preWrapMode = WrapMode.PingPong;
//		mTarget = null;
	}

	void Update ()
	{
		StartCoroutine (UpdateJoystick ());
	}

	IEnumerator UpdateJoystick ()
	{
		yield return new WaitForEndOfFrame ();

		// unity axes
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		mThumbPos = mThumbRectTransform.localPosition;
		if (x != 0.0f) {
			mThumbPos = new Vector2 (mRadius * x, mThumbPos.y);
		}

		if (y != 0.0f) {
			mThumbPos = new Vector2 (mThumbPos.x, mRadius * y);
		}
		mThumbRectTransform.anchoredPosition = mThumbPos;

		// update move
		mMoveVec = mThumbPos / mRadius;
		MoveControl (mMoveVec);
	}

	void MoveControl (Vector2 motion)
	{
//		if (mTarget == null) {
//			GameObject go = GameObject.FindGameObjectWithTag ("RPG-Character");
//			if (go != null) {
//				mTarget = go.GetComponent<RPGCharacterController> ();
//			}
//		}
//		if (mTarget != null) {
//			//                mTarget.Move(motion);
//		}
	}

	#endregion

	#region Pointer Handlers

	public void OnPointerDown (PointerEventData eventData)
	{
		mPointerId = eventData.pointerId;
		(transform as RectTransform).position = eventData.pressPosition;
		OnDrag (eventData);
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		if (mPointerId == eventData.pointerId) {
			(transform as RectTransform).position = mBakPos;
			mThumbRectTransform.anchoredPosition = Vector2.zero;
			mPointerId = -1;
		}
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (mPointerId == eventData.pointerId) {
			mThumbPos = (eventData.position - eventData.pressPosition);
			mThumbPos.x = Mathf.FloorToInt (mThumbPos.x);
			mThumbPos.y = Mathf.FloorToInt (mThumbPos.y);
			if (mThumbPos.magnitude > mRadius) {
				mThumbPos = mThumbPos.normalized * mRadius;
			}
			mThumbRectTransform.localPosition = mThumbPos;
		}
	}

	#endregion
}