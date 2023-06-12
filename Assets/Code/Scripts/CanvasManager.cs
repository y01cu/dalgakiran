using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private List<Canvas> badInkStoryCanvases;
    [SerializeField] private List<Canvas> goodInkStoryCanvases;

    private void Start()
    {
        foreach (Canvas badCanvas in badInkStoryCanvases)
        {
            badCanvas.gameObject.SetActive(false);
        }
        foreach (Canvas goodCanvas in goodInkStoryCanvases)
        {
            goodCanvas.gameObject.SetActive(false);
        }
    }

    private void ActivateCanvasBasedOnTurnAndKind()
    {
        bool isPlayerGood = GameManager.ReturnPlayerRole();

        if (isPlayerGood)
        {
            bool isPlayerAtHome = NPCTurnManager.GetNPCNumber() == -1;
            if (isPlayerAtHome)
            {

            }
            goodInkStoryCanvases[NPCTurnManager.GetNPCNumber()].gameObject.SetActive(true);
        }
        else
        {
            badInkStoryCanvases[NPCTurnManager.GetNPCNumber()].gameObject.SetActive(true);
        }

    }


}
