using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletDesktopInitialStateManager : MonoBehaviour
{
    private void Start()
    {
        DeactivateAllChildrenExceptRequired();
    }

    private void DeactivateAllChildrenExceptRequired()
    {
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            bool isChildGameObjectHasToBeActiveInitially = child.GetComponent<InitiallyActive>() != null;
            Debug.Log("Checked");
            if (isChildGameObjectHasToBeActiveInitially)
            {
                child.gameObject.SetActive(true);
                return;
            }
            child.gameObject.SetActive(false);
        }
    }
}