using System;
using System.Collections.Generic;
using Script.System;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem Instance;

    [Min(1), SerializeField] private int level;
    [SerializeField] private bool isTesting;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (!isTesting)
            LoadLevel();
    }

    [ContextMenu("LoadLevel")]
    public void Load()
    {
        if (isTesting)
            LoadLevel();
    }

    public void LoadLevel()
    {
        LoadBirdSystem.Instance.Load(level);
        _ = LoadLevelData.Instance.LoadAsync(level);
    }
}