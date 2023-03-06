using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCrate : MonoBehaviour
{

    private bool inArea = false; 

    private void Update()
    {
       if (inArea)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                transform.Translate(transform.right * Time.deltaTime * 8.25f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = false;
        }
    }
}
