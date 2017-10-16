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
        GameObject temp_player = GameObject.FindGameObjectWithTag("Player");
        Enemy temp_script = col.gameObject.GetComponent<Enemy>();
        if (temp_script != null)
        {
            Destroy(col.gameObject);
            //temp_player.GetComponent<Player>loseLife();
        }
    }
}
