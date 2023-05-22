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

    private int indexMessageMainStreet = 0;

    private int indexMessageAlleyWay = 0;



    private string[] messageArrayMainStreet;


    private void Awake()
    {
        messageText = transform.Find("Message").Find("TextMessage").GetComponent<TextMeshProUGUI>();
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
            string message = AssignAndReturnMessageArray()[Random.Range(0, messageArrayMainStreet.Length)];
            textWriterSingle = TextWriter.AddWriterWithSpeed_Static(messageText, message, messageLoadSpeed, true, true);
        }
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

    private string[] AssignAndReturnMessageArray()
    {
        messageArrayMainStreet = new string[] {
                "Hi there! Good to see you.",

            };

        return messageArrayMainStreet;
    }
}
