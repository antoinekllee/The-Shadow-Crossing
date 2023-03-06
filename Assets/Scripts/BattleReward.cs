using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BattleReward : MonoBehaviour {

    public static BattleReward instance;

    public Text xpText, itemText, goldText;
    public GameObject rewardScreen;

    public string[] rewardItems;
    public int xpEarned;

    public bool markQuestComplete;
    public string questToMark;
    
	// Use this for initialization
	void Start () {
        instance = this; 
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OpenRewardScreen(int xp, string[] rewards)
    {
        xpEarned = xp;
        rewardItems = rewards;

        xpText.text = "You Earned " + xpEarned + "XP!";

        goldText.text = "Gold Earned " + BattleStarter.instance.goldEarned + "g"; 

        itemText.text = "";

        for (int i = 0; i < rewardItems.Length; i++)
        {
            itemText.text += rewards[i] + "\n"; 
        }

        rewardScreen.SetActive(true); 
    }

    public void CloseRewardsScreen()
    {
        for (int i = 0; i < GameManager.instance.playerStats.Length; i++)
        {
            if (GameManager.instance.playerStats[i].gameObject.activeInHierarchy)
            {
                GameManager.instance.playerStats[i].AddExp(xpEarned); 
            }
        }

        for (int i = 0; i < rewardItems.Length; i++)
        {
            GameManager.instance.AddItem(rewardItems[i]); 
        }

        rewardScreen.SetActive(false);
        GameManager.instance.battleActive = false; 

        if (markQuestComplete)
        {
            QuestManager.instance.MarkQuestComplete(questToMark); 
        }
    }
}
