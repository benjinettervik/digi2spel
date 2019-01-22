using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPopUpText : MonoBehaviour
{
    #region DefaultTexts
    [TextArea]
    public string buttonDisabled;
    #endregion
    public Text textObject;
    public GameObject textPos;
    Camera camera;
    Outline outline;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        outline = textObject.GetComponent<Outline>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Think(buttonDisabled);
        }
    }

    public void Think(string text)
    {
        StopAllCoroutines();
        textObject.color = Color.white;
        outline.effectColor = Color.black;
        textObject.gameObject.SetActive(true);
        textObject.text = "";
        StartCoroutine(DisplayTextGradually(text));
    }

    IEnumerator DisplayTextGradually(string text)
    {
        char[] letters = text.ToCharArray();

        foreach (char letter in letters)
        {
            textObject.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(1);

        while (textObject.color.a > 0)
        {
            textObject.color -= new Color(0, 0, 0, Time.deltaTime * 2);
            outline.effectColor -= new Color(0, 0, 0, Time.deltaTime * 2);
            yield return false;
        }
        textObject.gameObject.SetActive(false);
    }
}
