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
        GameManager.FlowTheGameAction += SetPlayerPositionBasedOnTurnAndKind;
    }

    private void SetPlayerPositionBasedOnTurnAndKind()
    {
        NPCTurnManager.IncreaseNPCNumberByOneAction();

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

    private void Update()
    {
        ChangePosition();
        LookAtTheTabletOrReturnBack();
    }

    private void ChangePosition()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetPlayerPositionBasedOnTurnAndKind();
        }
    }

    [SerializeField] private TabletManager tablet;

    private bool isPlayerLookingAtTheTablet = false;

    private Vector3 previousPosition;
    private Quaternion previousRotation;

    private void LookAtTheTabletOrReturnBack()
    {
        // TODO: Player needs to look at the tablet whenever key T is pressed for the first time. When it's pressed for the second time, player needs to return back to the previous position.

        // Camera rotation needs to be (90, 0, 180) when we are looking at the tablet.

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Instead of defining a transform here I can store the values of the playerActualTransform varible and then reassign it when needed.

            if (!isPlayerLookingAtTheTablet)
            {
                previousPosition = playerActualTransform.position;
                previousRotation = playerActualTransform.rotation;

                playerActualTransform.position = tablet.transform.position;
                playerActualTransform.Translate(0, 0.7f, 0);
                playerActualTransform.rotation = Quaternion.Euler(90, 0, 180);

                mainCamera.transform.position = playerActualTransform.position;
                mainCamera.transform.rotation = playerActualTransform.rotation;

                isPlayerLookingAtTheTablet = true;
            }
            else
            {
                playerActualTransform.position = previousPosition;
                playerActualTransform.rotation = previousRotation;

                mainCamera.transform.position = playerActualTransform.position;
                mainCamera.transform.rotation = playerActualTransform.rotation;

                isPlayerLookingAtTheTablet = false;

            }
        }

        // previousTransform.position = playerActualTransform.position;

        // playerActualTransform = tablet.transform;

        // playerActualTransform.
    }
}
