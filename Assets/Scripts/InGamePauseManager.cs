using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Cameras;

public class InGamePauseManager : MonoBehaviour {

    public GameObject menu;
    public void LoadLevelSphere()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("main");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Show(!menu.activeSelf);
        }
    }
    void Show(bool active)
    {
        menu.SetActive(active);
        if (active)
        {
            Cursor.visible = true;
            Time.timeScale = 0;

        }
        else
        {
            FreeLookCam.instance.m_LockCursor = true;
            Cursor.visible = false;

            Time.timeScale = 1;
        }
    }

    void SetTimeZero()
    {
        Time.timeScale = 0;
    }
}
