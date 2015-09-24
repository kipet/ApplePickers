using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {
	public GUIText scoreGT; //1

	void Start(){
		//find reference to ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find ("ScoreCounter");//2
		//Get GUIText Component of GameObject
		scoreGT = scoreGO.GetComponent<GUIText> ();//3
		//Start poitns at 0
		scoreGT.text= "0";
	}
	// Update is called once per frame
	void Update () {
	//Get Current screen position of mouse from input
		Vector3 mousePos2D = Input.mousePosition; //1
		mousePos2D.z = -Camera.main.transform.position.z; //2
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D); //3

		//Move the x position of basket to x position of mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}
	void OnCollisionEnter (Collision coll){ //2
		//find what hit this basket
		GameObject collidedWith = coll.gameObject; //3
		if (collidedWith.tag == "Apple") {//4
			Destroy (collidedWith);
		}
		//Parse text of scoreGT into int
		int score = int.Parse (scoreGT.text);
		//Add points for catching apple
		score += 1;
		//Convert score back to string and display
		scoreGT.text = score.ToString ();
		//track high score
		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}
