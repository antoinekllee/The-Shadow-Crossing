using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{

    public GameObject saveMenu;
    public static bool menuActive = false;

    private void Update()
    {
        if (menuActive)
        {
            saveMenu.SetActive(true); 
        } 
        else if (!menuActive)
        {
            saveMenu.SetActive(false); 
        }
    }

    public void Cancel()
    {
        menuActive = false;
        GameManager.instance.saveMenuOpen = false;
    }
}
