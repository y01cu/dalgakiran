using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NPCTurnManager : MonoBehaviour
{
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

    public NPC npc;

    private void Update()
    {

    }

}
