using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

    private bool canPickup;
    public bool pickupGold;
    public int goldToAdd;

    public bool destroyAfterPickup = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canPickup && Input.GetKeyDown(KeyCode.Z) && PlayerController.instance.canMove)
        {
            if (pickupGold)
            {
                GameManager.instance.currentGold += goldToAdd; 
            }
            else
            {
                GameManager.instance.AddItem(GetComponent<Item>().itemName);
            }

            if (destroyAfterPickup)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canPickup = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canPickup = false;
        }
    }
}
