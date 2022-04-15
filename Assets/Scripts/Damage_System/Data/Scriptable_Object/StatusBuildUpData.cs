using UnityEngine;

[System.Serializable]
public class StatusBuildUpData
{
    [SerializeField] private bool _resetsAfterTriggering = true;
    [SerializeField] private int triggersAt = 100;
    [SerializeField] private int damageOnTrigger = 0;
    [SerializeField] private bool appliesStatusEffect;
    [SerializeField] private DamageOverTimeStatus appliedDoTStatusOnTrigger;


    public bool ResetsAfterTriggering => _resetsAfterTriggering;
    public int TriggersAt => triggersAt;
    public int DamageOnTrigger => damageOnTrigger;
    public bool AppliesStatusEffect => appliesStatusEffect;
    public DamageOverTimeStatus damageOverTimeStatus => appliedDoTStatusOnTrigger;
}
