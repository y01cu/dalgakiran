using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TextEditingApp : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    [Header("Topics")]
    [SerializeField] private List<Button> topicButtons;

    [Header("Allegations")]
    [SerializeField] private List<Button> allegationButtons;

    [Header("Header Text")]
    [SerializeField] private TextMeshProUGUI headerText;

    [Header("Audio")]
    [SerializeField] private AudioClip buttonAppearSound;
    [SerializeField] private AudioClip buttonClickSound;

    private string topicHeader = "Bir konu seçiniz.";
    private string allegationHeader = "Bir iddia seçiniz.";

    private void Start()
    {
        foreach (Button button in topicButtons)
        {
            button.gameObject.SetActive(false);

        }
        foreach (Button button in allegationButtons)
        {
            button.gameObject.SetActive(false);
        }

        headerText.text = topicHeader;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(ActivateAndFillTopicButtonsIfEmptyCoroutine());
        }
    }

    private bool doTopicButtonsHaveListeners = false;

    private int correctnessCounter = 0;

    private IEnumerator ActivateAndFillTopicButtonsIfEmptyCoroutine()
    {
        float initialWaitingTimeForHeaderTextAnimation = 3f;
        yield return new WaitForSeconds(initialWaitingTimeForHeaderTextAnimation);

        foreach (Button button in topicButtons)
        {
            button.gameObject.SetActive(true);
            button.interactable = false;

            StartCoroutine(PlayButtonAppearSoundCoroutine(button));

            float cooldownForNextButton = 2.2f;
            yield return new WaitForSeconds(cooldownForNextButton);
            if (!doTopicButtonsHaveListeners)
            {
                button.onClick.AddListener(() =>
                {
                    button.gameObject.GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
                    // Deactivate topic buttons
                    foreach (Button button in topicButtons)
                    {
                        button.gameObject.SetActive(false);
                    }
                    // -----
                    StartCoroutine(ActivateAllegationButtonsCoroutine());

                    // Animate header text
                    headerText.GetComponent<Animator>().SetTrigger("NextHeader");
                    StartCoroutine(HeaderTextAnimationCoroutine());
                    // -----

                    bool isChoiceCorrect = button.gameObject.CompareTag("CorrectButton");
                    if (isChoiceCorrect)
                    {
                        // I need to check button points here.
                        // I can name buttons with their points.
                        // button.gameObject.name.Contains
                        correctnessCounter++;
                    }

                });
            }
        }
        float waitingTimeForTopicButtonsInteraction = 2f;
        yield return new WaitForSeconds(waitingTimeForTopicButtonsInteraction);
        foreach (Button button in topicButtons)
        {
            button.interactable = true;
        }
    }

    private IEnumerator ActivateAllegationButtonsCoroutine()
    {
        float initialWaitingTimeForHeaderTextAnimation = 3f;
        yield return new WaitForSeconds(initialWaitingTimeForHeaderTextAnimation);

        foreach (Button button in allegationButtons)
        {
            button.gameObject.SetActive(true);
            button.interactable = false;

            StartCoroutine(PlayButtonAppearSoundCoroutine(button));

            float cooldownForNextButton = 2.2f;
            yield return new WaitForSeconds(cooldownForNextButton);
            if (!doTopicButtonsHaveListeners)
            {
                button.onClick.AddListener(() =>
                {
                    // Deactivate topic buttons
                    foreach (Button button in allegationButtons)
                    {
                        button.gameObject.SetActive(false);
                    }
                    // -----

                    // Animate header text
                    headerText.GetComponent<Animator>().SetTrigger("NextHeader");
                    StartCoroutine(HeaderTextAnimationCoroutine());
                    // -----

                    // Check choice correctness and increment counter if correct
                    bool isChoiceCorrect = button.gameObject.CompareTag("CorrectButton");
                    if (isChoiceCorrect)
                    {
                        // I need to check button points here.
                        // I can name buttons with their points.
                        // button.gameObject.name.Contains
                        correctnessCounter++;
                    }
                    StartCoroutine(CheckCorrectnessCounter());

                });
            }
        }
        float waitingTimeForTopicButtonsInteraction = 2f;
        yield return new WaitForSeconds(waitingTimeForTopicButtonsInteraction);
        foreach (Button button in allegationButtons)
        {
            button.interactable = true;
        }
    }

    // TODO configure this coroutine
    private IEnumerator HeaderTextAnimationCoroutine()
    {
        yield return new WaitForSeconds(2.2f);
        headerText.text = allegationHeader;
    }

    private IEnumerator CheckCorrectnessCounter()
    {
        float cooldownAfterAllegationChoice = 1f;
        yield return new WaitForSeconds(cooldownAfterAllegationChoice);
        if (correctnessCounter == 2)
        {
            // Move forward with a nice message.

            Debug.Log("Well done!");

            correctnessCounter = 0;
        }
        else
        {
            // Player needs to try again

            Debug.Log("Try again!");

            correctnessCounter = 0;

            StartCoroutine(RestartTextEditingApp());
        }
    }

    private IEnumerator RestartTextEditingApp()
    {
        foreach (Button button in topicButtons)
        {
            button.gameObject.SetActive(false);
        }
        foreach (Button button in allegationButtons)
        {
            button.gameObject.SetActive(false);
        }
        headerText.GetComponent<Animator>().SetTrigger("NextHeader");
        yield return new WaitForSeconds(2f);
        headerText.text = topicHeader;

        StartCoroutine(ActivateAllegationButtonsCoroutine());
    }

    private IEnumerator PlayButtonAppearSoundCoroutine(Button button)
    {
        yield return new WaitForSeconds(0.5f);
        button.GetComponent<AudioSource>().PlayOneShot(buttonAppearSound);
    }
}