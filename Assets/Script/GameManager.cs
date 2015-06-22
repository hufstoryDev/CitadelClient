using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private GameObject user;
	private GameObject competitor1;
	private GameObject competitor2;
	private PlayerInfo pi;

	public int gameTurn = 0;

	// Use this for initialization
	void Start () {


		user = GameObject.FindWithTag ("USER").gameObject;
		competitor1 = GameObject.FindWithTag ("COMPETITOR1").gameObject;
		competitor2 = GameObject.FindWithTag ("COMPETITOR2").gameObject;

		pi = user.GetComponent<PlayerInfo> ();
		pi.setTurn (0);
		pi = competitor1.GetComponent<PlayerInfo> ();
		pi.setTurn (1);
		pi = competitor2.GetComponent<PlayerInfo> ();
		pi.setTurn (2);

		PlayGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (100, 100, 50, 50), "end")) {
			gameTurn++;

			if(gameTurn > 2)
				gameTurn = 0;

			print(gameTurn);
		}
	}

	void setKing(GameObject player){
	
	}

	void PlayGame(){
	}

	void CardSelect(){

	}

	void BasicPlay(){

	}

	void JobPlay(){
	
	}

	void Arrange(){

	}
}
