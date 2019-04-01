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
    Camera cam;
    Outline outline;

    public bool disablePopUp;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (!disablePopUp)
            outline = textObject.GetComponent<Outline>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Think(buttonDisabled);
        }
    }

    public void Think(string _text)
    {
        StopAllCoroutines();
        textObject.color = Color.white;
        outline.effectColor = Color.black;
        SetTextAreaWidth(_text, 100, 30);
        textObject.text = "";
        StartCoroutine(DisplayTextGradually(_text));
        textObject.gameObject.SetActive(true);
    }

    IEnumerator DisplayTextGradually(string _text)
    {
        char[] letters = _text.ToCharArray();

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

    void SetTextAreaWidth(string _text, float x_offset, float y_offset)
    {
        string currentMessage = _text;
        if (currentMessage == buttonDisabled)
        {
            textObject.rectTransform.sizeDelta = new Vector2(x_offset, y_offset);
        }
    }
}
