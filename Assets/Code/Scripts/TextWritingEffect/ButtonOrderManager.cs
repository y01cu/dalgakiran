using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonOrderManager : MonoBehaviour
{
    // public List<Button> buttonList;
    [SerializeField] private Button[] firstButtons;

    // private int buttonIndex = 0;


    public void ActivateFirstButtons()
    {
        // Start of the game
        foreach (Button button in firstButtons)
        {
            button.gameObject.SetActive(true);
        }
    }

    // public void UpdateToNextButton()
    // {
    //     Debug.Log("starting value: " + buttonIndex);
    //     Debug.Log("button list count: " + buttonList.Count);
    //     Debug.Log("ending value: " + buttonIndex);

    //     IncrementIndex();
    // }

    // private void IncrementIndex()
    // {
    //     buttonIndex++;
    // }

}
