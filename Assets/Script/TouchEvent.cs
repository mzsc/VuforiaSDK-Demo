using UnityEngine;
using System.Collections;

public class TouchEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved)) {
            TouchRotation();
        }

        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void TouchRotation() {
        Vector2 TouchDelta = Input.GetTouch(0).deltaPosition;
        Vector3 LowRotation = this.transform.rotation.eulerAngles;
        Quaternion NewRotation = new Quaternion();
        NewRotation.eulerAngles = new Vector3(LowRotation.x - TouchDelta.y, LowRotation.y - TouchDelta.x, LowRotation.z);
        this.transform.rotation = NewRotation;
    }
}
