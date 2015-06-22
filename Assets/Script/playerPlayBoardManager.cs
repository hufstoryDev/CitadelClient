using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerPlayBoardManager : PlayBoardManager {
	
	public override void ListSort(){
		print ("start");
		CardCtrl cc = fieldList[fieldCount - 1].GetComponent<CardCtrl> ();
		Vector3 position = place.transform.position;
		Quaternion rotation = hand.transform.rotation;
		
		place.transform.Translate (new Vector3((fieldCount - 1) * 120 - 120, 0, 0));

		/*position.x -= 120;
		position.x += (fieldCount - 1) * 120;*/
		/*if (this.tag != "PLAYERBOARD")
			place.transform.Rotate (new Vector3 (0, 0, 180));*/
		
		cc.moveTo = place.transform.position;
		place.transform.position = position;
		
		cc.rotateTo = rotation;
	}
}
