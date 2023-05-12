using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    #region Variables
    public enum InteractionTypeEnum
    {
        None,
        RotateObjectLeft,
        RotateObjectRight
    }
    InteractionTypeEnum interactionType = InteractionTypeEnum.None;

    [SerializeField]
    Vector3 m_ObjectRotationSpeed = Vector3.zero;
    [SerializeField]
    float SpeedFactor = 1f;

    public ARSpawnedObject aRSpawnedObject;
   
    [SerializeField]
    GameObject m_tutoPanel;

    [SerializeField]
    List<GameObject> objectsToHideAtStart = new List<GameObject>();
    [SerializeField]
    List<GameObject> objectsToShowAtStart = new List<GameObject>();
    [SerializeField]
    List<GameObject> objectsToHideAtSpawningObject = new List<GameObject>();
    [SerializeField]
    List<GameObject> objectsToShowAtSpawningObject = new List<GameObject>();

    #endregion Variables

    private void OnEnable()
    {       
        DoOnStart();
    }

    private void FixedUpdate()
    {
        if (interactionType != InteractionTypeEnum.None)
        {
            if (interactionType == InteractionTypeEnum.RotateObjectLeft)
            {
                RotateObjectLeft();
            }
            else if (interactionType == InteractionTypeEnum.RotateObjectRight)
            {
                RotateObjectRight();
            }
        }
    }

    #region Rotation
    public void ClickToRotateObjectLeft()
    {
        interactionType = InteractionTypeEnum.RotateObjectLeft;
    }

    void RotateObjectLeft()
    {
        aRSpawnedObject.transform.Rotate(m_ObjectRotationSpeed, Time.fixedDeltaTime * SpeedFactor);
    }

    public void StopRotateObjectLeft()
    {
        interactionType = InteractionTypeEnum.None;
    }

    public void ClickToRotateObjectRight()
    {
        interactionType = InteractionTypeEnum.RotateObjectRight;
    }

    void RotateObjectRight()
    {
        aRSpawnedObject.transform.Rotate(-m_ObjectRotationSpeed, Time.fixedDeltaTime * SpeedFactor);
    }

    public void StopRotateObjectRight()
    {
        interactionType = InteractionTypeEnum.None;
    }
    #endregion Rotation

    #region Manage UI
    public void DoOnStart()
    {
        ShowObjectsAtStart();
        HideObjectsAtStart();
    }

    void ShowObjectsAtStart()
    {
        for (int i = 0; i < objectsToShowAtStart.Count; i++)
        {
            objectsToShowAtStart[i].SetActive(true);
        }
    }

    void HideObjectsAtStart()
    {
        for (int i = 0; i < objectsToHideAtStart.Count; i++)
        {
            objectsToHideAtStart[i].SetActive(false);
        }
    }

    public void DoOnSpawn()
    {
        ShowObjectsAtSpawning();
        HideObjectsAtSpawning();
    }

    void ShowObjectsAtSpawning()
    {
        for (int i = 0; i < objectsToShowAtSpawningObject.Count; i++)
        {
            objectsToShowAtSpawningObject[i].SetActive(true);
        }
    }

    void HideObjectsAtSpawning()
    {
        for (int i = 0; i < objectsToHideAtSpawningObject.Count; i++)
        {
            objectsToHideAtSpawningObject[i].SetActive(false);
        }
    }
   
    public void CloseTutoPanel()
    {
        m_tutoPanel.SetActive(false);
    }
    #endregion Manage UI
}

