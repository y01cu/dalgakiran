using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField] private List<Canvas> badInkStoryCanvases;
    [SerializeField] private List<Canvas> goodInkStoryCanvases;

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

        GameManager.FlowTheGameAction += ActivateCanvasBasedOnTurnAndKind;
    }

    private void ActivateCanvasBasedOnTurnAndKind()
    {
        bool isPlayerGood = GameManager.ReturnPlayerRole();

        if (isPlayerGood)
        {
            goodInkStoryCanvases[NPCTurnManager.GetNPCNumber()].gameObject.SetActive(true);
        }
        else
        {
            badInkStoryCanvases[NPCTurnManager.GetNPCNumber()].gameObject.SetActive(true);
        }
    }

    public void OpenTeleportPanel()
    {
        Debug.Log("Teleport panel is opened.");
    }


}
