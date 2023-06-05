using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputManager : MonoBehaviour
{
    private bool isReadyToIncreaseNPCNumber;
    private bool isReadyToIncreaseAreaAccess;
    private bool isReadyToDoSomethingElse;
    private bool isReadyToInstantiateRoom;

    private void Start()
    {
        isReadyToDoSomethingElse = Input.GetKeyDown(KeyCode.U);
        isReadyToIncreaseNPCNumber = Input.GetKeyDown(KeyCode.L);
        isReadyToIncreaseAreaAccess = Input.GetKeyDown(KeyCode.P);
        isReadyToInstantiateRoom = Input.GetKeyDown(KeyCode.I);
    }

    private void Update()
    {
        CheckUserInputs();
    }

    private void CheckUserInputs()
    {
        if (isReadyToIncreaseNPCNumber)
        {
            NPCTurnManager.IncreaseNPCNumberByOneAction();
        }
        if (isReadyToIncreaseAreaAccess)
        {
            AreaAccessManager.IncrementAndCheckAreaAccess();
        }

        if (isReadyToInstantiateRoom)
        {
            NPCTurnManager.IncreaseNPCNumberByOneAction();
        }
    }
}
