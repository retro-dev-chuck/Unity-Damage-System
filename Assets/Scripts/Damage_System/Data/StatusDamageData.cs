using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class StatusDamageData
{
    [SerializeField] private StatusBuildUp appliedBuildUp;
    [SerializeField] private int amount;

    public StatusDamageData(StatusBuildUp appliedBuildUp, int amount)
    {
        this.appliedBuildUp = appliedBuildUp;
        this.amount = amount;
    }

    [CanBeNull] public StatusBuildUp AppliedBuildup => appliedBuildUp;
    public int Amount => amount;
}
