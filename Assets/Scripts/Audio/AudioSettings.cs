using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;
    
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource audioClick;

    private bool isPlay;
    private Image image;
    private Button button;

    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        isPlay = true;
        SetSprite(pauseSprite);
        GameManager.State += PauseGame;
    }

    private void PauseGame(EnumStateGame state)
    {
        switch (state)
        {
            case EnumStateGame.Game:
                SetInteractableButton(true);
                break;
            case EnumStateGame.Pause:
                SetInteractableButton(false);
                break;
        }
    }

    private void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetIsPlay()
    {
        isPlay = !isPlay;

        if (isPlay)
        {
            SetSprite(pauseSprite);
            SetMuteAudio(audio, false);
            SetMuteAudio(audioClick, false);
            return;
        }
        
        SetSprite(playSprite);
        SetMuteAudio(audio, true);
        SetMuteAudio(audioClick, true);
    }

    private void SetMuteAudio(AudioSource audioSource, bool flag)
    {
        if (!audioSource) return;
        audioSource.mute = flag;
    }
    
    private void SetInteractableButton(bool value)
    {
        if (button)
            button.interactable = value;
    }
}
