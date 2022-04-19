using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Type", menuName = "Damage System/Damage Type", order = 0)]
public class DamageType : ScriptableObject
{
    public static DamageType GetInstance()
    {
        return ScriptableObject.CreateInstance<DamageType>();
    }
}
