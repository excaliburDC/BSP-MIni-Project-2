using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
   public static void  SavePlayer(PlayerPrefs player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + " /player.fun";
        //FileStream stream = new FileStream(path, FileMode.create);
        //PlayerData data = new PlayerData(player);
    }
}
