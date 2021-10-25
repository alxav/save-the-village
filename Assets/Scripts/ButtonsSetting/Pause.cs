using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class Pause : MonoBehaviour
{
    [SerializeField] private Sprite spritePlay;
    [SerializeField] private Sprite spritePause;

    private Image image;
    private bool isPlay;

    private void Start()
    {
        isPlay = true;
        image = GetComponent<Image>();
        UpdateSprite(spritePause);
    }
    
    private void UpdateSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void UpdateStateGame()
    {
        isPlay = !isPlay;

        if (isPlay)
        {
            GameManager.Instance.StartGame();
            UpdateSprite(spritePause);
            return;
        }

        GameManager.Instance.PauseGame();
        UpdateSprite(spritePlay);
    }

}
