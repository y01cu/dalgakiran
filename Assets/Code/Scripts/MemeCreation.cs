using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MemeCreation : App
{

    [SerializeField] private RectTransform scrollRectMaskImages;
    [SerializeField] private RectTransform[] images;

    [SerializeField] private RectTransform scrollRectMaskTexts;
    [SerializeField] private RectTransform[] texts;

    private bool IsVisible(RectTransform objectRect, RectTransform scrollRectMask)
    {
        // Convert the image position to the local coordinate system of the scroll rect
        Vector3 imagePositionInScrollRect = scrollRectMask.InverseTransformPoint(objectRect.position);
        Rect maskRect = new Rect(scrollRectMask.rect.x, scrollRectMask.rect.y, scrollRectMask.rect.width, scrollRectMask.rect.height);

        // Check if the center of the image is within the mask area
        return maskRect.Contains(imagePositionInScrollRect);
    }

    public void TryVisibleCouple()
    {
        foreach (var image in images)
        {
            if (IsVisible(image, scrollRectMaskImages))
            {
                Debug.Log("Image " + image.name + " is selected");
            }
        }

        foreach (var text in texts)
        {
            if (IsVisible(text, scrollRectMaskTexts))
            {
                Debug.Log("Text " + text.name + " is selected");
            }
        }
    }
}
