using System.Collections;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static Win Instance;
    [SerializeField] private WinSetting winSetting;

    private WinData winData;
    private int countFarmer;
    private int countWheat;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        winData = winSetting.WinData;
        Farmer.Count += GetCountFarmer;
        Wheat.Count += GetCountWheat;
    }

    private void GetCountWheat(int value) => countWheat = value;

    private void GetCountFarmer(int value) => countFarmer = value;

    public WinData GetWinData() => winData;

    public void SetWinData(WinData data)
    {
        winData = data;
        StartCoroutine(IsWin());
    }

    
    private IEnumerator IsWin()
    {
      
        while (true)
        {
            yield return new WaitForSeconds(0f);
            if (countWheat >= winData.countWheat && countFarmer >= winData.countFarmer)
            {
                GameManager.Instance.WinGame();
                yield break;
            }
        }
    }
    
}