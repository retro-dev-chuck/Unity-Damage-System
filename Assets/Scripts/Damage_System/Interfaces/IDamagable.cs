public interface IDamageable
{
    public int health { get; set; }
    void Damage(DamageDealer damageDealer);
}
