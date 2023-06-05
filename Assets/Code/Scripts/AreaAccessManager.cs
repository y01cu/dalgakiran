using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AreaAccessManager : MonoBehaviour
{
    private static int accessibleAreaCount = 0;
    public static Action IncrementAndCheckAreaAccess;

    public static Action TeleportToArea1;
    public static Action TeleportToArea2;
    public static Action TeleportToArea3;


    [SerializeField] private Button buttonArea1;
    [SerializeField] private Button buttonArea2;
    [SerializeField] private Button buttonArea3;

    private void Awake()
    {
        // Setting all buttons to false
        buttonArea1.gameObject.SetActive(false);
        buttonArea2.gameObject.SetActive(false);
        buttonArea3.gameObject.SetActive(false);

        // Subscribing to the event
        IncrementAndCheckAreaAccess += IncrementAccessibleAreaCount;
        IncrementAndCheckAreaAccess += CheckAreaAccess;
        accessibleAreaCount = 0;
    }

    public static void IncrementAccessibleAreaCount()
    {
        accessibleAreaCount++;
    }

    private void CheckAreaAccess()
    {
        if (accessibleAreaCount == 1)
        {
            buttonArea1.gameObject.SetActive(true);
        }
        else if (accessibleAreaCount == 2)
        {
            buttonArea2.gameObject.SetActive(true);
        }
        else if (accessibleAreaCount == 3)
        {
            buttonArea3.gameObject.SetActive(true);
        }
    }

    private void TeleportingArea1()
    {

    }


}
