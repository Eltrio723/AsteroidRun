using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public AudioMixer masterMixer;

    public void SetMasterVol(Slider slider){
        masterMixer.SetFloat("MasterVol", slider.value);
    }

    public void SetMusicVol(Slider slider) {
        masterMixer.SetFloat("MusicVol", slider.value);
    }

    public void SetSoundVol(Slider slider)
    {
        masterMixer.SetFloat("SoundVol", slider.value);
    }

}
