using UnityEngine;
using System.Collections;

public class TouchEvent : MonoBehaviour {

    public Transform ARCamera;

    private float LastDistance = 0;
    private float CurrentDistance = 0;
    private float ChangeDistance = 0;
    private bool MultiTouch = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Moved)) {
            TouchRotation();
        }

        if ((Input.touchCount > 1) && ((Input.GetTouch(0).phase == TouchPhase.Moved) || (Input.GetTouch(1).phase == TouchPhase.Moved))) {
            TouchScale();
            MultiTouch = true;
        }

        if (Input.touchCount <= 1) {
            MultiTouch = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void TouchRotation() {
        Vector2 TouchDelta = Input.GetTouch(0).deltaPosition;
        if (Mathf.Abs(TouchDelta.x) >= Mathf.Abs(TouchDelta.y)) {
            this.transform.Rotate(0, -TouchDelta.x, 0, Space.World);
        } else {
            this.transform.Rotate(-TouchDelta.y, 0, 0, Space.World);
        }      
    }

    private void TouchScale() {
        Vector2 Pos0 = Input.GetTouch(0).position;
        Vector2 Pos1 = Input.GetTouch(1).position;
        CurrentDistance = Vector2.Distance(Pos0, Pos1);
        ChangeDistance = CurrentDistance - LastDistance;

        if ((MultiTouch == true) && (ChangeDistance != 0)) {
            this.transform.Translate(0, 0, ChangeDistance * -2, ARCamera);
        }
        LastDistance = CurrentDistance;
    }
}
