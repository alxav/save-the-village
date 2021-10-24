using System;
using System.Collections;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public static Farmer Instance;
    public static event Action<int> Count;
    public static event Action<float> ProgressTraining;

    [SerializeField] private int startCount;
    [SerializeField] private FarmerSetting farmerSetting;

    private FarmerData farmerData;
    private int count;
    private float time;

    private void Awake()
    {
        Instance = this;
        farmerData = farmerSetting.Farmer;
    }

    private void Start()
    {
        SetCount(startCount);
    }

    private IEnumerator TimeoutTraining()
    {
        while (true)
        {
            yield return new WaitForSeconds(0f);
            if (time < farmerData.TimeTraining)
            {
                time += Time.deltaTime;
                ProgressTraining?.Invoke(new Helpers().GetPercentProgress(time, farmerData.TimeTraining));
            }
            else
            {
                time = 0;
                SetCount(1);
                yield break;
            }
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        Count = null;
        ProgressTraining = null;
    }

    public int GetCont() => count;

    public FarmerData GetFarmerData() => farmerData;

    public void SetCount(int value)
    {
        count += value;
        Count?.Invoke(count);
    }

    public void Training()
    {
        time = 0;
        Wheat.Instance.SetCount(-farmerData.PriceInWheat);
        StartCoroutine(TimeoutTraining());
    }
}