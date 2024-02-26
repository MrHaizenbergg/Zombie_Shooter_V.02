using UnityEngine;

public class HelicopterLopast : MonoBehaviour
{
    [SerializeField] private GameObject _lopastOne;
    [SerializeField] private GameObject _lopastTwo;
    [SerializeField] private float _speedRotate;

    void Update()
    {
        _lopastOne.transform.Rotate(0, 0, _speedRotate, Space.Self);
        _lopastTwo.transform.Rotate(0, 0, _speedRotate, Space.World);
    }
}
