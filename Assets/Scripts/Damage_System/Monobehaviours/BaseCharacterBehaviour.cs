using UnityEngine;

public class BaseCharacterBehaviour : MonoBehaviour
{
    [SerializeField] private int initialHealth = 50;
    [SerializeField] private BaseDamageableCharacter damageableCharacter;
    private void Awake()
    {
        damageableCharacter.health = initialHealth;
        damageableCharacter.Initialize();
    }

    public void Damage(DamageDealer damageDealer)
    {
        damageableCharacter.Damage(damageDealer);
    }

    public int GetHealth()
    {
        return damageableCharacter.health;
    }
}
