using UnityEngine;
using System.Collections;

public class Money : MonoBehaviour
{
    public GUIText moneyText;
    public int money = 0;

    void Start()
    {

    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    void Update()
    {
        moneyText.text = "Gold: " + money;
    }
}