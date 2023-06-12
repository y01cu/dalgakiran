using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // There will be 2 different people player can control in the game.
    // Each of them will face 3 different NPCs.
    // Each NPC will have its own InkStory in its canvas.
    // Their canvas will be activated when it is their turn by CanvasManager class.
    // When the player finishes the conversation with the NPC, the NPC could be destroyed.

    // Initial stage will be like this:
    // Player will wake up in a room based on his/her preference of the character.
    // Firstly they'll start the conversation between the game assistant canvas that'll tell them to go outside, meet the NPCs.
    // So, after the story ends in the assistant canvas these should/shouldn't happen:

    // - It should be clear that must not be any "end of the story, restart?" button in the whole game.
    // - Play should be able to travel using his/her travelling panel.
    // - Player should be told to open the travelling panel.
    // - Player should be told to go to the first NPC.



    public void LogCurrentNPCTurn()
    {
        Debug.Log("Current NPC number: " + NPCTurnManager.GetNPCNumber());
    }

    private void IncrementNPCTurn()
    {
        NPCTurnManager.IncreaseNPCNumberByOneAction();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            LogCurrentNPCTurn();
        }
    }




}
