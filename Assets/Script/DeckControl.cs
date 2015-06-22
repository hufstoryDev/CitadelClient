using UnityEngine;
using System.Collections;

public class DeckControl : MonoBehaviour {

	public GameObject card;
	private GameObject hand;

	private Transform tr;
//	private CardCtrl cc;
	private GameManager gm;
	private GameObject gameManager;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
//		cc = card.GetComponent<CardCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OnMouseDown(){
		gameManager = GameObject.FindWithTag ("GAMEMANAGER").gameObject;
		gm = gameManager.GetComponent<GameManager> ();
		switch(gm.gameTurn)
		{
		case 0:
			hand = GameObject.FindWithTag ("PLAYERHAND").gameObject;

			break;
		case 1:
			hand = GameObject.FindWithTag ("COMPEHAND1").gameObject;

			break;
		case 2:
			hand = GameObject.FindWithTag ("COMPEHAND2").gameObject;

			break;
		}

		GameObject child = Instantiate (card) as GameObject;

		CardCtrl cc = child.GetComponent<CardCtrl> ();


		child.transform.position = tr.position;
		child.transform.parent = hand.transform;

		cc.moveTo = hand.transform.position;
		cc.rotateTo = hand.transform.rotation;

		HandManager hm = hand.GetComponent<HandManager> ();
		hm.ListAdd (child);

		yield return null;
	}
}
