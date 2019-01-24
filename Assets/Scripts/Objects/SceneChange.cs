using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void loadscene(string _sceneName)
    {
        GetComponent<FadeIn>().fadeImage.gameObject.SetActive(true);
        StartCoroutine(GetComponent<FadeIn>().FadeInImage(true));
        StartCoroutine(DelayLoadScene(_sceneName));
    }

    public void quitGame()
    {
        Application.Quit();
    }

    IEnumerator DelayLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
