using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            System.Random rand = new System.Random();
            int chance = rand.Next(1, 6);
            int gold;
            if (chance == 6)
            {
                gold = 4;
            } else if (chance == 3)
            {
                gold = 2;
            } else {
                gold = 1;
            }
            GameObject.FindGameObjectWithTag("GoldText").GetComponent<Gold>().EarnGold(gold);
            GameObject.Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetRot(Quaternion rot)
    {
        transform.rotation = rot;
    }
}
