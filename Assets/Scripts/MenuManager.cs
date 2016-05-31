using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

	void Start()
	{
		AudioController.Play("MenuSong");
	}

    public void LoadLevelSphere()
    {
		AudioController.Stop("MenuSong");
        SceneManager.LoadScene("SphereLevel");
    }

    public void LoadLevelInfinite()
    {
		AudioController.Stop("MenuSong");
        SceneManager.LoadScene("InfiniteLevel");

    }

}
