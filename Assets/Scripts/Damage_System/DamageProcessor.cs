using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DamageProcessor 
{
    private ResistanceData<DamageType>[] _damageResistances;
    private Dictionary<DamageType, ResistanceData<DamageType>> _resistanceDataDict;

    public DamageProcessor(ref ResistanceData<DamageType>[] damageResistances)
    {
        Assert.IsNotNull(damageResistances);
        _damageResistances = damageResistances;
        _resistanceDataDict = new Dictionary<DamageType, ResistanceData<DamageType>>();

        foreach (var resistance in _damageResistances)
        {
            if (!_resistanceDataDict.ContainsKey(resistance.ResistanceType))
            {
                _resistanceDataDict.Add(resistance.ResistanceType, resistance);
            }
        }
    }

    public int GetDamageDealtToHealth(DamageData[] damages)
    {
        float totalDamageToHealth = 0f;
        //We assume if it's not on the list, we have immunity to the damage type
        foreach (var damage in damages)
        {
            if (damage.Amount < 1f) continue;
            var dmgType = damage.GetDamageType;
            if (_resistanceDataDict.ContainsKey(dmgType))
            {
                totalDamageToHealth += _resistanceDataDict[dmgType].GetDamageAfterResistance(damage.Amount);
            }
        }

        return Mathf.CeilToInt(totalDamageToHealth);
    }
}
