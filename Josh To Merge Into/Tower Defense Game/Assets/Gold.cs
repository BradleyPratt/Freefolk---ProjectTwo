using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gold : MonoBehaviour {

    private int gold;
    private Text text;

    // Use this for initialization
    void Start()
    {
        gold = 50;
        text = GetComponent<Text>();
        text.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool SpendGold(int spentGold)
    {
        int checkGold;
        checkGold = gold - spentGold;
        if (checkGold < 0)
        {
            return false;
        }
        else
        {
            gold = checkGold;
            text.text = gold.ToString();
            return true;
        }
    }

    public void EarnGold(int earnedGold)
    {
        gold = gold + earnedGold;
        text.text = gold.ToString();
    }
}
