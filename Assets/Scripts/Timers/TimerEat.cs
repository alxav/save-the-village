using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerEat : MonoBehaviour
{
    [SerializeField] private Text info;
    [SerializeField] private Image reload;
    [SerializeField] private string textInfo;

    private WarriorData warriorData;
    private float time;
    
    private void Start()
    {
        SetTextInfo();
        warriorData = Warrior.Instance.GetWarriorData();
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0f);
            UpdateTime();
        }   
    }

    private void UpdateTime()
    {
        var timeoutEat = warriorData.TimeoutEat;
        if (time < timeoutEat)
        {
            time += Time.deltaTime;
            var percent = new Helpers().GetPercentProgress(time, timeoutEat);
            UpdateReload(percent);
            return;
        }

        time = 0;
        Wheat.Instance.SetCount(-warriorData.EatCountWheat * Warrior.Instance.GetCount());

    }

    private void UpdateReload(float percent)
    {
        if (!reload) return;
        reload.fillAmount = percent;
    }

    private void SetTextInfo()
    {
        if (info)
            info.text = textInfo;
    }
    
    
    
}
