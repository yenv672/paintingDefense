using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class controller_Main : MonoBehaviour {

	public bool pressedTriggerBut = false;
	public bool pressedGripBut = false;
	public bool pressedTouchBut = false;
	public bool pressedMenuBut = false;

    private Valve.VR.EVRButtonId touchPadButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId MenuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

	public SteamVR_Controller.Device controllerMy { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
	public SteamVR_TrackedObject trackedObj;
	ushort nowHaptic = 0;
	public float haptic_min = 10;
	public float haptic_max = 2000;
	public float haptic_Acc_time = 3;
	 float hapticSecStartTime = -1;
	Coroutine haptingCor;

    [System.Serializable]
    public class MyEventType : UnityEvent { }
    //public MyEventType stay;
	public MyEventType triggerGripBut;
	public MyEventType exitGripBut;
	public MyEventType triggerTouchBut;
	public MyEventType exitTouchBut;
    public MyEventType triggerTriggerBut;
    public MyEventType exitTriggerBut;
	public MyEventType triggerMenuBut;
	public MyEventType exitMenuBut;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (controllerMy == null) {
			Debug.Log("Controller not initialized");
			return;
		}

		if (controllerMy.GetPress(MenuButton)) {
			pressedMenuBut = true;
			OnTriggerMenuBut();
		}

		if (controllerMy.GetPressUp(MenuButton)) {
			pressedMenuBut = false;
			EndTriggerMenuBut();
		}

		if (controllerMy.GetPress(triggerButton)) {
			pressedTriggerBut = true;
            OnTriggerTriggerBut();
		}

		if (controllerMy.GetPressUp(triggerButton)) {
			pressedTriggerBut = false;
            EndTriggerTriggerBut();
		}

		if (controllerMy.GetPress(gripButton)) {
			pressedGripBut = true;
			OnTriggerGripBut();
		}

		if (controllerMy.GetPressUp(gripButton)) {
			pressedGripBut = false;
			EndTriggerGripBut();
		}

		if (controllerMy.GetPress(touchPadButton)) {
			pressedTouchBut = true;
			OnTriggerTouchBut();
		}

		if (controllerMy.GetPressUp(touchPadButton)) {
			pressedTouchBut = false;
			EndTriggerTouchBut();
		}
	}

	public void hapticLight(){
		controllerMy.TriggerHapticPulse (100);
	}


	public void hapticSmall(){
		controllerMy.TriggerHapticPulse (500);
	}

	public void startHapticForAwhile(){
		print ("invoke "+ hapticSecStartTime);
		if (haptingCor == null) {
			hapticSecStartTime = Time.time;
			haptingCor = StartCoroutine (hapticing());
		} 
	}

	IEnumerator hapticing(){
		while (hapticSecStartTime != -1 && hapticSecStartTime + 0.1f > Time.time) {
			hapticSmall ();
			yield return null;
		}

		hapticSecStartTime = -1;

		if (haptingCor != null) {
			StopCoroutine (haptingCor);
			haptingCor = null;
		}
		yield return null;
	}

	public void hapticInbetween(){
		if (nowHaptic == 0) {
			nowHaptic = (ushort)Mathf.Lerp (haptic_min, haptic_max, haptic_Acc_time * Time.deltaTime);
		} else {
			nowHaptic = (ushort)Mathf.Lerp (nowHaptic, haptic_max, haptic_Acc_time * Time.deltaTime);
		}

		controllerMy.TriggerHapticPulse (nowHaptic);
	}

	public void endHapticInBetween(){
		nowHaptic = 0;
	}

	public void OnTriggerMenuBut(){
		triggerMenuBut.Invoke ();
	}

	public void EndTriggerMenuBut(){
		exitMenuBut.Invoke ();
	}

	public void OnTriggerTouchBut(){
		triggerTouchBut.Invoke ();
	}

	public void EndTriggerTouchBut(){
		exitTouchBut.Invoke ();
	}

	public void OnTriggerGripBut(){
		triggerGripBut.Invoke ();
	}

	public void EndTriggerGripBut(){
		exitGripBut.Invoke ();
	}

    public void OnTriggerTriggerBut(){
        triggerTriggerBut.Invoke();
    }

    public void EndTriggerTriggerBut() {
        exitTriggerBut.Invoke();
    }

}
