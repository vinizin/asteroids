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
			AudioController.Play("Alarm");
            Alert.instance.ShowAlert(true);
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
			AudioController.Stop("Alarm");
            Alert.instance.ShowAlert(false);
        }
    }
}
