using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string name;
    public int number;

    [SerializeField] private Transform transformForInteraction;
}
