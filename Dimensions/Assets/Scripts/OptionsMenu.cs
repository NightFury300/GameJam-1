using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    private float volume;

    public void Done()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void AdjustVolume(float volume)
    {
        mixer.SetFloat("mastervolume",volume);
        this.volume = volume;
    }

    public void Mute(bool isMute)
    {
        if(isMute)
        {
            mixer.SetFloat("mastervolume", volume);
            isMute = false;
        }
        else
        {
            mixer.SetFloat("mastervolume", -80.0f);
            isMute = true;
        }
    }

    public void Fullscreen()
    {
        if (Screen.fullScreen)
            Screen.fullScreen = false;
        else
            Screen.fullScreen = true;
    }
}
