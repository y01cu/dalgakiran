using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTurnManager : MonoBehaviour
{
    [SerializeField] private Room room1;
    [SerializeField] private Room room2;
    [SerializeField] private Room room3;

    private void Start()
    {
        SubscribeToActionOfNPCNumberIncrement();
    }

    private int roomNumber;

    private void SubscribeToActionOfNPCNumberIncrement()
    {
        NPCTurnManager.IncreaseNPCNumberByOneAction += SetRoomActiveBasedOnNPCNumber;
    }

    private void SetRoomActiveBasedOnNPCNumber()
    {
        roomNumber = NPCTurnManager.GetNPCNumber() % 3 + 1;
    }

    private void InstantiateRoomBasedOnNumber()
    {
        switch (roomNumber)
        {
            case 1:
                room1.InstantiateRoom();
                break;
            case 2:
                room2.InstantiateRoom();
                break;
            case 3:
                room3.InstantiateRoom();
                break;
            default:
                break;
        }
    }


}
