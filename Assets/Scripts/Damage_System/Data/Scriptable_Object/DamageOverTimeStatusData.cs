using System;
using UnityEngine;
[Serializable]
public class DamageOverTimeStatusData
{
    [SerializeField] private float duration;
    [SerializeField] private float totalDamageOverDuration;
    public float Duration => duration;
    public float TotalDamageOverDuration => totalDamageOverDuration;
    
    public DamageOverTimeStatusData(){}

    public DamageOverTimeStatusData(float duration, float totalDamageOverDuration)
    {
        this.duration = duration;
        this.totalDamageOverDuration = totalDamageOverDuration;
    }
}
