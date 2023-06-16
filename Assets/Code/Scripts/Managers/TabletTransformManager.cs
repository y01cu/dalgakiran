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

        GameManager.FlowTheGameAction +=
        SetTabletPositionBasedOnTurnAndKind;
    }

    private void SetTabletPositionBasedOnTurnAndKind()
    {
        StartCoroutine(SetTabletPositionBasedOnTurnAndKindCoroutine());
    }

    private IEnumerator SetTabletPositionBasedOnTurnAndKindCoroutine()
    {
        Debug.Log("npc turn before: " + NPCTurnManager.GetNPCNumber());
        yield return new WaitForSeconds(1f);
        Debug.Log("npc turn after: " + NPCTurnManager.GetNPCNumber());
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

    private void Update()
    {
        ChangePosition();
    }

    private void ChangePosition()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetTabletPositionBasedOnTurnAndKind();
        }
    }
}
