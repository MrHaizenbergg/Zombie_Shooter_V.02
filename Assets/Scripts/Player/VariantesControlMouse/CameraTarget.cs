using UnityEngine;
using Cinemachine;

public class CameraTarget : MonoBehaviour
{
    private Camera _cameraTarget;
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _treshold;
    private Vector3 mousePos;
    private Vector3 targetPos;

    private void Awake()
    {
        _cameraTarget = Camera.main;
        _virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _virtualCamera.Follow = gameObject.transform;
    }

    //private void Update()
    //{
    //    mousePos = _cameraTarget.ScreenToWorldPoint(Input.mousePosition);
    //    targetPos = (_player.position + mousePos) / 2f;

    //    targetPos.x = Mathf.Clamp(targetPos.x, -_treshold + _player.position.x, _treshold + _player.position.x);
    //    targetPos.y = Mathf.Clamp(targetPos.y, -_treshold + _player.position.y, _treshold + _player.position.y);

    //    transform.position = targetPos;
    //}
}
