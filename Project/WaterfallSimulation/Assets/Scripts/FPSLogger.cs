using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FPSLogger : MonoBehaviour
{
    private string filePath; 
    private float timer = 0.0f; 
    private bool isLogging = true; 
    private List<float> fpsValues = new List<float>(); 
    private const float loggingDuration = 15.0f; 

    void Start()
    {
     
        filePath = Directory.GetParent(Application.dataPath) + "/fps_data.csv";

        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("Run,Average FPS");
            }
        }
    }

    void Update()
    {
        if (!isLogging)
            return;

        timer += Time.deltaTime;
        float fps = 1.0f / Time.deltaTime;
        fpsValues.Add(fps);
        if (timer >= loggingDuration)
        {
            isLogging = false; 
            WriteResultsToFile();
        }
    }
    private void WriteResultsToFile()
    {
        float averageFPS = CalculateAverage(fpsValues);
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{System.DateTime.Now}, {averageFPS:F2}");
        }
        Debug.Log($"FPS results written to {filePath}");
    }

    private float CalculateAverage(List<float> values)
    {
        float sum = 0.0f;
        foreach (float value in values)
        {
            sum += value;
        }
        return sum / values.Count;
    }

}


