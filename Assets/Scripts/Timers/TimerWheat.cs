using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerWheat : MonoBehaviour
{
    [SerializeField] private Text info;
    [SerializeField] private Image reload;
    
    [SerializeField] private string textInfo;

    private FarmerData farmerData;
    private float time;
    
    
    private void Start()
    {
        SetTextInfo();
        farmerData = Farmer.Instance.GetFarmerData();
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
        if (time < farmerData.TimeoutExtract)
        {
            time += Time.deltaTime;
            var percent = new Helpers().GetPercentProgress(time, farmerData.TimeoutExtract);
            UpdateReload(percent);
            return;
        }

        time = 0;
        Wheat.Instance.SetCount(farmerData.ExtractCountWheat * Farmer.Instance.GetCont());

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
