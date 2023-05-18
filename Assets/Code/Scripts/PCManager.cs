using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCManager : MonoBehaviour
{
    public TempFriend socialMediaApp;
    private bool isSocialMediaAppActive = false;

    public GameObject messagingApp;
    private bool isMessagingAppActive = false;

    public GameObject imageEditingApp;
    private bool isImageEditingAppActive = false;

    public GameObject videoEditingApp;
    private bool isVideoEditingAppActive = false;

    public void SocialMediaAppButton()
    {
        if (isSocialMediaAppActive == false)
        {
            socialMediaApp.gameObject.SetActive(true);
            isSocialMediaAppActive = true;
            return;
        }
        socialMediaApp.gameObject.SetActive(false);
        isSocialMediaAppActive = false;
    }

    public void MessagingAppButton()
    {
        if (isMessagingAppActive == false)
        {
            messagingApp.SetActive(true);
            isMessagingAppActive = true;
            return;
        }
        messagingApp.SetActive(false);
        isMessagingAppActive = false;
    }

    public void ImageEditingAppButton()
    {
        if (isImageEditingAppActive == false)
        {
            imageEditingApp.SetActive(true);
            isImageEditingAppActive = true;
            return;
        }
        imageEditingApp.SetActive(false);
        isImageEditingAppActive = false;
    }

    public void VideoEditingAppButton()
    {
        if (isVideoEditingAppActive == false)
        {
            videoEditingApp.SetActive(true);
            isVideoEditingAppActive = true;
            return;
        }
        videoEditingApp.SetActive(false);
        isVideoEditingAppActive = false;
    }
}
