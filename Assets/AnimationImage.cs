using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AnimationImage class created for reaching AnimationImage easily
/// </summary>
public class AnimationImage : MonoBehaviour
{
    public static AnimationImage Instance;
    // singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

}