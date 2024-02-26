using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private DoorTopDown doorTopDown;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            doorTopDown.OpenDoor();
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            doorTopDown.CloseDoor();
        }
    }
}
