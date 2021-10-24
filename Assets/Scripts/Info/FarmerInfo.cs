using UnityEngine;
using UnityEngine.UI;

public class FarmerInfo : MonoBehaviour
{
    [SerializeField] private Text text;
    
    void Start()
    {
        Farmer.Count += UpdateCount;
    }

    private void UpdateCount(int count)
    {
        if (text)
            text.text = count.ToString();
    }

}
