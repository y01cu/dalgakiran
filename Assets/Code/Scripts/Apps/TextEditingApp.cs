using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TextEditingApp : App
{
    public static TextEditingApp Instance;

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

    [SerializeField] private Button exitButton;

    [Header("Topics")]
    [SerializeField] private List<Button> topicButtons;
    [SerializeField] private List<string> topicsOneAndBad;
    [SerializeField] private List<string> topicsTwoAndBad;
    [SerializeField] private List<string> topicsThreeAndBad;

    [SerializeField] private List<string> topicsOneAndGood;
    [SerializeField] private List<string> topicsTwoAndGood;
    [SerializeField] private List<string> topicsThreeAndGood;


    [Header("Allegations")]
    [SerializeField] private List<Button> allegationButtons;
    [SerializeField] private List<string> allegationsOneAndBad;
    [SerializeField] private List<string> allegationsTwoAndBad;
    [SerializeField] private List<string> allegationsThreeAndBad;

    [SerializeField] private List<string> allegationsOneAndGood;
    [SerializeField] private List<string> allegationsTwoAndGood;
    [SerializeField] private List<string> allegationsThreeAndGood;

    [SerializeField] private List<GameObject> selectableTweetObjects;

    [SerializeField] private List<string> selectableTweetsTextOneAndBad;
    [SerializeField] private List<string> selectableTweetsTextTwoAndBad;
    [SerializeField] private List<string> selectableTweetsTextThreeAndBad;

    [SerializeField] private List<string> selectableTweetsTextOneAndGood;
    [SerializeField] private List<string> selectableTweetsTextTwoAndGood;
    [SerializeField] private List<string> selectableTweetsTextThreeAndGood;

    // I can add right part if time will be enough but I'll keep the naming same
    // [SerializeField] private List<GameObject> tweetsOneAndBadAndRight;

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

    private static int appProgress = 0;

    public static void IncrementAppProgress()
    {
        appProgress++;
    }

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

    public void OpenCanvasAgain()
    {
        InkStoryManager.OpenCanvasAgainAction?.Invoke();
    }

    private IEnumerator Start()
    {
        // appProgress++;

        TextEditingAppFillContent();

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

    // I can fill in the content of this app using a function and adding it to the start method. It's that easy.

    public void TextEditingAppFillContent()
    {
        // Fill buttons
        // Fill tweets
        FillInButtons();
        FillInSelectableTweets();
    }

    private void FillInButtons()
    {
        bool isPlayerGood = GameManager.ReturnPlayerRole();

        bool isAppProgressOneAndBad = appProgress == 1 && !isPlayerGood;
        bool isAppProgressTwoAndBad = appProgress == 2 && !isPlayerGood;
        bool isAppProgressThreeAndBad = appProgress == 3 && !isPlayerGood;

        bool isAppProgressOneAndGood = appProgress == 1 && isPlayerGood;
        bool isAppProgressTwoAndGood = appProgress == 2 && isPlayerGood;
        bool isAppProgressThreeAndGood = appProgress == 3 && isPlayerGood;

        // All conditions are listed here below
        if (isAppProgressOneAndBad)
        {
            for (int i = 0; i < 3; i++)
            {
                topicButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = topicsOneAndBad[i];
                allegationButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = allegationsOneAndBad[i];
            }
        }
        else if (isAppProgressTwoAndBad)
        {
            for (int i = 0; i < 3; i++)
            {
                topicButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = topicsTwoAndBad[i];
                allegationButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = allegationsTwoAndBad[i];
            }
        }
        else if (isAppProgressThreeAndBad)
        {
            for (int i = 0; i < 3; i++)
            {
                topicButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = topicsThreeAndBad[i];
                allegationButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = allegationsThreeAndBad[i];
            }
        }
        else if (isAppProgressOneAndGood)
        {
            for (int i = 0; i < 3; i++)
            {
                topicButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = topicsOneAndGood[i];
                allegationButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = allegationsOneAndGood[i];
            }
        }
        else if (isAppProgressTwoAndGood)
        {
            for (int i = 0; i < 3; i++)
            {
                topicButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = topicsTwoAndGood[i];
                allegationButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = allegationsTwoAndGood[i];
            }
        }
        else if (isAppProgressThreeAndGood)
        {
            for (int i = 0; i < 3; i++)
            {
                topicButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = topicsThreeAndGood[i];
                allegationButtons[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = allegationsThreeAndGood[i];
            }
        }


    }

    private void FillInSelectableTweets()
    {
        bool isPlayerGood = GameManager.ReturnPlayerRole();

        bool isAppProgressOneAndBadForSelectableTweets = appProgress == 1 && !isPlayerGood;
        bool isAppProgressTwoAndBadForSelectableTweets = appProgress == 2 && !isPlayerGood;
        bool isAppProgressThreeAndBadForSelectableTweets = appProgress == 3 && !isPlayerGood;

        bool isAppProgressOneAndGoodForSelectableTweets = appProgress == 1 && isPlayerGood;
        bool isAppProgressTwoAndGoodForSelectableTweets = appProgress == 2 && isPlayerGood;
        bool isAppProgressThreeAndGoodForSelectableTweets = appProgress == 3 && isPlayerGood;

        // All conditions are listed here below
        if (isAppProgressOneAndBadForSelectableTweets)
        {
            for (int i = 0; i < 3; i++)
            {
                selectableTweetObjects[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = selectableTweetsTextOneAndBad[i];
            }
        }
        else if (isAppProgressTwoAndBadForSelectableTweets)
        {
            for (int i = 0; i < 3; i++)
            {
                selectableTweetObjects[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = selectableTweetsTextTwoAndBad[i];

            }
        }
        else if (isAppProgressThreeAndBadForSelectableTweets)
        {
            for (int i = 0; i < 3; i++)
            {
                selectableTweetObjects[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = selectableTweetsTextThreeAndBad[i];
            }
        }
        else if (isAppProgressOneAndGoodForSelectableTweets)
        {
            for (int i = 0; i < 3; i++)
            {
                selectableTweetObjects[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = selectableTweetsTextOneAndGood[i];
            }
        }
        else if (isAppProgressTwoAndGoodForSelectableTweets)
        {
            for (int i = 0; i < 3; i++)
            {
                selectableTweetObjects[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = selectableTweetsTextTwoAndGood[i];
            }
        }
        else if (isAppProgressThreeAndGoodForSelectableTweets)
        {
            for (int i = 0; i < 3; i++)
            {
                selectableTweetObjects[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = selectableTweetsTextThreeAndGood[i];
            }
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

            // Open canvas again so that the game can continue
            InkStoryManager.OpenCanvasAgainAction?.Invoke();
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