using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsController.SetMasterVolume(0.5f);
        float dicks = PlayerPrefsController.GetMasterVolume();
        Debug.Log("NOT ITS NOT TO LOUD AT " + dicks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
