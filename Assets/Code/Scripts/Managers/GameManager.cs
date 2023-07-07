using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Image canvasScreenImage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Let's say player is bad.
    private static bool isPlayerGood = false;

    public static Action FlowTheGameAction;

    private IEnumerator Start()
    {
        StartCoroutine(ActivateCanvasScreenImageWithAnimation());

        yield return new WaitForSeconds(1f);
        FlowTheGameAction?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlowTheGameAction?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            TabletManager.IncrementAvailableAppsAction();
        }
    }

    public void FlowTheGame()
    {
        StartCoroutine(FlowTheGameWithFadeAnimationCoroutine());
    }

    private IEnumerator FlowTheGameWithFadeAnimationCoroutine()
    {
        canvasScreenImage.gameObject.SetActive(true);
        FlowTheGameAction?.Invoke();
        float imageAnimationCooldown = 3f;
        yield return new WaitForSeconds(imageAnimationCooldown);
        // Set it active so that we can use it later
        canvasScreenImage.gameObject.SetActive(false);
    }

    // I need to delete what's unnecessary in the future

    public IEnumerator ActivateCanvasScreenImageWithAnimation()
    {
        canvasScreenImage.gameObject.SetActive(true);

        float imageAnimationLength = 2.7f;
        yield return new WaitForSeconds(imageAnimationLength);
        canvasScreenImage.gameObject.SetActive(false);

    }



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
    // - Player should be told to open the travelling panel and go to the place where first NPC is.

    public static bool ReturnPlayerRole()
    {
        return isPlayerGood;
    }

    public void LogCurrentNPCTurn()
    {
        Debug.Log("Current NPC number: " + NPCTurnManager.GetNPCNumber());
    }

    private void IncrementNPCTurn()
    {
        NPCTurnManager.IncreaseNPCNumberByOneAction();
    }

    private void CheckLogs()
    {
        bool isReadyToLogNPCTurn = Input.GetKeyDown(KeyCode.Y);
        if (isReadyToLogNPCTurn)
        {
            LogCurrentNPCTurn();
        }
    }
}
