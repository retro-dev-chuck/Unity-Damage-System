using UnityEngine;

[System.Serializable]
public class StatusBuildUpData
{
    [SerializeField] private bool _resetsAfterTriggering = true;
    [SerializeField] private int triggersAt = 100;
    [SerializeField] private int damageOnTrigger = 0;
    [SerializeField] private bool appliesDamageOverTimeOnTrigger;
    [SerializeField] private DamageOverTimeStatus appliedDamageOverTimeOnTrigger;

    
    public bool ResetsAfterTriggering => _resetsAfterTriggering;
    public int TriggersAt => triggersAt;
    public int DamageOnTrigger => damageOnTrigger;
    public bool AppliesDamageOverTimeOnTrigger => appliesDamageOverTimeOnTrigger;
    public DamageOverTimeStatus damageOverTimeStatus => appliedDamageOverTimeOnTrigger;
}
