using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ActionLog : MonoBehaviour
{
    [Header("UI Settings")]
    public TextMeshProUGUI logText;      // Drag your TMP text here
    public int maxLogs = 10;             // Max number of recent logs to show

    [Header("Log Filter")]
    [Tooltip("Only show logs that contain these keywords. Leave empty to show all.")]
    public string[] keywordsFilter;

    private Queue<string> logQueue = new Queue<string>();

    void Awake()
    {
        if (logText == null)
        {
            Debug.LogWarning("ActionLog: logText is not assigned!");
        }

        // Subscribe to Unity's Debug.Log
        Application.logMessageReceived += HandleLog;
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Only process regular logs (ignore errors/warnings)  
        if (type != LogType.Log)
            return;

        // If keywordsFilter is set, only accept logs containing at least one keyword
        if (keywordsFilter != null && keywordsFilter.Length > 0)
        {
            bool containsKeyword = false;
            foreach (string keyword in keywordsFilter)
            {
                if (logString.Contains(keyword))
                {
                    containsKeyword = true;
                    break;
                }
            }

            if (!containsKeyword)
                return; // Ignore this log
        }

        // Add log to queue
        logQueue.Enqueue(logString);

        // Keep queue size within maxLogs
        while (logQueue.Count > maxLogs)
        {
            logQueue.Dequeue();
        }

        UpdateLogUI();
    }

    private void UpdateLogUI()
    {
        if (logText == null) return;

        logText.text = ""; 
        foreach (string msg in logQueue)
        {
            logText.text += msg + "\n";
        }
    }

    // Optional: manually add a log
    public void AddLog(string message)
    {
        // Apply keyword filter manually
        if (keywordsFilter != null && keywordsFilter.Length > 0)
        {
            bool containsKeyword = false;
            foreach (string keyword in keywordsFilter)
            {
                if (message.Contains(keyword))
                {
                    containsKeyword = true;
                    break;
                }
            }
            if (!containsKeyword) return;
        }

        logQueue.Enqueue(message);

        while (logQueue.Count > maxLogs)
        {
            logQueue.Dequeue();
        }

        UpdateLogUI();
    }
}
