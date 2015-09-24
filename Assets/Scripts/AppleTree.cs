using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {
	//Prefab for instantiating apples
	public GameObject applePrefab;

	//Speed of AppleTree moving in meters/sec
	public float speed = 1f;

	//Distance where AppleTree turns around
	public float leftAndRightEdge = 10f;

	//Chance that AppleTree will change directions
	public float chanceToChangeDirections = 0.1f;

	//Rate at which Apples will be instantiated
	public float secondsBetweenAppleDrops = 1f;

	void Start(){
		//Drops apples every second
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);
	}
	void DropApple(){
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}
	void Update(){
		//Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//Changing Direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);//move right
		}else if (pos.x > leftAndRightEdge){
			speed = -Mathf.Abs (speed);//move left
		}
	}
	void FixedUpdate(){
		//Changing direction randomly
		if (Random.value < chanceToChangeDirections) {
			speed *= -1;//Change directions
		}
	}
}
