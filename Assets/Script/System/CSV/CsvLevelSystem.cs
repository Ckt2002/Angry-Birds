using System;
using System.Collections.Generic;
using UnityEngine;
using Task = System.Threading.Tasks.Task;


public class CsvLevelSystem : MonoBehaviour
{
    public static Task LoadDataLevelFromCSV(string fileName, Action<KeyValuePair<byte, byte[]>> action = null)
    {
        TextAsset csvData = Resources.Load<TextAsset>(fileName);

        if (csvData == null)
        {
            Debug.Log($"File name {fileName} not found");
            return Task.CompletedTask;
        }

        string[] lines = csvData.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i])) continue;

            string[] values = lines[i].Split(',');
            byte level = byte.Parse(values[0]);

            var birdsNumbers = new byte[values.Length - 1];
            for (int j = 1; j < values.Length; j++)
            {
                if (byte.TryParse(values[0], out byte number))
                {
                    birdsNumbers[j - 1] = number;
                }
            }

            KeyValuePair<byte, byte[]> birdsInLevel = new KeyValuePair<byte, byte[]>(level, birdsNumbers);
            action?.Invoke(birdsInLevel);
        }

        return Task.CompletedTask;
    }
}