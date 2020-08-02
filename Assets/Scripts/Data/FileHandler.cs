using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileHandler
{
    const string fileName = "settings.json";
    static readonly string directoryPath = Path.Combine(UnityEngine.Application.persistentDataPath, "Settings");
    static readonly string filePath = Path.Combine(directoryPath, fileName);

    public static void SaveSettings()
    {
        FileStream fs;

        fs = File.OpenWrite(filePath);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerSettings.Instance);
        fs.Close();
    }

    public static void LoadSettings()
    {
        FileStream fs;
        PlayerSettings ps;

        Directory.CreateDirectory(directoryPath);

        if (File.Exists(filePath)) { fs = File.OpenRead(filePath); }
        else { fs = File.Create(filePath); }

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            ps = bf.Deserialize(fs) as PlayerSettings;
            fs.Close();
        }
        catch (SerializationException)
        {
            ps = new PlayerSettings();
        }

        PlayerSettings.Instance.UpdateSettings(ps);
    }
}