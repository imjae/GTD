using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundSelect : MonoBehaviour
{
    public SoundPlayer soundPlayer;

    TMP_InputField soundSelect;

    private void Start()
    {
        soundSelect = GetComponent<TMP_InputField>();
    }

    private void Update()
    {
        soundPlayer.situation = soundSelect.text;
    }
}
