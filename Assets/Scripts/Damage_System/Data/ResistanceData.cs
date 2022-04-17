using System;
using UnityEngine;

[Serializable]
public class ResistanceData<T>
{
    [SerializeField] private T type;

    public T getResistanceType => type;
    private float _baseResistanceValue = 100f;
    public float addedResistanceValue { get; set; }
    //100: 0 damage reduction 90: 10 percent more damage taken 110: 10 percent less damage taken
    public int GetDamageAfterResistance(int damage)
    {
        return Mathf.RoundToInt((1 - (addedResistanceValue / _baseResistanceValue)) * damage);
    }
    
}
