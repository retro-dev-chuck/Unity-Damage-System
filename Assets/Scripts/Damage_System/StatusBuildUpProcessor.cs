using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class StatusBuildUpProcessor
{
    private ResistanceData<StatusBuildUp>[] _statusResistances;
    private Dictionary<StatusBuildUp, ResistanceData<StatusBuildUp>> _statusResistanceDataDict;
    public Dictionary<StatusBuildUp, int> appliedStatusBuildUps { get; }

    public Action<StatusBuildUp> onStatusEffectTrigger;
    
    public StatusBuildUpProcessor(ref ResistanceData<StatusBuildUp>[] statusResistances)
    {
        Assert.IsNotNull(statusResistances);
        _statusResistances = statusResistances;
        appliedStatusBuildUps = new Dictionary<StatusBuildUp, int>();
        _statusResistanceDataDict = new Dictionary<StatusBuildUp, ResistanceData<StatusBuildUp>>();
        
        foreach (var resistance in _statusResistances)
        {
            if (!_statusResistanceDataDict.ContainsKey(resistance.getResistanceType))
            {
                _statusResistanceDataDict.Add(resistance.getResistanceType, resistance);
                appliedStatusBuildUps.Add(resistance.getResistanceType, 0);
            }
        }
    }

    public void ProcessDamage(StatusDamageData[]  statusBuildUps)
    {
        foreach (var statusDamageData in statusBuildUps)
        {
            var buildup = statusDamageData.AppliedBuildup;
            
            Assert.IsNotNull(buildup);
           
            if(!appliedStatusBuildUps.ContainsKey(buildup) 
               || !_statusResistanceDataDict.ContainsKey(buildup)) continue;

            float damageToApply = _statusResistanceDataDict[buildup].GetDamageAfterResistance(statusDamageData.Amount);
            appliedStatusBuildUps[buildup] += Mathf.CeilToInt(damageToApply);
            
            if (appliedStatusBuildUps[buildup] >= buildup.Data.TriggersAt)
            {
                if(buildup.Data.ResetsAfterTriggering){
                    appliedStatusBuildUps[buildup] = 0;
                }
                onStatusEffectTrigger?.Invoke(buildup);
            }

        }
    }
}
