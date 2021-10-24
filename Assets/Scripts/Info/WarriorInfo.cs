using UnityEngine;
using UnityEngine.UI;

public class WarriorInfo : MonoBehaviour
{
    [SerializeField] private Text text;
    
    void Start()
    {
        Warrior.Count += UpdateCount;
    }

    private void UpdateCount(int count)
    {
        if (text)
            text.text = count.ToString();
    }

}
