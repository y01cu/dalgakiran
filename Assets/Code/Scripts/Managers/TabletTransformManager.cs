using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTransformManager : MonoBehaviour
{
    [SerializeField] private List<Transform> goodTabletPositions;
    [SerializeField] private List<Transform> badTabletPositions;

    [SerializeField] private TabletManager mainTablet;

    // private Transform tabletActualTransform;

    private void Start()
    {
        // Calling flow the game action happens in PlayerTransformManager class. Then there's no need to call it here.

        GameManager.FlowTheGame += SetTabletPositionBasedOnTurnAndKind;
    }

    private void SetTabletPositionBasedOnTurnAndKind()
    {
        StartCoroutine(SetTabletPositionBasedOnTurnAndKindCoroutine());
    }

    private IEnumerator SetTabletPositionBasedOnTurnAndKindCoroutine()
    {
        yield return new WaitForSeconds(1f);
        // No need to call it here also.
        // NPCTurnManager.IncreaseNPCNumberByOneAction();

        bool isPlayerGood = GameManager.ReturnPlayerRole();
        if (isPlayerGood)
        {
            mainTablet.transform.position = goodTabletPositions[NPCTurnManager.GetNPCNumber()].position;
            mainTablet.transform.rotation = goodTabletPositions[NPCTurnManager.GetNPCNumber()].rotation;
        }
        else if (!isPlayerGood)
        {
            mainTablet.transform.position = badTabletPositions[NPCTurnManager.GetNPCNumber()].position;
            mainTablet.transform.rotation = badTabletPositions[NPCTurnManager.GetNPCNumber()].rotation;
        }
        else
        {
            Debug.Log("Tablet position is not changed.");
        }
    }
}