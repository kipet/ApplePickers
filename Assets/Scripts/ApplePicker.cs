using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
		for (int i =0; i<numBaskets; i++) {
			GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}
	public void AppleDestroyed(){ 
		//Destroy all falling apples
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject tGo in tAppleArray){
			Destroy(tGo);
		}
		//Destory one basket
		//Get index of last basket in basketList
		int basketIndex = basketList.Count - 1;
		//get reference to Basket GameObject
		GameObject tBasketGO = basketList [basketIndex];
		//remove basket from list and destroy GameObject
		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGO);

		//restart game, doesn't affect HighScore.score
		if (basketList.Count == 0) {
			Application.LoadLevel("Apple Picker Prototype");
		}
	}
}
