using System;
using System.Collections.Generic;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

public class CsvLevelSystem : MonoBehaviour
{
    public static Task LoadDataLevelFromCSV(Action<KeyValuePair<byte, byte[]>> action = null)
    {
        string fileName = "Level CSV";
        TextAsset csvData = Resources.Load<TextAsset>(fileName);

        if (csvData == null)
        {
            Debug.LogWarning($"File name {fileName} not found");
            return Task.CompletedTask;
        }

        string[] lines = csvData.text.Split('\n');

        for (int i = 2; i < 7; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
                continue;

            string birdsStr = lines[i].Replace('"', ' ').Replace(", ", " ").Replace(",", " ").Trim();
            string[] values = birdsStr.Split(' ');
            byte level = byte.Parse(values[0]);

            ResultSystem.Instance.SetResultRequires(int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

            var birdsQueue = new byte[values.Length - 5];
            for (int j = 5; j < values.Length; j++)
            {
                if (byte.TryParse(values[j], out var number))
                    birdsQueue[j - 5] = number;
            }

            KeyValuePair<byte, byte[]> birdsInLevel = new KeyValuePair<byte, byte[]>(level, birdsQueue);
            action?.Invoke(birdsInLevel);
        }

        return Task.CompletedTask;
    }
}