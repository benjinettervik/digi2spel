using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Canvas mainCanvas;
    public List<GameObject> keys = new List<GameObject>();
    public Image[] keyImages;
    public int keyAmount;
    int currentKey = 0;

    private void Start()
    {
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    public void AddKey(GameObject _key)
    {
        keys.Add(_key);
        keyImages[currentKey].gameObject.SetActive(true);
        currentKey++;
    }
}
