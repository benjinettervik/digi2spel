using System.Collections;
using UnityEngine;

public class Chest : Interactable
{
    Animator anim;
    BoxCollider boxColl;
    GameObject canvas;
    GameObject cam;
    public GameObject objectToSpawn;


    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        boxColl = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
    }

    public override void OnClick()
    {
        anim.Play("ChestOpen");

        SpawnObject();

        //eftersom kistan expanderar när man öppnar den måste box collidern bli större
        boxColl.center = new Vector3(boxColl.center.x, boxColl.center.y, -1.3f);
        boxColl.size = new Vector3(boxColl.size.x, boxColl.size.y, 5);
    }

    void SpawnObject()
    {
        GameObject objectToSpawnSprite;
        var objectToSpawnVar = Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity);
        objectToSpawnSprite = objectToSpawnVar.transform.Find("ObjectSprite").gameObject;
        objectToSpawnSprite.transform.SetParent(canvas.transform);
        objectToSpawnSprite.transform.rotation = transform.rotation;
        StartCoroutine(SetSpritePosition(objectToSpawnSprite));
    }

    float timeSinceSpawned;
    IEnumerator SetSpritePosition(GameObject objectToSetPos)
    {
        objectToSetPos.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        objectToSetPos.SetActive(true);

        while (timeSinceSpawned < 1)
        {
            timeSinceSpawned += Time.deltaTime;
            objectToSetPos.transform.position = cam.GetComponent<Camera>().WorldToScreenPoint(transform.position);
            yield return false;
        }

        objectToSetPos.SetActive(false);

    }
}
