using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Close : MonoBehaviour
{
    public void doExitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
