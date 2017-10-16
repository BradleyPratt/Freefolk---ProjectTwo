using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour {

    private int lives;
    private Text text;
    
    // Use this for initialization
    void Start () {
        lives = 10;
        text = GetComponent<Text>();
        text.text = lives.ToString();    
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void TakeDamage ()
    {
        lives = lives - 1;
        if (lives < 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        } else
        {
            text.text = lives.ToString();
        }
    }
}
