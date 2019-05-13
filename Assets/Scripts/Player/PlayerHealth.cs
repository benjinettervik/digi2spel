using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    GameObject healthBar;

    EditMaterial editMaterial;

    public float currentHealth;
    public int maxhealth = 5;

    void Start()
    {
        currentHealth = maxhealth;
        editMaterial = transform.Find("Knight").GetComponent<EditMaterial>();
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        healthBar.GetComponent<Slider>().value = currentHealth;

        if (currentHealth <= 0)
        {
            //die
            print("dead");
            GetComponent<Animator>().Play("Death");
            StartCoroutine(TakeDamageEffects(true));
        }

        else
        {
            StartCoroutine(TakeDamageEffects(false));
        }
    }

    void Die()
    {
        GetComponent<movement>().enabled = false;
        GetComponent<Attack>().enabled = false;

        foreach (Material material in editMaterial.materials)
        {
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", Color.red * 2);
        }

        StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<FadeIn>().FadeInImage(true));
    }

    IEnumerator TakeDamageEffects(bool die)
    {
        foreach (Material material in editMaterial.materials)
        {
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", Color.red);
        }

        yield return new WaitForSeconds(0.05f);

        foreach (Material material in editMaterial.materials)
        {
            material.DisableKeyword("_EMISSION");
        }

        if (die)
        {
            Die();
        }
    }
}
