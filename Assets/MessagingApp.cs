using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingApp : MonoBehaviour
{
    private bool isPlayerAtHome;

    public void OpenCanvasAgainIfPlayerIsAtHome()
    {
        // This function is called when the player clicks on the messaging app's exit button
        isPlayerAtHome = NPCTurnManager.GetNPCNumber() == 0;

        if (isPlayerAtHome)
        {
            InkStoryManager.OpenCanvasAgainAction?.Invoke();
        }
    }
}
