using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FPSLogger : MonoBehaviour
{
    private string filePath; // Path to the CSV file
    private float timer = 0.0f; // Timer to track elapsed time
    private bool isLogging = true; // Flag to control logging
    private List<float> fpsValues = new List<float>(); // List to store FPS values
    private const float loggingDuration = 15.0f; // Duration for logging FPS

    void Start()
    {
        // Define the file path for the CSV file in the project root
        filePath = Directory.GetParent(Application.dataPath) + "/fps_data.csv";

        // Check if the file exists and create a header if it doesn't
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("Run,Average FPS,Minimum FPS,Maximum FPS,Median FPS");
            }
        }
    }

    void Update()
    {
        if (!isLogging)
            return;

        // Increment the timer
        timer += Time.deltaTime;

        // Calculate FPS
        float fps = 1.0f / Time.deltaTime;

        // Store FPS in the list
        fpsValues.Add(fps);

        // Stop logging after the defined duration
        if (timer >= loggingDuration)
        {
            isLogging = false; // Stop logging
            WriteResultsToFile();
        }
    }

    private void WriteResultsToFile()
    {
        // Calculate FPS statistics
        float averageFPS = CalculateAverage(fpsValues);
        float minFPS = Mathf.Min(fpsValues.ToArray());
        float maxFPS = Mathf.Max(fpsValues.ToArray());
        float medianFPS = CalculateMedian(fpsValues);

        // Write results to the file
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{System.DateTime.Now}, {averageFPS:F2}, {minFPS:F2}, {maxFPS:F2}, {medianFPS:F2}");
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

    private float CalculateMedian(List<float> values)
    {
        values.Sort();
        int count = values.Count;
        if (count % 2 == 0)
        {
            // Even number of elements
            return (values[count / 2 - 1] + values[count / 2]) / 2.0f;
        }
        else
        {
            // Odd number of elements
            return values[count / 2];
        }
    }
}

