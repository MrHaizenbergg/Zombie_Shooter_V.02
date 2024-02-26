using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LaunchGrenade : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosGrenade;
    [SerializeField] private GameObject _grenadePrefab;

    private GrenadeAmount _grenadeAmount;

    [SerializeField] private Button _grenadeButton;

    [SerializeField] private float range = 7f;
    [SerializeField] private float maxRange = 15f;
    private float chargeTime = 0f;

    private bool isCharching = false;
    private bool isPC;
    private bool isAndroid;

    public UnityEvent OnLaunchGrenade;

    private void Awake()
    {
        _grenadeAmount = FindObjectOfType<GrenadeAmount>();

        //if (Application.platform==RuntimePlatform.WindowsPlayer)
        //{
        //    isPC = true;
        //    isAndroid = false;
        //    Debug.Log("PC");
        //}
        //else if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //    isPC = true;
        //    isAndroid = false;
        //    Debug.Log("isEditor");
        //}

        if (Application.isMobilePlatform)
        {
            isAndroid = true;
            isPC = false;
            Debug.Log("Android");
        }
        else
        {
            isPC = true;
            isAndroid = false;
            Debug.Log("PC");
        }

    }

    private void Start()
    {
        OnLaunchGrenade.AddListener(delegate { _grenadeAmount.UpdateGrenadeUI(SaveManager.instance.amountGrenade); });
        OnLaunchGrenade.Invoke();
    }

    private void Update()
    {
        if (isPC)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && SaveManager.instance.amountGrenade != 0)
            {
                StartLaunch();
            }
            if (isCharching)
            {
                ChargeFrow();
            }
            if (Input.GetKeyUp(KeyCode.Mouse1) && SaveManager.instance.amountGrenade != 0)
            {
                ReleaseThrow();
            }
        }
        else if (isAndroid)
        {      
            if (isCharching)
            {
                ChargeFrow();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && SaveManager.instance.amountGrenade != 0)
            {
                StartLaunch();
            }
            if (isCharching)
            {
                ChargeFrow();
            }
            if (Input.GetKeyUp(KeyCode.Mouse1) && SaveManager.instance.amountGrenade != 0)
            {
                ReleaseThrow();
            }
        }


    }

    public void StartLaunch()
    {
        isCharching = true;
        chargeTime = 0f;
    }

    private void ChargeFrow()
    {
        chargeTime += Time.deltaTime;
    }

    public void ReleaseThrow()
    {
        Launch(Mathf.Min(chargeTime * range, maxRange));
        isCharching = false;
    }

    private void Launch(float force)
    {
        GameObject grenade = Instantiate(_grenadePrefab, _spawnPosGrenade.position, _spawnPosGrenade.rotation);
        Rigidbody2D rigidbody = grenade.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);
        SaveManager.instance.amountGrenade--;
        SaveManager.instance.Save();
        OnLaunchGrenade.Invoke();
    }
}
