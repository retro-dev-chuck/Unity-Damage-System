using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

public class DamageProcessorTests
{
    private DamageProcessor _processor;
    private ResistanceData<DamageType>[] _includedResistanceData;
    private ResistanceData<DamageType>[] _immuneResistanceData;
    [SetUp]
    public void SetUp()
    {
        CreateResistanceArrays();
        _processor = new DamageProcessor(ref _includedResistanceData);
    }

    private void CreateResistanceArrays()
    {
        List<ResistanceData<DamageType>> resistances = new List<ResistanceData<DamageType>>();

        for (int i = 0; i < 5; i++)
        {
            var res = new ResistanceData<DamageType>
            {
                ResistanceType = DamageType.GetInstance()
            };
            resistances.Add(res);
        }

        _includedResistanceData = resistances.ToArray();

        resistances.Clear();

        for (int i = 0; i < 5; i++)
        {
            var res = new ResistanceData<DamageType>
            {
                ResistanceType = DamageType.GetInstance()
            };
            resistances.Add(res);
        }

        _immuneResistanceData = resistances.ToArray();
    }

    [Test]
    public void HealthReturnedIsZeroIfImmuneToDamageType()
    {
        List<DamageData> types = new List<DamageData>();
        foreach (var immuneRes in _immuneResistanceData)
        {
            types.Add(new DamageData(immuneRes.ResistanceType, Random.Range(100,500)));
        }

        int damageTakenToHp = _processor.GetDamageDealtToHealth(types.ToArray());
        Assert.AreEqual(0 , damageTakenToHp);
    }

    [Test]
    public void HealthReturnedIsSumIfNotImmuneToDamageType()
    {
        List<DamageData> types = new List<DamageData>();
        int totalDamage = 0;
        
        foreach (var res in _includedResistanceData)
        {
            int amount = Random.Range(100, 500);
            totalDamage += amount;
            types.Add(new DamageData(res.ResistanceType, amount));
        }

        int damageTakenToHp = _processor.GetDamageDealtToHealth(types.ToArray());
        Assert.AreEqual(totalDamage , damageTakenToHp);
    }
}
