using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

    public void LoadByIndex(int sceneIndex)
    {
        Debug.Log("ClickedButton");
        SceneManager.LoadScene(sceneIndex);
    }
}
