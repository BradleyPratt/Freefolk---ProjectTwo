using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour {

    public void LoadByIndex(int sceneIndex)
    {
        Debug.Log("ClickedButton");
        SceneManager.LoadScene(sceneIndex);
    }
}
