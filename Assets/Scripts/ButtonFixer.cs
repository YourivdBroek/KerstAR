using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFixer : MonoBehaviour
{
    /*
    private void Start()
    {
        PresetSwitcher switcher = GameObject.FindGameObjectWithTag("Player").GetComponent<PresetSwitcher>();
        switcher.DeleteOldARSessionOrigins();
    }
    */
    

    public void NextPreset()
    {
        //PresetSwitcher switcher = GameObject.FindGameObjectWithTag("Player").GetComponent<PresetSwitcher>();
        PresetSwitcher.Instance.NextPreset();
    }

    public void LastPreset()
    {
        //PresetSwitcher switcher = GameObject.FindGameObjectWithTag("Player").GetComponent<PresetSwitcher>();
        PresetSwitcher.Instance.LastPreset();
    }
}
