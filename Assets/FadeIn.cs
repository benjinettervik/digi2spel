using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    public Image fadeImage;

    private void Start()
    {
        StartCoroutine(FadeInImage());
    }

    IEnumerator FadeInImage()
    {
        while (fadeImage.color.a > 0)
        {
            fadeImage.color -= new Color(0, 0, 0, 0.15f * Time.deltaTime);
            yield return null;
        }

        yield return false;
    }

}
