using UnityEngine;
using System.Collections;

public class compePlayBoardManager : PlayBoardManager {
	
	public override void ListSort(){
		
		CardCtrl cc = fieldList[fieldCount - 1].GetComponent<CardCtrl> ();
		GameObject cardFace = cc.transform.FindChild ("CardFace").gameObject;
		Vector3 position = place.transform.position;
		Quaternion rotation = hand.transform.rotation;
		
		place.transform.Translate (new Vector3((fieldCount - 1) * 120 - 120, 0, 0));
		
		if (this.tag != "PLAYERBOARD")
			cardFace.transform.Translate(new Vector3(0,2,0));
		/*position.x -= 120;
		position.x += (fieldCount - 1) * 120;*/
		/*if (this.tag != "PLAYERBOARD")
			place.transform.Rotate (new Vector3 (0, 0, 180));*/
		
		cc.moveTo = place.transform.position;
		place.transform.position = position;
		
		cc.rotateTo = rotation;
	}
}