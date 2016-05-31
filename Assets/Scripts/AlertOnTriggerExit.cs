using UnityEngine;
using System.Collections;

public class AlertOnTriggerExit : MonoBehaviour {

    void Start()
    {
        Alert.instance.ShowAlert(false);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Alert.instance.ShowAlert(true);
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Alert.instance.ShowAlert(false);
        }
    }
}
