﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    public float speed;
    public float health;
    public float damage;
    public float sightRange;
    public float engagementDistance;

    public bool dontMove = true;
    public bool isMoving;
    float timeSinceLastSpotted;
    [HideInInspector]
    public bool playerIsSpotted = false;
    [HideInInspector]
    public Vector3 playerLastSpotted = Vector3.zero;
    public Transform desigPos;

    [HideInInspector]
    public Animator anim;

    public EditMaterial editMaterial;

    public GameObject hitPosition;

    [HideInInspector]
    public GameObject player;
    public GameObject healthBarObj;
    GameObject healthBar;

    public virtual void Update()
    {
        SetHealthBarVisibility();
    }

    private void FixedUpdate()
    {
        SpotPlayer();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.GetComponent<Slider>().value = health;

        if (health <= 0)
        {
            StartCoroutine(TakeDamageEffects(true));
        }
        else
        {
            StartCoroutine(TakeDamageEffects(false));
        }
    }

    public void SpotPlayer()
    {
        timeSinceLastSpotted += Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < sightRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, (player.transform.position - transform.position), out hit, sightRange, 15))
            {
                if (hit.collider.tag == "PlayerEnemyTrigger")
                {
                    print("hitting");
                    playerLastSpotted = hit.collider.transform.root.position;
                    playerIsSpotted = true;
                    dontMove = false;

                    //detta är för att förhindra att den hackar mycket när den ska kolla på spelaren, för av någon anledning träffar rayen spelaren typ varannan frame  
                    timeSinceLastSpotted = 0;
                }
                else if (timeSinceLastSpotted > 3)
                {
                    playerIsSpotted = false;
                }

            }

            Debug.DrawLine(Vector3.up / 1.5f + transform.position, Vector3.up / 1.5f + transform.position + (player.transform.position - transform.position));
        }
    }

    void Die()
    {
        Destroy(healthBar);
        Destroy(gameObject);
    }

    public void SetupHealthBar()
    {
        healthBar = Instantiate(healthBarObj);
        healthBar.GetComponent<HealthBar>().Setup(gameObject, Vector3.up * 2);
    }

    public void SetHealthBarVisibility()
    {
        if (playerIsSpotted)
        {
            healthBar.SetActive(true);
        }
        else
        {
            //healthBar.SetActive(false);
        }
    }

    //när den blir träffad
    IEnumerator RotateBack(bool die)
    {
        float timeSinceStart = 0;

        Quaternion lookRot = Quaternion.LookRotation(hitPosition.transform.position - transform.position);

        while (timeSinceStart < 0.5f)
        {
            timeSinceStart += Time.unscaledDeltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, 1f * Time.unscaledDeltaTime);

            yield return false;
        }
    }

    IEnumerator TakeDamageEffects(bool die)
    {
        StartCoroutine(RotateBack(die));

        foreach (Material material in editMaterial.materials)
        {
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", Color.red);
        }

        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(0.3f);

        Time.timeScale = 1;

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
