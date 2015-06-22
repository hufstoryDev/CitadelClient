using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayBoardManager : MonoBehaviour {

	protected List<GameObject> fieldList;
	protected int fieldCount = 0;
	protected GameObject place;
	private CardCtrl cc;
	private int fieldLimit = 3;

	public GameObject hand;
	public GameObject player;

	// Use this for initialization
	void Start () {
		fieldList = new List<GameObject> ();

		if (this.tag == "PLAYERBOARD")
			place = GameObject.FindWithTag ("PBOARDPLACE").gameObject;
		else if (this.tag == "COMPEBOARD1")
			place = GameObject.FindWithTag ("COM1BOARDPLACE").gameObject;
	 	else if (this.tag == "COMPEBOARD2")
			place = GameObject.FindWithTag ("COM2BOARDPLACE").gameObject;
	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col){
		cc = col.gameObject.GetComponent<CardCtrl> ();
		GameObject cardParent = col.transform.parent.gameObject;

		if (col.tag == "CARD" && cardParent == hand)
			cc.onBoard = true;
	}
	
	void OnTriggerEnter(Collider col){
		cc = col.gameObject.GetComponent<CardCtrl> ();
		GameObject cardParent = col.transform.parent.gameObject;

		if (col.tag == "CARD" && cardParent == hand)
			cc.onBoard = true;
	}
	
	void OnTriggerExit(Collider col){
		cc = col.gameObject.GetComponent<CardCtrl> ();

		if (col.tag == "CARD")
			cc.onBoard = false;
	} 

	public void ListAdd(GameObject card){

		if (fieldCount < fieldLimit) {

			CardCtrl cc = card.GetComponent<CardCtrl>();
			HandManager hm = hand.GetComponent<HandManager>();

			cc.moveAble = false;
			card.transform.parent = this.transform;

			hm.RemoveInHand(card);
			fieldList.Insert (fieldCount++, card);
			ListSort ();
		}
	}

	public virtual void ListSort(){}
}
