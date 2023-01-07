using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu: MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer MainMixer;
    private float value;

    private void Start()
    {
        Time.timeScale = 1;
        MainMixer.GetFloat("Volume", out value);
        volumeSlider.value = value;
    }
    public void SetVolume()
    {
        MainMixer.SetFloat("Volume", volumeSlider.value);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        PlayerManager.lastCheckPointPos = new Vector2(10.51f, 202.61f);

    }



}
