using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingBuildIndex;

    private void Awake()
    {
        //make sure object persists
        int scenePersistCount = FindObjectsOfType<ScenePersist>().Length;
        if (scenePersistCount > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    }

    void Start()
    {
        startingBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        int currBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currBuildIndex != startingBuildIndex)
        {
            Destroy(gameObject);
        }
    }
}
