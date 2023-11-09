using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextLevelName;
    public float delayBeforeLoad = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TryLoadNextLevel();
        }
    }

    private void TryLoadNextLevel()
    {
        StartCoroutine(LoadNextLevelWithDelay());
    }

    private IEnumerator LoadNextLevelWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);

        SceneManager.LoadScene(nextLevelName);
    }
}
