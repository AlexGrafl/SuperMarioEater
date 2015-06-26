using UnityEngine;
using System.Collections;

public class OnTouchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
		     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) {
		        CheckTouch(Input.GetTouch(0).position, true);
		    }
		} else if(Application.platform == RuntimePlatform.WindowsEditor){
			if(Input.GetMouseButtonDown(0)) {
				CheckTouch(Input.mousePosition, true);
         	} else if(Input.GetMouseButtonUp(0)){
				CheckTouch(Input.mousePosition, false);
			}
		}
	}
	
	void CheckTouch(Vector3 pos, bool down){
		pos.z = 10;
		Vector3 camPos = Camera.main.ScreenToWorldPoint(pos);
		int pipeLayerMask = 1 << LayerMask.NameToLayer("Pipes");
     	RaycastHit2D hit = Physics2D.Raycast(camPos, Vector2.zero, Mathf.Infinity, pipeLayerMask);
     	if (hit != null && hit.collider != null) {
     	    Debug.Log ("I'm hitting " + hit.collider.name);
			if(hit.collider.name.StartsWith("pipe")){
				GameObject plant = GameObject.Find("plant_" + hit.collider.name.Substring(hit.collider.name.Length - 1, 1));
				Debug.Log("Found plant " + plant.name);
				plant.GetComponent<PlantScript>().SetGrowing(down);
			}
     	}
	}
}
