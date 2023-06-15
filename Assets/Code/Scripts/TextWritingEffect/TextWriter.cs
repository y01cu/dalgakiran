using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;

    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static TextWriterSingle AddWriterWithSpeed_Static(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriterWithSpeed(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }

    private TextWriterSingle AddWriterWithSpeed(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(TextMeshProUGUI uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(TextMeshProUGUI uiText)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        // Debug.Log(textWriterSingleList.Count);
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    // Represents a single TextWriter instance

    public class TextWriterSingle
    {
        private TextMeshProUGUI uiText;
        private string textToWrite;
        private float timePerCharacter;
        private int characterIndex;
        private float timer;
        private bool invisibleCharacters;
        private Action onComplete;
        // -----
        // Added for smooth ink integration
        private bool isCurrentCanvasDialogEnded;

        public TextWriterSingle(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0;
        }

        // Returns true on complete
        public bool Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                // Added the if condition above to prevent the text from being written when the current canvas dialog is ended

                // Display next character
                timer += timePerCharacter;
                characterIndex++;

                // Added in order to get rid of ArgumentOutOfRangeException
                if (textToWrite == "")
                {
                    return false;
                }

                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    // Entire string displayed
                    // uiText = null;
                    if (onComplete != null)
                    {
                        onComplete();
                    }
                    return true;
                }


            }

            return false;
        }

        public TextMeshProUGUI GetUIText()
        {
            return uiText;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            if (onComplete != null)
            {
                onComplete();
            }
            TextWriter.RemoveWriter_Static(uiText);
        }

    }

}

