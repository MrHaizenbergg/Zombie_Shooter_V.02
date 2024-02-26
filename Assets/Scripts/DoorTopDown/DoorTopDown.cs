using UnityEngine;
using UnityEngine.Events;

public class DoorTopDown : MonoBehaviour
{
    private JointAngleLimits2D openDoorLimits;
    private JointAngleLimits2D closeDoorLimits;
    private HingeJoint2D joint2D;

    public UnityEvent isDoorOpen;

    private void Awake()
    {
        //joint2D = transform.Find("Hinge").GetComponent<HingeJoint2D>();
        joint2D=GetComponentInChildren<HingeJoint2D>();
        openDoorLimits = joint2D.limits;
        closeDoorLimits = new JointAngleLimits2D { min = 0f, max = 0f };
        CloseDoor();
    }

    public void OpenDoor()
    {
        joint2D.limits= openDoorLimits;
        isDoorOpen.Invoke();
    }

    public void CloseDoor()
    {
        joint2D.limits = closeDoorLimits;
    }
}
