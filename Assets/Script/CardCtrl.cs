using UnityEngine;
using System.Collections;

public class CardCtrl : MonoBehaviour {

	public Vector3 moveTo;
	public Quaternion rotateTo;
	public bool moveAble = true;
	public bool onBoard = false;
	public GameObject hand;
	public GameObject playboard;

	private GameObject gameManager;
	private PlayBoardManager pm;
	private HandManager hm;
	private GameManager gm;
	private Transform thisTrans;
	private Transform edgeTrans;


	// Use this for initialization
	void Start () {
		thisTrans = transform;
		edgeTrans = thisTrans.FindChild("Edge");
		gameManager = GameObject.FindWithTag ("GAMEMANAGER").gameObject;
		gm = gameManager.GetComponent<GameManager> ();

		switch(gm.gameTurn)
		{
		case 0:
			hand = GameObject.FindWithTag ("PLAYERHAND").gameObject;
			playboard = GameObject.FindWithTag ("PLAYERBOARD").gameObject;
			break;
		case 1:
			hand = GameObject.FindWithTag ("COMPEHAND1").gameObject;
			playboard = GameObject.FindWithTag ("COMPEBOARD1").gameObject;
			break;
		case 2:
			hand = GameObject.FindWithTag ("COMPEHAND2").gameObject;
			playboard = GameObject.FindWithTag ("COMPEBOARD2").gameObject;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Lerp(this.transform.position
		                                       , moveTo
		                                       , 5*Time.deltaTime);
		
		this.transform.rotation = Quaternion.Lerp (this.transform.rotation
		                                           , rotateTo
		                                           , 5*Time.deltaTime);
	}
	
	IEnumerator OnMouseDown(){
		
		Vector3 scrSpace = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x
		                                                                                   , Input.mousePosition.y
		                                                                                   , scrSpace.z));
		
		if (moveAble) {
			while (Input.GetMouseButton(0)) {
				Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, scrSpace.z); 
				Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
				transform.position = curPosition;
				transform.rotation = hand.transform.rotation;
				
				yield return null;
			}
		}
	}
	
	IEnumerator OnMouseUp(){

		if (onBoard) {
			pm = playboard.GetComponent<PlayBoardManager> ();
			pm.ListAdd (this.gameObject);
			edgeTrans.gameObject.SetActive(false);
		}
		
		yield return null;
	}

	IEnumerator OnMouseEnter(){
		if (thisTrans.parent.gameObject == hand)
			edgeTrans.gameObject.SetActive(true);

		yield return null;
	}

	IEnumerator OnMouseExit(){
		edgeTrans.gameObject.SetActive(false);

		yield return null;
	}
}
