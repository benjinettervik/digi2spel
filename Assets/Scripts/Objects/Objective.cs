using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    //checka denna i inspektorn så blir det lättare att hålla koll på vad som är vad
    public bool notActualObjective;
    public bool isCompleted;
    [HideInInspector]
    public bool isInTrigger;
    [Header("Varje rum har en egen room controller")]
    public GameObject roomController;
    [Header("Alla objekt som DETTA objektet ska aktivera")]
    public GameObject[] objectivesToActivate;
    public GameObject[] objectivesToDeActivate;

    public GameObject popUpText;
    [HideInInspector]
    public GameObject currentText;

    [HideInInspector]
    public GameObject player;

    [HideInInspector]
    public PlayerPopUpText playerInteract;

    [Header("Om detta objekt inte ska vara aktiverat innan något annat har blivit aktiverat, lägg de(t) andra objekten här")]
    public Dictionary<GameObject, bool> gameObjectsToBeActivatedBy = new Dictionary<GameObject, bool>();

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInteract = player.GetComponent<PlayerPopUpText>();

        foreach (GameObject objective in objectivesToActivate)
        {
            objective.GetComponent<Objective>().gameObjectsToBeActivatedBy.Add(gameObject, false);
        }

        if (gameObjectsToBeActivatedBy.Count > 0)
        {
            //ActionToBePerformed(false);
        }
    }

    public virtual void PerformAction()
    {

    }

    public virtual void DisperformAction()
    {

    }

    //döper det till dessa retarded namn för jag glömmer nästan vad jag håller på med
    public void CheckIfAllObjectsHaveActivatedCurrentObject(bool enable, GameObject activatingObject)
    {
        if (gameObjectsToBeActivatedBy.ContainsKey(activatingObject))
        {
            gameObjectsToBeActivatedBy[activatingObject] = true;
        }

        foreach (KeyValuePair<GameObject, bool> entry in gameObjectsToBeActivatedBy)
        {
            if (entry.Value == false)
            {
                return;
            }
        }

        ActionToBePerformed(enable);
    }

    public virtual void ActionToBePerformed(bool enable)
    {

    }

    public void ActivateObjects()
    {
        foreach (GameObject objective in objectivesToActivate)
        {
            objective.GetComponent<Objective>().CheckIfAllObjectsHaveActivatedCurrentObject(true, gameObject);
        }
    }

    public void DeActivateObjects()
    {
        foreach (GameObject objective in objectivesToDeActivate)
        {
            objective.GetComponent<Objective>().ActionToBePerformed(false);
            //inte optimalt och fint
            objective.GetComponent<Objective>().gameObjectsToBeActivatedBy[gameObject] = false;
        }
    }

    public virtual void DisplayText(GameObject _linkedObject, string _text, Vector3 _direction, int _fontIncreasement)
    {
        currentText = Instantiate(popUpText);

        currentText.transform.GetChild(0).GetComponent<PopUpText>().InstantiateSetup(_linkedObject, _text, _direction);
        currentText.transform.GetChild(0).GetComponent<Text>().fontSize += _fontIncreasement;
    }

    public virtual void DestroyText()
    {
        Destroy(currentText);
    }
}