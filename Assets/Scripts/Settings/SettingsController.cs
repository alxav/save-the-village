using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private WarriorSetting _warriorSetting;
    [SerializeField] private FarmerSetting _farmerSetting;
    [SerializeField] private EnemySetting _enemySetting;

    private Warrior _warrior;
    private Farmer _farmer;
    private Enemy _enemy;
    
    // Start is called before the first frame update
    void Awake()
    {
        _warrior = _warriorSetting.Warrior;
        _farmer = _farmerSetting.Farmer;
        _enemy = _enemySetting.Enemy;
    }

    public Warrior DataWarrior() => _warrior;
    
    public Farmer DataFarmer() => _farmer;
    
    public Enemy DataEnemy() => _enemy;

    

}
