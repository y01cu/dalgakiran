using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TabletManager : MonoBehaviour
{
    private static int availableApps = 0;

    [SerializeField] private GameObject messagingAppButton;
    [SerializeField] private GameObject imageEditingAppButton;
    [SerializeField] private GameObject videoManipulationAppButton;
    [SerializeField] private GameObject textEditingAppButton;
    [SerializeField] private GameObject socialMediaAppButton;

    // If required I can add an action for here
    public static Action IncrementAvailableAppsAction;
    // Using action makes some function impossible to be called without another and it includes both name as well I guess.

    private void Start()
    {
        // Initially deactivate app buttons in the tablet

        messagingAppButton.SetActive(false);
        socialMediaAppButton.SetActive(false);
        textEditingAppButton.SetActive(false);
        imageEditingAppButton.SetActive(false);
        videoManipulationAppButton.SetActive(false);

        // Subscribing to the action
        IncrementAvailableAppsAction += IncrementAvailableApps;
        IncrementAvailableAppsAction += UpdateAvailableApps;
    }

    private static void IncrementAvailableApps()
    {
        // Activates next app
        availableApps++;
    }

    private void UpdateAvailableApps()
    {
        switch (availableApps)
        {
            case 0:

                messagingAppButton.SetActive(false);
                socialMediaAppButton.SetActive(false);
                textEditingAppButton.SetActive(false);
                imageEditingAppButton.SetActive(false);
                videoManipulationAppButton.SetActive(false);

                break;

            case 1:

                messagingAppButton.SetActive(true);
                socialMediaAppButton.SetActive(false);
                textEditingAppButton.SetActive(false);
                imageEditingAppButton.SetActive(false);
                videoManipulationAppButton.SetActive(false);

                break;

            case 2:

                messagingAppButton.SetActive(true);
                socialMediaAppButton.SetActive(true);
                textEditingAppButton.SetActive(false);
                imageEditingAppButton.SetActive(false);
                videoManipulationAppButton.SetActive(false);

                break;

            case 3:

                messagingAppButton.SetActive(true);
                socialMediaAppButton.SetActive(true);
                textEditingAppButton.SetActive(true);
                imageEditingAppButton.SetActive(false);
                videoManipulationAppButton.SetActive(false);

                break;

            case 4:

                messagingAppButton.SetActive(true);
                socialMediaAppButton.SetActive(true);
                textEditingAppButton.SetActive(true);
                imageEditingAppButton.SetActive(true);
                videoManipulationAppButton.SetActive(false);

                break;

            case 5:

                messagingAppButton.SetActive(true);
                socialMediaAppButton.SetActive(true);
                textEditingAppButton.SetActive(true);
                imageEditingAppButton.SetActive(true);
                videoManipulationAppButton.SetActive(true);

                break;
        }
    }
}