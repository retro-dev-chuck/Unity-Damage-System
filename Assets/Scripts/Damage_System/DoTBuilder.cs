public class DoTBuilder
{
    private float _duration;
    private float _totalDamageOverDuration;

    public DoTBuilder WithDuration(float duration)
    {
        _duration = duration;
        return this;
    }
    
    public DoTBuilder WithTotalDamageOverDuration(float totalDamageOverDuration)
    {
        _totalDamageOverDuration = totalDamageOverDuration;
        return this;
    }

    private DamageOverTimeStatus Build()
    {
        var dotStatus = DamageOverTimeStatus.CreateInstance();

        var dotsData = new DamageOverTimeStatusData(_duration, _totalDamageOverDuration);

        dotStatus.SetData(dotsData);
        
        return dotStatus;
    }
    public static implicit operator DamageOverTimeStatus(DoTBuilder builder)
    {
        return builder.Build();
    }
}
