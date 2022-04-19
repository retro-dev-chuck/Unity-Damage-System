using System;
using UnityEngine;

[Serializable]
public class StatusBuildUpData
{
    [SerializeField] private bool resetsAfterTriggering = true;
    [SerializeField] private int triggersAt = 100;
    [SerializeField] private int damageOnTrigger = 0;
    [SerializeField] private bool appliesDamageOverTimeOnTrigger;
    [SerializeField] private DamageOverTimeStatus appliedDamageOverTimeOnTrigger;

    
    public bool ResetsAfterTriggering
    {
        get => resetsAfterTriggering;
        set => resetsAfterTriggering = value;
    }

    public int TriggersAt
    {
        get => triggersAt;
        set => triggersAt = value;
    }

    public int DamageOnTrigger
    {
        get => damageOnTrigger;
        set => damageOnTrigger = value;
    }

    public bool AppliesDamageOverTimeOnTrigger
    {
        get => appliesDamageOverTimeOnTrigger;
        set => appliesDamageOverTimeOnTrigger = value;
    }

    public DamageOverTimeStatus damageOverTimeStatus
    {
        get => appliedDamageOverTimeOnTrigger;
        set => appliedDamageOverTimeOnTrigger = value;
    }
}
