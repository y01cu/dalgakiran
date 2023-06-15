using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class InkStoryManager : MonoBehaviour
{
    // AC refers to AudioClip

    // [SerializeField] private AudioClip tempAC;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip huhSound;

    // [SerializeField] private AudioClip buttonClickAudioClip;

    private TextWriter.TextWriterSingle textWriterSingle;
    // [Range(0, 1)]
    // [SerializeField] 
    private float textWritingSpeed;

    /*
         _inkStory.BindExternalFunction ("playSound", (string name) => {
            _audioController.Play(name);
        });    
    */

    // This is a super bare bones example of how to play and display a ink story in Unity.
    public static event Action<Story> OnCreateStory;

    private void Awake()
    {
        textWritingSpeed = 0.02f;
        // Remove the default message
        RemoveChildren();
        // StartStory();
    }

    private void Start()
    {
        OpenCanvasAgainAction += CallOpenCanvasAgainAndContinueCoroutine;
    }

    // Creates a new Story object with the compiled story which we can then play!
    public void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        InkBindExternalFunctions();

        if (OnCreateStory != null) OnCreateStory(story);

        RefreshView();
    }

    private void InkBindExternalFunctions()
    {
        story.BindExternalFunction("ActivateTempButton", (string name) =>
        {

        });

        story.BindExternalFunction("OpenTeleportPanel", () =>
        {
            // CanvasManager.Instance.OpenTeleportPanel();
            // GetComponentInParent<Canvas>().gameObject.SetActive(false);
            // teleportPanel.gameObject.SetActive(true);
        });

        story.BindExternalFunction("PlayHuhSound", () =>
        {
            StartCoroutine(WaitHuhSound());
        });

        story.BindExternalFunction("ActivateNextApp", () =>
        {
            // Activate next app and close canvas
            TabletManager.IncrementAvailableAppsAction();

            // // Open it again after certain time
            // CallOpenCanvasAgainAndContinueCoroutine();

            // Close the text writing process
            SetAlpha(GetComponent<Image>(), 0f);
            DeactivateChildren();

        });

        story.BindExternalFunction("FlowTheGame", () =>
        {
            GameManager.Instance.FlowTheGame();
        });

        story.BindExternalFunction("DestroyCanvas", () =>
        {
            // Destroy your own parent
            Destroy(gameObject.transform.parent.gameObject);
        });
    }

    private void MakeCanvasInvisible()
    {
        SetAlpha(GetComponent<Image>(), 0f);
    }

    private void CallOpenCanvasAgainAndContinueCoroutine()
    {
        float canvasOpeningCooldown = 3f;
        StartCoroutine(OpenCanvasAgainAndContinueCoroutine(canvasOpeningCooldown));
    }

    private void DeactivateChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void ActivateChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void SetAlpha(Image img, float alphaValue)
    {
        Color originalColor = img.color;
        img.color = new Color(originalColor.r, originalColor.g, originalColor.b, alphaValue);
    }

    [SerializeField] private Canvas parentCanvas;

    public static Action OpenCanvasAgainAction;

    private IEnumerator OpenCanvasAgainAndContinueCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        SetAlpha(GetComponent<Image>(), 0.9f);
        ActivateChildren();
        // Let's try it without refreshing the view
    }

    private IEnumerator WaitHuhSound()
    {
        yield return new WaitForSeconds(0.1f);
        audioSource.PlayOneShot(huhSound);
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    private void RefreshView()
    {
        StartCoroutine(RefreshViewCoroutine());
    }

    private IEnumerator RefreshViewCoroutine()
    {
        float cooldown = 0.4f;
        yield return new WaitForSeconds(cooldown);
        // Remove all the UI on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {

            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
        }
    }

    private void StopSoundEffectAndDisplayChoices()
    {
        StopSoundEffect_TextWriting();
        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate
                {
                    // audioSource.PlayOneShot(buttonClickAudioClip);
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            Button choice = CreateChoiceView("End of story.\nRestart?");
            choice.onClick.AddListener(delegate
            {
                StartStory();
            });
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    private void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);

        StartCoroutine(RefreshViewCoroutine());
        // RefreshView();
    }

    // Creates a textbox showing the the line of text
    private void CreateContentView(string text)
    {
        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;

        // storyText.text = text;

        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            // Currently active TextWriter
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            PlaySoundEffect_TextWriting();
            textWriterSingle = TextWriter.AddWriterWithSpeed_Static(storyText, text, textWritingSpeed, true, true, StopSoundEffectAndDisplayChoices);

            // Previously
            // Send what's required into the coroutine
            // StartCoroutine(CreateContentViewElseBlockCoroutine(storyText, text));
        }

        Transform textField = transform.Find("TextField").transform;

        storyText.transform.SetParent(textField.transform, false);
    }

    private IEnumerator CreateContentViewElseBlockCoroutine(TextMeshProUGUI storyText, string text)
    {
        // Not used
        yield return new WaitForSeconds(0.2f);
    }

    private void PlaySoundEffect_TextWriting()
    {
        audioSource.Play();
    }

    private void StopSoundEffect_TextWriting()
    {
        audioSource.Stop();
    }

    // Creates a button showing the choice text
    private Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;

        Transform buttonsField = transform.Find("ButtonsField").transform;

        choice.transform.SetParent(buttonsField.transform, false);

        // Gets the text from the button prefab
        TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;

        // Make the button expand to fit the text
        // VerticalLayoutGroup verticalLayoutGroup = choice.GetComponent<VerticalLayoutGroup>();
        // verticalLayoutGroup.childForceExpandHeight = false;

        return choice;
    }

    // Destroys all the children of this gameobject (all the UI)
    private void RemoveChildren()
    {
        int childCount = textBackgroundImage.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            bool isField = textBackgroundImage.transform.GetChild(i).name == "TextField" || textBackgroundImage.transform.GetChild(i).name == "ButtonsField";
            if (isField)
            {
                int fieldChildCount = textBackgroundImage.transform.GetChild(i).childCount;
                for (int j = fieldChildCount - 1; j >= 0; --j)
                {
                    GameObject.Destroy(textBackgroundImage.transform.GetChild(i).GetChild(j).gameObject);
                }
            }
            else
            {
                GameObject.Destroy(textBackgroundImage.transform.GetChild(i).gameObject);
            }
        }
    }

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story story;

    // UI Prefabs
    [SerializeField]
    private TextMeshProUGUI textPrefab;
    [SerializeField]
    private Button buttonPrefab = null;
    [SerializeField] private Image textBackgroundImage;

    // [SerializeField] private Button tempButton;
}
