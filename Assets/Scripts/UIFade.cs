using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIFade : MonoBehaviour {

    public static UIFade instance; 

    public Image fadeScreen;
    public float fadeSpeed; 

    private bool shouldFadeToBlack;
    private bool shouldFadeFromBlack; 

	// Use this for initialization
	void Start () {
        instance = this;

        DontDestroyOnLoad(gameObject); 

	}
	
	// Update is called once per frame
	void Update () {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
                shouldFadeFromBlack = true; 
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            shouldFadeToBlack = false;
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true; 
        shouldFadeFromBlack = false; 
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true; 
    }
}
