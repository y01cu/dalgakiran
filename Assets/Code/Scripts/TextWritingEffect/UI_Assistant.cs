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

    private string[] messageArray;


    private void Awake()
    {
        messageText = transform.Find("Message").Find("TextMessage").GetComponent<TextMeshProUGUI>();
    }

    public void ActivateText()
    {
        Debug.Log("Text activated.");
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            // Currently active TextWriter
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            string message = AssignAndReturnMessageArray()[Random.Range(0, messageArray.Length)];
            textWriterSingle = TextWriter.AddWriterWithSpeed_Static(messageText, message, messageLoadSpeed, true, true);
        }
    }

    private string[] AssignAndReturnMessageArray()
    {
        messageArray = new string[] {
                "This is the assistant speaking, hello and goodbye, see you next time!",
                "Hey there! Howdy! I've missed you. Come here and give me a hug.",
                "This is a really cool and useful effect that you can use in various projects",
                "Let's learn some code and make awesome games, cool isn't it!",
                "Manage your time wisely nice little young man.",
            };

        return messageArray;
    }
}
