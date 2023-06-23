using UnityEngine;
using UnityEngine.UI;

public class SoundButton: MonoBehaviour
{
    public Sprite uncheckedSprite;
    public Sprite checkedSprite;

    private Image buttonImage;
    private bool isChecked = false;
    public AudioSource musicAudioSource;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void OnButtonClick()
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
}
