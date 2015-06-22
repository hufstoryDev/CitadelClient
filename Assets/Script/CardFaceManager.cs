using UnityEngine;
using System.Collections;

public class CardFaceManager : MonoBehaviour {

	private Material mt;
	private int cardNum;
	private Renderer renderer;

	// Use this for initialization
	void Start () {

		cardNum = Random.Range (1, 3+1);
		renderer = GetComponent<Renderer> ();
		
		switch (cardNum) {
		case 1:
			mt = Resources.Load ("Materials/Card1", typeof(Material)) as Material;
			renderer.material = mt;
			break;
		case 2:
			mt = Resources.Load ("Materials/Card2", typeof(Material)) as Material;
			renderer.material = mt;
			break;
		case 3:
			mt = Resources.Load ("Materials/Card3", typeof(Material)) as Material;
			renderer.material = mt;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
