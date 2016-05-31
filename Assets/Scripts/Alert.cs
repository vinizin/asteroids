using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Alert : MonoBehaviour {
    public static Alert instance;
    public Text alert;

    void Awake()
    {
        instance = this;
    }
    public void ShowAlert(bool active)
    {
        alert.gameObject.SetActive(active);
    }
}
