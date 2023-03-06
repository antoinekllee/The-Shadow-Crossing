using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMenuActivator : MonoBehaviour
{
    bool canOpenMenu; 

    private void Update()
    {
        if (canOpenMenu)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SavePoint.menuActive = true;
                GameManager.instance.saveMenuOpen = true;                 
                canOpenMenu = false;

                AudioManager.instance.PlaySFX(1); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
            canOpenMenu = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpenMenu = false;
        }
    }
}
