using UnityEngine;

[CreateAssetMenu]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] IntObject volume;
    [SerializeField] IntObject levelCount;

    public int Volume
    {
        get => volume.value;
        set => volume.value = value;
    }

    public int LevelCount
    {
        get => levelCount.value;
        set => levelCount.value = value;
    }
}