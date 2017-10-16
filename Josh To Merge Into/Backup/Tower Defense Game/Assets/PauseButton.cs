using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

    private bool paused = false;

    public void TogglePause()
    {
        if (paused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        paused = !paused;
    }
}
