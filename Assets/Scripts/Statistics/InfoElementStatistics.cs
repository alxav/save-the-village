using UnityEngine;
using UnityEngine.UI;

public class InfoElementStatistics : MonoBehaviour
{
    [SerializeField] private Text info;
    [SerializeField] private Text value;

    public void SetData(DataStatistics data)
    {
        SetText(info, data.text);
        SetText(value, data.value.ToString());
    }

    private void SetText(Text text, string value)
    {
        if (text)
            text.text = value;
    }

}
