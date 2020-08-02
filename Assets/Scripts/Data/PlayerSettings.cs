[System.Serializable]
public class PlayerSettings
{
    public static readonly PlayerSettings Instance = new PlayerSettings();

    public int volume;
    public float repeatDelay;

    public PlayerSettings()
    {
        volume = 10;
        repeatDelay = 10;
    }

    public void UpdateSettings(PlayerSettings ps)
    {
        volume = ps.volume;
        repeatDelay = ps.repeatDelay;
    }
}