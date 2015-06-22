using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandManager : MonoBehaviour {

	private List<GameObject> handList;
	private CardCtrl cc;
	private int handCount = 0;
	private GameObject place;


	// Use this for initialization
	void Start () {
		handList = new List<GameObject>();

		if (this.tag == "PLAYERHAND")
			place = GameObject.FindWithTag ("PLAYERPLACE").gameObject;
		else if (this.tag == "COMPEHAND1")
			place = GameObject.FindWithTag ("COM1PLACE").gameObject;
		else if (this.tag == "COMPEHAND2")
			place = GameObject.FindWithTag ("COM2PLACE").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (handCount > 1)
			ListSort ();
		else if (handCount == 1) {
			cc = handList [0].GetComponent<CardCtrl> ();
			cc.rotateTo = this.transform.rotation;
		}
	}

	public void ListAdd(GameObject card){
		handList.Insert (handCount++, card);
	}

	public void ListSort(){
		//float handY = this.transform.parent.transform.rotation.y;
		float angle = -30.0f;
		Quaternion placeRot = place.transform.rotation;
		Vector3 placePos = place.transform.position;

		int handPosition = -60 * (handCount / 2);
		
		for (int i = 0; i < handCount; i++) {
			float handRotation = 60 / (handCount - 1);

			CardCtrl temp = handList [i].GetComponent<CardCtrl> ();
			/*float handX = this.transform.parent.transform.rotation.x;
			temp.rotateTo = Quaternion.Euler (handX, angle + handRotation * i, 0);
			temp.rotateTo.y += handY;*/

			place.transform.Rotate(new Vector3(0,angle + handRotation * i, 0));
			temp.rotateTo = place.transform.rotation;

			place.transform.rotation = placeRot;

//			Vector3 position = //handList [i].transform.parent.localPosition;
				//this.transform.position;
				//this.transform.localPosition;

			place.transform.Translate(new Vector3(handPosition + (60 * i), i * 1.5f, 0));
			/*placePos.x += handPosition;
			placePos.x += 30 * i;
			placePos.y += i;*/

			temp.moveTo = place.transform.position;
			place.transform.position = placePos;

			/*
			temp.moveTo.x += handPosition;
			temp.moveTo.x += 30 * i;
			temp.moveTo.y += i;*/

		}
	}

	public void RemoveInHand(GameObject card){
		handList.Remove (card);
		handCount--;
	}
}
