using UnityEngine;

public class BaseDamagableCharacter : MonoBehaviour, IDamageable
{
    public int health { get; set; }
   
    [SerializeField] private DamageType[] resistances;
    
    public void Damage(DamageDealer damageDealer)
    {
    }

    
}
