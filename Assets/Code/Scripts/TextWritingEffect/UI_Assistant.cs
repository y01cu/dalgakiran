// INK Script badnewsgame initial dialogues below.

/*


- Hi there! Good to see you.
*   [Hey]
-- You're here for the position of disinformation and fake news tycoon, is that correct?
    ** [That's right]
            
   
    ** [What?]
    --- Disinformation is ...
        *** [Got it!]
*   [Uhm, who are you?]   
--   My job is to guide you in your quest to becoming a disinformation and fake news tycoon.
    ** [Oh boy!]

- You're probably frustrated about something, right? Aren't we all. You can get started by using Twitter to vent.
* [Post a frustrated tweet]
* [I'm not sure]
        Well done!

--> END


*/

/*
    Disabling clicked button interaction.

    IEnumerator FadeOutAndContinue(Choice choice)
    {
        foreach (ChoiceView choiceView in choiceViews)
        {
            choiceView.StopAllCoroutines();
            // If choice is met
            if (choiceView.choice == choice)
                choiceView.button.interactable = false;
            else
                choiceView.button.enabled = false;
        }
        foreach (ChoiceView choiceView in choiceViews)
        {
            if (choiceView.choice != choice)
                StartCoroutine(choiceView.FadeOut(0.4f));
        }
        if (choiceViews.Count > 1)
            yield return new WaitForSeconds(0.25f);
        foreach (ChoiceView choiceView in choiceViews)
        {
            if (choiceView.choice == choice)
                yield return StartCoroutine(choiceView.FadeOut(0.6f));
        }
        foreach (ChoiceView choiceView in choiceViews)
        {
            Destroy(choiceView.gameObject);
        }
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
        Main.Instance.gameState.ChooseChoiceIndex(choice.index);
    }
}


*/



// Make your peace


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CodeMonkey.Utils;


public class UI_Assistant : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] private float messageLoadSpeed;
    private TextMeshProUGUI messageText;
    private TextWriter.TextWriterSingle textWriterSingle;

    // private int indexMessageMainStreet = 0;

    // private int indexMessageAlleyWay = 0;

    private AudioSource audioSource;

    private string[] messageArrayMainStreetAllLeft;
    private string[] messageArrayMainStreetAllRight;
    private string[] messageArrayMainStreet;

    private void Awake()
    {
        messageText = transform.Find("Message").Find("TextMessage").GetComponent<TextMeshProUGUI>();
        audioSource = transform.Find("TextWritingSound").GetComponent<AudioSource>();
    }

    public void ActivateTextAndProgressMainStreet()
    {


        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            // Currently active TextWriter
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            // We'll have increment approach rather than random here
            string message = AssignAndReturnMessageArrayMainStreet()[Random.Range(0, messageArrayMainStreet.Length)];
            PlaySE_TextWriting();
            textWriterSingle = TextWriter.AddWriterWithSpeed_Static(messageText, message, messageLoadSpeed, true, true, StopSE_TextWriting);
        }
    }

    private void StopSE_TextWriting()
    {
        audioSource.Stop();
    }

    private void PlaySE_TextWriting()
    {
        audioSource.Play();
    }


    // public void ActivateTextAndProgressAlleyWayLeft()
    // {
    //     messageArrayAlleyWayLeft = new string[]{
    //             "",

    //     };

    // }

    // public void ActivateTextAndProgressAlleyWayRight()
    // {
    //     messageArrayAlleyWayRight = new string[]{
    //             ""
    //     };

    // }

    // private string[] AssignAndReturnMessageArrayLeft()
    // {
    //     messageAlleywayAllLeft = new string[] {
    //             "Hi there! Good to see you.",
    //             "You're here for the position of disinformation and fake news tycoon, is that correct?",
    //             "You're probably frustrated about something, right? Aren't we all. You can get started by using Twitter to vent.",
    //             "Look! Your constructive criticism of the government got you a few followers. And more followers means more influence.",
    //             "Look at your meter. People don't find you very credible yet. To gain some real influence, you'll need to raise your credibility.",
    //             "I'll show you! But first: would you like to take part in a study on fake news recognition? It'll only take about 1-2 minutes of your time."
    //             "Your responses are completely anonymous and any collected data will only be used for scientific research on media literacy and education. You can cancel your participation at any time. To consent, please select 'Got it'."
    //         };

    //     return messageArrayMainStreetAllLeft;
    // }
    private string[] AssignAndReturnMessageArrayMainStreet()
    {
        messageArrayMainStreet = new string[] {
                "Hi there! Good to see you.",
                "You're probably frustrated about something, right? Aren't we all. You can get started by using Twitter to vent.",
            };

        return messageArrayMainStreet;
    }


}
