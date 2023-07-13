using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformManager : MonoBehaviour
{
    [SerializeField] private List<Transform> goodPlayerPositions;
    [SerializeField] private List<Transform> badPlayerPositions;

    [SerializeField] private Camera mainCamera;

    private Transform playerActualTransform;

    private void Start()
    {
        GameManager.FlowTheGame += SetPlayerPositionBasedOnTurnAndKind;
    }
    
    void SetPlayerPositionBasedOnTurnAndKind()
    {
        bool isPlayerGood = GameManager.ReturnPlayerRole();
        if (isPlayerGood)
        {
            playerActualTransform = goodPlayerPositions[NPCTurnManager.GetNPCNumber()];
            SetMainCameraTransform();
        }
        else if (!isPlayerGood)
        {
            playerActualTransform = badPlayerPositions[NPCTurnManager.GetNPCNumber()];
            SetMainCameraTransform();
        }
        else
        {
            Debug.Log("Player position is not changed.");
        }
    }

    private void SetMainCameraTransform()
    {
        mainCamera.transform.position = playerActualTransform.position;
        mainCamera.transform.rotation = playerActualTransform.rotation;
    }
}
