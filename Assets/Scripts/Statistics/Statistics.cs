using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    [SerializeField] private InfoElementStatistics infoElementStatistics;
    [SerializeField] private GameObject container;

    private List<DataStatistics> listStatistic = new List<DataStatistics>();

    private void Start()
    {
        AddList();
        GenerateElements();
    }

    private void GenerateElements()
    {
        listStatistic.ForEach(GenerateElement);
    }
    
    private void GenerateElement(DataStatistics data)
    {
        var clone = Instantiate(infoElementStatistics, container.transform);
        clone.SetData(data);
    }

    private void AddList()
    {
        var countCycle = Enemy.Instance.GetCountCycle();
        AddElement( "Количество пережитых набегов:" , countCycle-1); // 1 отнимаем так как мы текущую волну не пережили.
        
        var allCountWheat = Wheat.Instance.GetAllCont();
        AddElement( "Количество произведенного зерна:" , allCountWheat);
        
        var countWarriorTraining = Warrior.Instance.GetCountTraining();
        AddElement( "Количество натренированных воинов:" , countWarriorTraining);

    }

    private void AddElement(string info, int value)
    {
        var dataStatistic = new DataStatistics();
        dataStatistic.text = info;
        dataStatistic.value = value;
        listStatistic.Add(dataStatistic);
    }

}

