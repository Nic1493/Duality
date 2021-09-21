using UnityEngine;

[CreateAssetMenu]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] IntObject volume;
    public int Volume
    {
        get => volume.value;
        set => volume.value = value;
    }
}