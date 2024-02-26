using UnityEngine;
using Cinemachine;

public class SetPlayerCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private CameraTarget _target;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        _target = FindObjectOfType<CameraTarget>();
        _virtualCamera.Follow = _target.gameObject.transform;
    }
}
