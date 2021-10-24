using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class InfoCycle: MonoBehaviour
{
    private Text info;

    void Start()
    {
        info = GetComponent<Text>();
        Enemy.CountCycle += SetInfo;
    }

    private void SetInfo(int value)
    {
        info.text = "Волна " + value;
    }
}
