using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    public static CanvasManager Instance;

    [SerializeField] private List<Canvas> badInkStoryCanvases;
    [SerializeField] private List<Canvas> goodInkStoryCanvases;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        foreach (Canvas badCanvas in badInkStoryCanvases) {
            badCanvas.gameObject.SetActive(false);
        }
        foreach (Canvas goodCanvas in goodInkStoryCanvases) {
            goodCanvas.gameObject.SetActive(false);
        }

        GameManager.FlowTheGame += () => {
            StartCoroutine(ActivateCanvasBasedOnTurnAndKind());
        };
    }

    private IEnumerator ActivateCanvasBasedOnTurnAndKind() {
        float initialActivationCooldown = 3f;
        yield return new WaitForSeconds(initialActivationCooldown);
        //yield return new WaitForSeconds(3f);
        bool isPlayerGood = GameManager.ReturnPlayerRole();
        if (isPlayerGood) {
            goodInkStoryCanvases[NPCTurnManager.GetNPCNumber()].gameObject.SetActive(true);
        } else {
            badInkStoryCanvases[NPCTurnManager.GetNPCNumber()].gameObject.SetActive(true);
        }
    }

    [SerializeField] private Canvas teleportPanel;
    [SerializeField] private Button buttonPlace1;
    [SerializeField] private Button buttonPlace2;

    public void OpenTeleportPanel() {
        teleportPanel.gameObject.SetActive(true);

        buttonPlace1.GetComponent<Animator>().SetTrigger("ScaleInAndOut");
    }


}
