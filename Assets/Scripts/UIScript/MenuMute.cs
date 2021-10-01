using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMute : MonoBehaviour
{
    
    public void AllSound()
    {
         AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
    
}
