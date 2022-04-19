using System.Collections.Generic;
using UnityEngine;

public class BaseDamageableCharacterBuilder
{
    private List<ResistanceData<DamageType>> damageResistances;
    private List<ResistanceData<StatusBuildUp>> statusResistances;

    public BaseDamageableCharacterBuilder()
    {
        damageResistances = new List<ResistanceData<DamageType>>();
        statusResistances = new List<ResistanceData<StatusBuildUp>>();
    }

    public BaseDamageableCharacterBuilder AddDamageResistance(ResistanceData<DamageType> resistanceData)
    {
        if (!damageResistances.Contains(resistanceData))
        {
            damageResistances.Add(resistanceData);
        }
        else
        {
            damageResistances[damageResistances.IndexOf(resistanceData)] = resistanceData;
        }

        return this;
    }
    public BaseDamageableCharacterBuilder AddStatusBuildUpResistance(ResistanceData<StatusBuildUp> resistanceData)
    {
        if (!statusResistances.Contains(resistanceData))
        {
            statusResistances.Add(resistanceData);
        }
        else
        {
            statusResistances[statusResistances.IndexOf(resistanceData)] = resistanceData;
        }

        return this;
    }
    public BaseDamageableCharacter Build()
    {
        return new BaseDamageableCharacter();
    }
}
