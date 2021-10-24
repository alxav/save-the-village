using System;
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
    private Helpers helpers;

    private void Start()
    {
        isPlay = true;
        image = GetComponent<Image>();
        UpdateSprite(spritePause);
        helpers = new Helpers();
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
            helpers.SetTimeScale(1);
            UpdateSprite(spritePause);
            return;
        }
        
        helpers.SetTimeScale(0);
        UpdateSprite(spritePlay);
    }

}
