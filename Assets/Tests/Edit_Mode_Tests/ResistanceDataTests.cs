using NUnit.Framework;

public class ResistanceDataTests
{
    private ResistanceData<DamageType> _resistanceData;
    [SetUp]
    public void Setup()
    {
        _resistanceData = new ResistanceData<DamageType>();
    }
    [Test]
    public void ZeroAddedResistanceReturnsUnaffectedDamage()
    {
        _resistanceData.addedResistanceValue = 0f;
        int damage = 100;
        Assert.AreEqual(damage, _resistanceData.GetDamageAfterResistance(damage));
    }

    [Test]
    public void FiftyAddedResistanceReturnsHalfDamage()
    {
        _resistanceData.addedResistanceValue = 50f;
        int damage = 100;
        Assert.AreEqual(damage/2, _resistanceData.GetDamageAfterResistance(damage));
    }
    [Test]
    public void MinusHundredAddedResistanceReturnsDoubleDamage()
    {
        _resistanceData.addedResistanceValue = -100f;
        int damage = 100;
        Assert.AreEqual(damage * 2, _resistanceData.GetDamageAfterResistance(damage));
    }
}
