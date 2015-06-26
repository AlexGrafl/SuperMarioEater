using UnityEngine;
using System.Collections;

public class PlantScript : MonoBehaviour {
	
	Animator anim;
	bool isGrowing;
	public float moveForce;
	public float maxHeight;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isGrowing){
			rigidbody2D.AddForce(Vector2.up * moveForce);
		}
		if(transform.position.y > maxHeight) {
			rigidbody2D.velocity = new Vector2(0, 0);
			transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
		}
	}
	
	public void SetGrowing(bool growing){
		Debug.Log("plant is growing");
		isGrowing = growing;
		anim.SetBool("isGrowing", isGrowing);
	}
}
