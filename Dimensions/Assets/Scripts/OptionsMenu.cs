using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;

    [SerializeField] private Slider slider;

    private float previousVolume;

    public void Done()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void AdjustVolume(float volume)
    {
        mixer.SetFloat("mastervolume",volume);
    }

    public void Mute(bool isMute)
    {
        
        if(!isMute)
        {
            mixer.SetFloat("mastervolume", previousVolume);       
            slider.value = previousVolume;
        }
        else
        {           
            mixer.SetFloat("mastervolume", -80.0f);
            previousVolume = slider.value;
            slider.value = -80.0f;
        }
        
    }

    public void Fullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
