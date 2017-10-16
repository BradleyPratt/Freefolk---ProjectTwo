using UnityEngine;
using System.Collections;

public class PathEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("LivesText").GetComponent<Lives>().TakeDamage();
            GameObject.Destroy(col.gameObject);
        }
    }
}
