using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour {

	public GameObject playerExplosion, hazardExplosion;
	private GameController gameController;

	void Start(){
		GameObject ob = GameObject.FindGameObjectWithTag ("GameController");
		if (ob!=null){
			gameController = ob.GetComponent<GameController> ();
		}

	}


	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary")
			return;

		
		Instantiate (hazardExplosion, gameObject.transform.position,gameObject.transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			gameController.GameOver ();
		} else {
			gameController.AddScore ();
			Destroy (other.gameObject);

		}
		
		Destroy (gameObject.gameObject);
	}


}
