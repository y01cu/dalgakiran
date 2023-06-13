using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string name;
    public int number;

    [SerializeField] private Transform transformForInitiation;

    public void InstantiateRoom()
    {
        Instantiate(transformForInitiation, transform.position, transform.rotation);
    }
}
