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
    private string tweetHeader = "Bir paylaşım seçiniz.";

    [SerializeField] private RectTransform scrollRectMaskPosts;
    [SerializeField] private RectTransform[] posts;

    private bool IsVisible(RectTransform objectRect, RectTransform scrollRectMask)
    {
        // Convert the image position to the local coordinate system of the scroll rect
        Vector3 imagePositionInScrollRect = scrollRectMask.InverseTransformPoint(objectRect.position);
        Rect maskRect = new Rect(scrollRectMask.rect.x, scrollRectMask.rect.y, scrollRectMask.rect.width, scrollRectMask.rect.height);

        // Check if the center of the image is within the mask area
        return maskRect.Contains(imagePositionInScrollRect);
    }

    public void TrySendingPost()
    {
        foreach (var post in posts)
        {
            if (IsVisible(post, scrollRectMaskPosts))
            {
                Debug.Log("Post " + post.name + " is selected");
            }
        }
    }

    private IEnumerator Start()
    {

        // Make them inactive at the beginning.
        foreach (Button button in topicButtons)
        {
            button.gameObject.SetActive(false);

        }
        foreach (Button button in allegationButtons)
        {
            button.gameObject.SetActive(false);
        }
        headerText.gameObject.SetActive(false);
        headerText.text = topicHeader;


        float initialWaitingDelayForImageAnimation = 4f;
        yield return new WaitForSeconds(initialWaitingDelayForImageAnimation);


        // Activate topic buttons
        StartCoroutine(ActivateAndFillTopicButtonsIfEmptyCoroutine());

        // Activate header text
        headerText.gameObject.SetActive(true);
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

            float cooldownForNextButton = 1.2f;
            yield return new WaitForSeconds(cooldownForNextButton);
            if (!doTopicButtonsHaveListeners)
            {
                button.onClick.AddListener(() =>
                {
                    button.gameObject.GetComponent<AudioSource>().PlayOneShot(buttonClickSound);

                    foreach (Button button in topicButtons)
                    {
                        button.interactable = false;
                    }
                    // -----
                    StartCoroutine(DeactivateTopicButtons());

                    StartCoroutine(ActivateAllegationButtonsCoroutine());

                    // Animate header text
                    headerText.GetComponent<Animator>().SetTrigger("NextHeader");
                    StartCoroutine(HeaderTextAllegationAnimationCoroutine());
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
        float waitingTimeForTopicButtonsInteraction = 0.5f;
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

            float cooldownForNextButton = 1.2f;
            yield return new WaitForSeconds(cooldownForNextButton);
            if (!doTopicButtonsHaveListeners)
            {
                button.onClick.AddListener(() =>
                {
                    button.gameObject.GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
                    foreach (Button button in allegationButtons)
                    {
                        button.interactable = false;
                    }
                    // -----
                    StartCoroutine(DeactivateAllegationButtons());
                    // Animate header text
                    // headerText.GetComponent<Animator>().SetTrigger("NextHeader");
                    // StartCoroutine(HeaderTextAnimationCoroutine());
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
        float waitingTimeForAllegationButtonsInteraction = 0.5f;
        yield return new WaitForSeconds(waitingTimeForAllegationButtonsInteraction);
        foreach (Button button in allegationButtons)
        {
            button.interactable = true;
        }
    }

    private IEnumerator DeactivateAllegationButtons()
    {
        foreach (Button button in allegationButtons)
        {
            button.GetComponent<Animator>().SetTrigger("Disappear");
        }
        yield return new WaitForSeconds(2f);
        foreach (Button button in allegationButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactivateTopicButtons()
    {
        foreach (Button button in topicButtons)
        {
            button.GetComponent<Animator>().SetTrigger("Disappear");
        }
        yield return new WaitForSeconds(2f);
        foreach (Button button in topicButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    // TODO configure this coroutine
    private IEnumerator HeaderTextAllegationAnimationCoroutine()
    {
        yield return new WaitForSeconds(1f);
        headerText.text = allegationHeader;
    }

    private IEnumerator HeaderTextTweetAnimationCoroutine()
    {
        headerText.GetComponent<Animator>().SetTrigger("NextHeader");
        yield return new WaitForSeconds(1f);
        headerText.text = tweetHeader;
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

            StartCoroutine(OpenTweetChoicesPanel());
        }
        else
        {
            // Player needs to try again

            Debug.Log("Try again!");

            correctnessCounter = 0;

            StartCoroutine(RestartTextEditingApp());
        }
    }

    [SerializeField] private GameObject topicAndAllegationsPanel;
    [SerializeField] private Button sendTweetButton;
    [SerializeField] private ScrollRect scrollRect;


    private IEnumerator OpenTweetChoicesPanel()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(HeaderTextTweetAnimationCoroutine());

        // -----
        // Close topic and allegation panel

        topicAndAllegationsPanel.GetComponent<Animator>().SetTrigger("ClosePanel");
        yield return new WaitForSeconds(3f);
        topicAndAllegationsPanel.gameObject.SetActive(false);

        sendTweetButton.gameObject.SetActive(true);
        scrollRect.gameObject.SetActive(true);

    }

    public void CallRestartTextEditingAppCoroutine()
    {
        StartCoroutine(RestartTextEditingApp());
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
        yield return new WaitForSeconds(0.25f);
        button.GetComponent<AudioSource>().PlayOneShot(buttonAppearSound);
    }

    public void SendTweetAndCloseTheApp()
    {
        StartCoroutine(SendTweetAndCloseTheAppCoroutine());
    }

    [SerializeField] private TextEditingApp textEditingApp;

    private IEnumerator SendTweetAndCloseTheAppCoroutine()
    {
        yield return new WaitForSeconds(3f);

        textEditingApp.gameObject.SetActive(false);
    }
}