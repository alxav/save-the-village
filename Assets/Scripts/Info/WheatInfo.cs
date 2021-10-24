using UnityEngine;
using UnityEngine.UI;

public class WheatInfo : MonoBehaviour
{
    [SerializeField] private Text text;
    
    void Start()
    {
        Wheat.Count += UpdateCount;
    }

    private void UpdateCount(int count)
    {
        if (text)
            text.text = count.ToString();
    }

}
