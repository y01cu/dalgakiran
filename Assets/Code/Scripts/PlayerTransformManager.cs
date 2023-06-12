using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformManager : MonoBehaviour
{
    [SerializeField] private List<Transform> goodPlayerPositions;
    [SerializeField] private List<Transform> badPlayerPositions;

    [SerializeField] private Transform playerActualTransform;

    private void ChangePlayerPositionBasedOnTurnAndKind()
    {
        bool isPlayerGood = GameManager.ReturnPlayerRole();
        bool isItOkToChangePosition = NPCTurnManager.GetNPCNumber() >= 0;
        if (isPlayerGood && isItOkToChangePosition)
        {
            playerActualTransform = goodPlayerPositions[NPCTurnManager.GetNPCNumber()];
        }
        else if (!isPlayerGood && isItOkToChangePosition)
        {
            playerActualTransform = badPlayerPositions[NPCTurnManager.GetNPCNumber()];
        }
        else
        {
            Debug.Log("Player position is not changed.");
        }
    }
}
