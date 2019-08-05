using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTXT : MonoBehaviour
{
    TextAsset _text;
    public string[,] data;



    public string[,] Read()
    {
        _text = Resources.Load("map_Stage1") as TextAsset;
        string str = _text.text;
        string[] row = str.Split('\n');
        data = new string[row.Length, row[0].Split(',').Length];
        for (int i = 0; i < row.Length; i++)
        {
            //row[i] = row[i].Substring(0, row[i].Length - 1);
            //row[i].Replace(@"\r", "");
            row[i] = row[i].TrimEnd((char[])"\r".ToCharArray());
            string debugstr = "";
            string[] tile = row[i].Split(',');
            for (int j = 0; j < tile.Length; j++)
            {
                //if (tile[j].Length > 1)
                //    tile[j] = tile[j].Substring(0, tile[j].Length - 1);
                //tile[j].Replace("\r","");
                data[i, j] = tile[j];
                debugstr += data[i, j];
            }
               // Debug.Log(debugstr);
        }
        return data;
    }

}
