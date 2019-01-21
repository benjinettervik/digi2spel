using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    public GameObject gameController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine(gameController.GetComponent<FadeIn>().FadeInImage(true));
            StartCoroutine(DelayLoadScene());
        }
    }

    IEnumerator DelayLoadScene()
    {
        print("loading scene in 3 seconds");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("menu");
    }
}
