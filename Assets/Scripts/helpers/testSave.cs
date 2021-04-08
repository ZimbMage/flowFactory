using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class testSave 
{



    public static void save(List<string> card) 
    {

        FileStream fs = new FileStream("save.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, card);
        fs.Close();

    }

    public static List<string> load() 
    {
        using (Stream stream = File.Open("save.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            return (List<string>)bformatter.Deserialize(stream);
        }
    }

}
