using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManipulation : MonoBehaviour
{
    private static int correctChoiceCounter = 0;

    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    [SerializeField] private Image leftImage;
    [SerializeField] private Image rightImage;

    private IEnumerator Start()
    {
        AddFunctionsToButtons();

        float initialWaitingDelayForImageAnimation = 4f;
        yield return new WaitForSeconds(initialWaitingDelayForImageAnimation);

    }


    private void AddFunctionsToButtons()
    {
        leftButton.onClick.AddListener(() =>
        {
            Debug.Log("Left button clicked.");

            leftImage.gameObject.SetActive(true);

            leftButton.interactable = false;

            correctChoiceCounter++;

            CheckTotalCorrectChoices();
        });

        rightButton.onClick.AddListener(() =>
        {
            Debug.Log("Right button clicked.");

            rightImage.gameObject.SetActive(true);

            rightButton.interactable = false;

            correctChoiceCounter++;

            CheckTotalCorrectChoices();
        });
    }

    private void CheckTotalCorrectChoices()
    {
        if (correctChoiceCounter == 2)
        {
            StartCoroutine(CloseImageManipulationCoroutine());
        }
        else
        {
            return;
        }
    }

    [SerializeField] private GameObject imageManipulationPart;
    [SerializeField] private GameObject mainParts;

    private void CloseImageManipulation()
    {
        imageManipulationPart.gameObject.SetActive(false);
        mainParts.gameObject.SetActive(true);
    }

    [SerializeField] private Image wellDoneImage;

    private IEnumerator CloseImageManipulationCoroutine()
    {
        yield return new WaitForSeconds(3f);

        wellDoneImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);

        CloseImageManipulation();
    }

}
