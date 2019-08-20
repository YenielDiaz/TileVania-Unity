using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] int delay = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextSceneAndDelay());
    }

    private IEnumerator LoadNextSceneAndDelay()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(currSceneIndex + 1);
    }
}

