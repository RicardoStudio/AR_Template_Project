using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSpawnedObject : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Vector3 m_spawnRotationOffset = Vector3.zero;

    InteractionManager interactionManager;
    #endregion Variables

    #region Init
    private void OnEnable()
    {
        ApplySpawnOffsets();
        ConnectToInteractionManager();
        DoOnSpawn();
    }
    
    void ConnectToInteractionManager()
    {
        interactionManager = FindAnyObjectByType<InteractionManager>();
        interactionManager.aRSpawnedObject= this;
    }
    #endregion Init

    #region Spawn Offsets
    private void ApplySpawnOffsets()
    {
        RotateObjectAtSpawn();
    }

    void RotateObjectAtSpawn()
    {
        transform.Rotate(m_spawnRotationOffset);
    }

    void DoOnSpawn()
    {
        interactionManager.DoOnSpawn();
    }
    #endregion Spawn Offsets
}
