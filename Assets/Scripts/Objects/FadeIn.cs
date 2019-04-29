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
        StartCoroutine(FadeInImage(false));
    }

    public IEnumerator FadeInImage(bool fadeInOrOut)
    {
        if (!fadeInOrOut)
        {
            while (fadeImage.color.a > 0)
            {
                fadeImage.color -= new Color(0, 0, 0, 0.15f * Time.deltaTime);
                yield return null;
            }
        }

        else
        {
            while (fadeImage.color.a < 1)
            {
                print("fading");
                fadeImage.color += new Color(0, 0, 0, 0.8f * Time.deltaTime);
                yield return null;
            }

            GetComponent<LoadScene>().LoadCustomScene("Menu_real");
        }
        yield return false;
    }

}
