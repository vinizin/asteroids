using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {


    public void LoadLevelSphere()
    {
        SceneManager.LoadScene("SphereLevel");
    }

    public void LoadLevelInfinite()
    {
        SceneManager.LoadScene("InfiniteLevel");

    }
}
