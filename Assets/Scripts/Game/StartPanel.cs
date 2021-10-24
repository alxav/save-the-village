using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{

    [SerializeField] private InputField inputFarmer;
    [SerializeField] private InputField inputWheat;

    private WinData winData;
    void Start()
    {
        winData = Win.Instance.GetWinData();
        SetValue(inputFarmer, winData.countFarmer);
        SetValue(inputWheat, winData.countWheat);
    }

    private void SetValue(InputField input, int value)
    {
        if (input)
            input.text = value.ToString();
    }

    public void UpdateWinSettings()
    {
        winData.countFarmer = int.Parse(inputFarmer.text);
        winData.countWheat = int.Parse(inputWheat.text);
        Win.Instance.SetWinData(winData);
    }


}
