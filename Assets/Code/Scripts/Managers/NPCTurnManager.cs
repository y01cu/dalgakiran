using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NPCTurnManager : MonoBehaviour
{
    // NPC number needs to increase as the game flows.
    private static int npcNumber = -1;

    public static int GetNPCNumber()
    {
        return npcNumber;
    }

    public static Action IncreaseNPCNumberByOneAction;

    private void Start()
    {
        IncreaseNPCNumberByOneAction += IncreaseNPCNumberByOne;
        IncreaseNPCNumberByOneAction += OtherThingsHappening;
    }

    public void IncreaseNPCNumberByOne()
    {
        npcNumber++;
    }

    private void OtherThingsHappening()
    {

    }

}
