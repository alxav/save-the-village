using UnityEngine;
using UnityEngine.UI;

public class TrainingWarrior : MonoBehaviour
{ 
    [SerializeField] private GameObject buttonObject;
    [SerializeField] private Image reload;
    [SerializeField] private Sprite sprite;

    private Button button;
    private Image image;
    private WarriorData warriorData;

    private void Awake()
    {
        button = buttonObject.GetComponent<Button>();
        image = buttonObject.GetComponent<Image>();
    }

    void Start()
    {
        warriorData = Warrior.Instance.GetWarriorData();
        SetImage();
        AddClickButton();
        Warrior.ProgressTraining += SetReload;
        Wheat.Count += UpdateCountWheat;
    }

    private void UpdateCountWheat(int value)
    {
        SetInteractableButton(value >= warriorData.PriceInWheat);
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
            button.onClick.AddListener(Warrior.Instance.Training);
    }
    

    private void SetInteractableButton(bool value)
    {
        if (button)
            button.interactable = value;
    }

}
