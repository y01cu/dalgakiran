using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionDiaologueUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Button button0;
    private Button button1;

    private void Awake()
    {
        text = transform.Find("TextMessage").GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }


}
