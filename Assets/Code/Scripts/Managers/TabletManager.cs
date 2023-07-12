using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TabletManager : MonoBehaviour
{
    private static int availableApps = 0;
    [Header("App buttons")]
    [SerializeField] private GameObject messagingAppButton;
    [SerializeField] private GameObject imageEditingAppButton;
    [SerializeField] private GameObject videoManipulationAppButton;
    [SerializeField] private GameObject textEditingAppButton;
    [SerializeField] private GameObject socialMediaAppButton;

    // If required I can add an action for here
    public static Action IncrementAvailableAppsAction;
    // Using action makes some function impossible to be called without another and it includes both name as well I guess.

    [Header("Apps")]
    [SerializeField] private GameObject messagingApp;
    [SerializeField] private GameObject imageEditingApp;
    [SerializeField] private GameObject videoManipulationApp;
    [SerializeField] private GameObject textEditingApp;
    [SerializeField] private GameObject socialMediaApp;

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
                messagingAppButton.SetActive(false);
                socialMediaAppButton.SetActive(true);
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

    public static int GetAvailableApps()
    {
        return availableApps;
    }

    public void ActivateSocialMediaApp()
    {
        StartCoroutine(AnimateImageSetGameObjectActiveAfterCooldown(socialMediaApp));
    }

    public void ActivateTextEditingApp()
    {
        StartCoroutine(AnimateImageSetGameObjectActiveAfterCooldown(textEditingApp));
    }
    public void ActivateImageEditingApp()
    {
        StartCoroutine(AnimateImageSetGameObjectActiveAfterCooldown(imageEditingApp));
    }

    private IEnumerator AnimateImageSetGameObjectActiveAfterCooldown(GameObject gameObjectToBeActivated)
    {
        StartCoroutine(ActivateAnimateThenDeactivateAnimationImage());
        float appOpeningCooldown = 1f;
        yield return new WaitForSeconds(appOpeningCooldown);
        gameObjectToBeActivated.SetActive(true);
    }

    // ---------------------------------------------------------------------------------------------------------

    [SerializeField] private AnimationImage animationImage;

    private IEnumerator ActivateAnimateThenDeactivateAnimationImage()
    {
        float initialCoolDownAfterClick = 0.2f;
        yield return new WaitForSeconds(initialCoolDownAfterClick);
        ActivateAnimationImage();
        float deactivatingImageCooldown = 3;
        yield return new WaitForSeconds(deactivatingImageCooldown);
        DeactivateAnimationImage();
    }

    private void ActivateAnimationImage()
    {
        animationImage.gameObject.SetActive(true);
    }

    private void DeactivateAnimationImage()
    {
        animationImage.gameObject.SetActive(false);
    }

}