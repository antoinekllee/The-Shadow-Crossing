using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour {

    public GameObject player; 

	// Use this for initialization
	void Start () {
        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone; 
        }
	}
	
	// Update is called once per frame
    void Update () {
		
	}
}
