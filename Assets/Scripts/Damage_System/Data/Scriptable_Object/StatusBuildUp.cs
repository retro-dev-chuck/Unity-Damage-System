using UnityEngine;

[CreateAssetMenu(fileName = "New Status Build Up", menuName = "Damage System/Status Build Up", order = 2)]
public class StatusBuildUp : ScriptableObject
{
    [SerializeField] private StatusBuildUpData data;
    public StatusBuildUpData Data
    {
        get => data;
        set => data = value;
    }

    public static StatusBuildUp GetInstance()
    {
        var instance = ScriptableObject.CreateInstance<StatusBuildUp>();
        instance.Data = new StatusBuildUpData();
        return instance;
    }
}
