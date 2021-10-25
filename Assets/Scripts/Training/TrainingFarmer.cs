using UnityEngine;
using UnityEngine.UI;

public class TrainingFarmer : MonoBehaviour
{ 
    [SerializeField] private GameObject buttonObject;
    [SerializeField] private Image reload;
    [SerializeField] private Sprite sprite;

    private Button button;
    private Image image;
    private FarmerData farmerData;

    private void Awake()
    {
        button = buttonObject.GetComponent<Button>();
        image = buttonObject.GetComponent<Image>();
    }

    void Start()
    {
        farmerData = Farmer.Instance.GetFarmerData();
        SetImage();
        AddClickButton();
        Farmer.ProgressTraining += SetReload;
        Wheat.Count += UpdateCountWheat;
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

    private void UpdateCountWheat(int value)
    {
        SetInteractableButton(value >= farmerData.PriceInWheat);
    }

    private void SetReload(float value)
    {
        if (!reload) return;
        reload.fillAmount = value;

        if (value <= 0) reload.enabled = false;

        if (value > 0 && !reload.enabled)
            reload.enabled = true;
    }

    private void SetImage()
    {
        if (image)
            image.sprite = sprite;
    }
    private void AddClickButton()
    {
        if (button)
            button.onClick.AddListener(Farmer.Instance.Training);
    }
    

    private void SetInteractableButton(bool value)
    {
        if (button)
            button.interactable = value;
    }

}
