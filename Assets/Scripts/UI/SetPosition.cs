using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPosition : MonoBehaviour
{
    //detta skriptet är dumt men hade nåt konstigt bug
    GameObject textPos;
    GameObject player;
    Camera cam;

    private void Start()
    {
        StartCoroutine(SetOpacity());
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        textPos = player.transform.Find("Textpos").gameObject;
    }

    private void Update()
    {
        transform.position = cam.WorldToScreenPoint(textPos.transform.position);
    }

    //Detta är för att man ser texten flyttas från mitten av skärmen till spelarens huvud i någon split-sekund
    IEnumerator SetOpacity()
    {
        yield return new WaitForSeconds(0.01f);
        GetComponent<Text>().color = Color.white;
    }
    private void OnDisable()
    {
        GetComponent<Text>().color = new Color(Color.white.a, Color.white.b, 0);
    }
}

