using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SocialMediaAppManager : MonoBehaviour
{
    // It starts with -1 because there are some zeroth things.
    private static int appProgress = -1;

    public static void IncrementAppProgress()
    {
        appProgress++;
    }

    public static SocialMediaAppManager Instance;

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

    [SerializeField] private List<GameObject> tweetsList;

    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    // Active tweet may needs to change
    [SerializeField] private GameObject activeTweet;

    [SerializeField] private List<string> tweetTextsZeroth;


    [SerializeField] private List<Sprite> profileImagesZeroth;

    [SerializeField] private List<string> profileNamesZeroth;


    [Header("Tweets")]

    [SerializeField] private List<Sprite> profileImagesOneAndBad;
    [SerializeField] private List<Sprite> profileImagesTwoAndBad;
    [SerializeField] private List<Sprite> profileImagesThreeAndBad;

    [SerializeField] private List<Sprite> profileImagesOneAndGood;
    [SerializeField] private List<Sprite> profileImagesTwoAndGood;
    [SerializeField] private List<Sprite> profileImagesThreeAndGood;

    [SerializeField] private List<string> tweetTextsOneAndBad;
    [SerializeField] private List<string> tweetTextsTwoAndBad;
    [SerializeField] private List<string> tweetTextsThreeAndBad;

    [SerializeField] private List<string> tweetTextsOneAndGood;
    [SerializeField] private List<string> tweetTextsTwoAndGood;
    [SerializeField] private List<string> tweetTextsThreeAndGood;

    [SerializeField] private List<string> profileNamesOneAndBad;
    [SerializeField] private List<string> profileNamesTwoAndBad;
    [SerializeField] private List<string> profileNamesThreeAndBad;

    [SerializeField] private List<string> profileNamesOneAndGood;
    [SerializeField] private List<string> profileNamesTwoAndGood;
    [SerializeField] private List<string> profileNamesThreeAndGood;

    public void OpenCanvasAgain()
    {
        InkStoryManager.OpenCanvasAgainAction?.Invoke();
    }

    private void Start()
    {
        IncrementAppProgress();
        FillPosts();
    }

    public void FillPosts()
    {
        // foreach (GameObject tweet in tweetsList)
        // {
        //     tweet.SetActive(false);
        // }

        // tweetsList[0].SetActive(true);
        // activeTweet = tweetsList[0];

        // Debug.Log("Available app count: " + TabletManager.GetAvailableApps());

        bool isPlayerGood = GameManager.ReturnPlayerRole();

        for (int i = 0; i <= 3; i++)
        {
            // There's no bad and good in zeroth condition
            if (appProgress == 0)
            {
                tweetsList[i].transform.Find("ProfileImage").GetComponent<Image>().sprite = profileImagesZeroth[i];
                tweetsList[i].transform.Find("ProfileNameText").GetComponent<TextMeshProUGUI>().text = profileNamesZeroth[i];
                tweetsList[i].transform.Find("TweetText").GetComponent<TextMeshProUGUI>().text = tweetTextsZeroth[i];

                // tweetsList[i].GetComponent<TextMeshProUGUI>().text = tweetsFirst[i];
            }

            if (appProgress == 1 && !isPlayerGood)
            {
                tweetsList[i].transform.Find("ProfileImage").GetComponent<Image>().sprite = profileImagesOneAndBad[i];
                tweetsList[i].transform.Find("ProfileNameText").GetComponent<TextMeshProUGUI>().text = profileNamesOneAndBad[i];
                tweetsList[i].transform.Find("TweetText").GetComponent<TextMeshProUGUI>().text = tweetTextsOneAndBad[i];

                // tweetsList[i].GetComponent<TextMeshProUGUI>().text = tweetsFirst[i];
            }
            if (appProgress == 2 && !isPlayerGood)
            {
                tweetsList[i].transform.Find("ProfileImage").GetComponent<Image>().sprite = profileImagesTwoAndBad[i];
                tweetsList[i].transform.Find("ProfileNameText").GetComponent<TextMeshProUGUI>().text = profileNamesTwoAndBad[i];
                tweetsList[i].transform.Find("TweetText").GetComponent<TextMeshProUGUI>().text = tweetTextsTwoAndBad[i];
            }
            if (appProgress == 3 && !isPlayerGood)
            {
                tweetsList[i].transform.Find("ProfileImage").GetComponent<Image>().sprite = profileImagesThreeAndBad[i];
                tweetsList[i].transform.Find("ProfileNameText").GetComponent<TextMeshProUGUI>().text = profileNamesThreeAndBad[i];
                tweetsList[i].transform.Find("TweetText").GetComponent<TextMeshProUGUI>().text = tweetTextsThreeAndBad[i];
            }

            if (appProgress == 1 && isPlayerGood)
            {
                tweetsList[i].transform.Find("ProfileImage").GetComponent<Image>().sprite = profileImagesOneAndGood[i];
                tweetsList[i].transform.Find("ProfileNameText").GetComponent<TextMeshProUGUI>().text = profileNamesOneAndGood[i];
                tweetsList[i].transform.Find("TweetText").GetComponent<TextMeshProUGUI>().text = tweetTextsOneAndGood[i];

                // tweetsList[i].GetComponent<TextMeshProUGUI>().text = tweetsFirst[i];
            }

            if (appProgress == 2 && isPlayerGood)
            {
                tweetsList[i].transform.Find("ProfileImage").GetComponent<Image>().sprite = profileImagesTwoAndGood[i];
                tweetsList[i].transform.Find("ProfileNameText").GetComponent<TextMeshProUGUI>().text = profileNamesTwoAndGood[i];
                tweetsList[i].transform.Find("TweetText").GetComponent<TextMeshProUGUI>().text = tweetTextsTwoAndGood[i];
            }

            if (appProgress == 3 && isPlayerGood)
            {
                tweetsList[i].transform.Find("ProfileImage").GetComponent<Image>().sprite = profileImagesThreeAndBad[i];
                tweetsList[i].transform.Find("ProfileNameText").GetComponent<TextMeshProUGUI>().text = profileNamesThreeAndBad[i];
                tweetsList[i].transform.Find("TweetText").GetComponent<TextMeshProUGUI>().text = tweetTextsThreeAndBad[i];
            }

            // Maybe I could've used two lists instead of 6, but I'm too lazy to change it now said copilot :D
            // Maybe I could've used two dimensional array instead of 6, but I'm too lazy to change it now said copilot :D

        }
    }

    // public void IterateLeft()
    // {
    //     if (activeTweet != tweetsList[0])
    //     {
    //         activeTweet.SetActive(false);
    //         activeTweet = tweetsList[tweetsList.IndexOf(activeTweet) - 1];
    //         activeTweet.SetActive(true);
    //     }
    // }

    // public void IterateRight()
    // {
    //     if (activeTweet != tweetsList[tweetsList.Count - 1])
    //     {
    //         activeTweet.SetActive(false);
    //         activeTweet = tweetsList[tweetsList.IndexOf(activeTweet) + 1];
    //         activeTweet.SetActive(true);
    //     }
    // }

    private bool isPlayerAtHome;

    public void OpenCanvasAgainIfPlayerIsAtHome()
    {
        // This function is called when the player clicks on the messaging app's exit button
        isPlayerAtHome = NPCTurnManager.GetNPCNumber() == 0;

        if (isPlayerAtHome)
        {
            InkStoryManager.OpenCanvasAgainAction?.Invoke();
        }
    }
}
