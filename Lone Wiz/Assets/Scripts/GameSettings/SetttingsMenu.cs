using UnityEngine;
using UnityEngine.Audio;

public class SetttingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVoulme (float voulme)
    {
        audioMixer.SetFloat("volume", voulme);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
