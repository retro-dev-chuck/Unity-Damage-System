using UnityEngine;

[CreateAssetMenu(fileName = "New Damage over Time Status", menuName = "Damage System/Damage over Time Status", order = 1)]
public class DamageOverTimeStatus : ScriptableObject
{
    [SerializeField] private DamageOverTimeStatusData data;
}
