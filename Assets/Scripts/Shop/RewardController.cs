using UnityEngine;
using UnityEngine.Events;
using YG;

public class RewardController : MonoBehaviour
{
    [SerializeField] private GameObject _dieOrRiseGameObject;
    [SerializeField] private GameObject _rewardBtnEndGame;
    [SerializeField] private AmountKillZombies _amountKillZombies;
    [SerializeField] private float _explosionSavePlayerForce;
    [SerializeField] private float _explosionSavePlayerRadius;

    Collider2D[] isExplosionRadius = null;
    private GameObject _player;
    private int _moneyRewardEndGame;

    public UnityEvent staticRewardEvent;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    public void Rewarded(int id)
    {
        if (id == 0)
        {
            SaveManager.instance.money += 500;
            SaveManager.instance.Save();
            Debug.Log("CoinsRewarded");
        }
        else if (id == 1)
        {
            ExplosionSavePlayer();
            _player.GetComponent<HealthController>().AddHeatlh(_player.GetComponent<HealthController>().maxHealth);
            staticRewardEvent.Invoke();
            _dieOrRiseGameObject.SetActive(false);
            Debug.Log("AliveRewarded");
        }
        else if (id == 2)
        {
            _moneyRewardEndGame = _amountKillZombies.amountOfMoney * 3;
            _amountKillZombies.amountOfMoney = _moneyRewardEndGame;
            SaveManager.instance.money += _moneyRewardEndGame;
            SaveManager.instance.Save();
            _amountKillZombies.AmountKilledEndLevel();
            _rewardBtnEndGame.SetActive(false);
            Debug.Log("GetMpneyAds: " + _moneyRewardEndGame);
        }

        Debug.Log("CloseAdvRewMoneyAdd");
    }

    private void ExplosionSavePlayer()
    {
        //_grenadeAudioSource.Play();

        //Instantiate(_grenadeExplosion, transform.position, Quaternion.identity);

        isExplosionRadius = Physics2D.OverlapCircleAll(_player.transform.position, _explosionSavePlayerRadius);

        foreach (Collider2D obj in isExplosionRadius)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            BreakBox breakBox = obj.GetComponent<BreakBox>();
            if (breakBox != null)
            {
                breakBox.StartCoroutineBreakBox();
            }

            if (rb != null)
            {
                Vector2 distanceVector = obj.transform.position - transform.position;
                if (distanceVector.magnitude > 0)
                {
                    float explosionForce = _explosionSavePlayerForce / distanceVector.magnitude;
                    rb.AddForce(distanceVector.normalized * explosionForce);
                    HealthController healthController = rb.gameObject.GetComponent<HealthController>();
                    if (healthController != null)
                    {
                        healthController.TakeDamage(500);
                        Debug.Log("KillEnemy " + rb.name);
                    }
                }
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    if (_player != null)
    //        Gizmos.DrawWireSphere(_player.transform.position, _explosionSavePlayerRadius);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        SaveManager.instance.money += 1000;
    //        SaveManager.instance.Save();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        SaveManager.instance.money -= 1000;
    //        SaveManager.instance.Save();
    //    }

    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        SaveManager.instance.ClearData();
    //        SaveManager.instance.Save();
    //    }
    //}
}