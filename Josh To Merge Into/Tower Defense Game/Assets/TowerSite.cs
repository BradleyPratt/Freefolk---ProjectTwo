using UnityEngine;
using System.Collections;
using System.Linq;

public class TowerSite : MonoBehaviour
{

    public GameObject towerPrefab;
    public float speed = 1f;

    private bool canPlaceTower()
    {
        return tower == null;
    }


    private GameObject tower;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnMouseUp()
    {
        if (canPlaceTower())
        {
            if (GameObject.FindGameObjectWithTag("GoldText").GetComponent<Gold>().SpendGold(20))
            {
                tower = (GameObject)
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
