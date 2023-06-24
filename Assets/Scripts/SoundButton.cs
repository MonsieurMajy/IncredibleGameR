using UnityEngine;
using UnityEngine.UI;

public class SoundButton: MonoBehaviour
{
    public Sprite uncheckedSprite;
    public Sprite checkedSprite;

    private Image buttonImage;
    private bool isChecked = false;
    public AudioSource musicAudioSource;
    public static bool noisesAudioActivated = true;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void BackgroundAudioSwitch()
    {
        isChecked = !isChecked;

        if (isChecked)
        {
            buttonImage.sprite = checkedSprite;
            musicAudioSource.Stop();
        }
        else
        {
            buttonImage.sprite = uncheckedSprite;
            musicAudioSource.Play();
        }
    }

    public void NoisesAudioSwitch()
    {
        isChecked = !isChecked;

        if (isChecked)
        {
            buttonImage.sprite = checkedSprite;
            noisesAudioActivated = false;
        }
        else
        {
            buttonImage.sprite = uncheckedSprite;
            noisesAudioActivated = true;
        }
    }
}
