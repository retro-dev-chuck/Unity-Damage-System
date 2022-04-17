using UnityEngine;

[CreateAssetMenu(fileName = "New Status Build Up", menuName = "Damage System/Status Build Up", order = 2)]
public class StatusBuildUp : ScriptableObject
{
    [SerializeField] private StatusBuildUpData data;
    public StatusBuildUpData Data => data;
}
