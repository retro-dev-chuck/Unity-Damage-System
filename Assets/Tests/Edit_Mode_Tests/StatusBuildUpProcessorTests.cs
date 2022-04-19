using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

public class StatusBuildUpProcessorTests
{
    private StatusBuildUpProcessor _processor;
    private ResistanceData<StatusBuildUp>[] _includedResistanceData;
    private ResistanceData<StatusBuildUp>[] _immuneResistanceData;
    [SetUp]
    public void SetUp()
    {
        CreateResistanceArrays();
        _processor = new StatusBuildUpProcessor(ref _includedResistanceData);
    }

    private void CreateResistanceArrays()
    {
        List<ResistanceData<StatusBuildUp>> resistances = new List<ResistanceData<StatusBuildUp>>();

        for (int i = 0; i < 5; i++)
        {
            var res = new ResistanceData<StatusBuildUp>
            {
                ResistanceType = StatusBuildUp.GetInstance()
            };
            
            res.ResistanceType.Data.TriggersAt = 100;
            res.ResistanceType.Data.ResetsAfterTriggering = true;
            
            resistances.Add(res);
        }

        _includedResistanceData = resistances.ToArray();

        resistances.Clear();

        for (int i = 0; i < 5; i++)
        {
            var res = new ResistanceData<StatusBuildUp>
            {
                ResistanceType = StatusBuildUp.GetInstance()
            };
            resistances.Add(res);
        }

        _immuneResistanceData = resistances.ToArray();
    }

    [Test]
    public void NoBuildUpIfImmuneToAllStatusBuildups()
    {
        List<StatusDamageData> types = new List<StatusDamageData>();
        
        foreach (var resistanceData in _immuneResistanceData)
        {
            types.Add(new StatusDamageData(resistanceData.ResistanceType, Random.Range(1,99)));
        }
        _processor.ProcessDamage(types.ToArray());
        foreach (var type in types)
        {
            Assert.AreEqual(0, _processor.GetBuildUpForStatus(type.AppliedBuildup));
        }
    }

    [Test]
    public void BuildUpOccursForIncludedTypes()
    {
        List<StatusDamageData> types = new List<StatusDamageData>();
        List<int> amounts = new List<int>();
        
        foreach (var resistanceData in _includedResistanceData)
        {
            int buildUpAmount = Random.Range(1, 40);
            amounts.Add(buildUpAmount);
            types.Add(new StatusDamageData(resistanceData.ResistanceType, buildUpAmount));
            
        }
        _processor.ProcessDamage(types.ToArray());
        for (int i = 0; i < types.Count; i++)
        {
            Assert.AreEqual(amounts[i], _processor.GetBuildUpForStatus(types[i].AppliedBuildup));
        }
    }
}
