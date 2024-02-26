using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class LevelController : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] sentences;

    [TextArea(3, 10)]
    public string[] englishSentences;

    [SerializeField] private Transform _triggerBlowDynamite;
    [SerializeField] private GameObject _dymaniteForWall;
    [SerializeField] private GameObject _iconDynamite;
    [SerializeField] private GameObject _destroyTriggerDinamite;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject AndroidHUD;

    private PlayerMovement _transformPlayer;
    private SplashWindow _splashWindow;

    public bool isDynamiteActive;

    //Yandex
    //[DllImport("__Internal")]
    //private static extern void RateGame();

    public void RateGameButton()
    {
        //RateGame();
    }

    private void Awake()
    {
        _iconDynamite.SetActive(false);
        _transformPlayer = FindObjectOfType<PlayerMovement>();
        _splashWindow = GetComponent<SplashWindow>();

        if (Application.isMobilePlatform)
        {
            AndroidHUD.SetActive(true);
            Debug.Log("Android");
        }
        else
        {
            AndroidHUD.SetActive(false);
            Debug.Log("PC");
        }
    }

    private void Start()
    {
        ActiveEnemies();
        if (SaveManager.instance.currentLevel == 1)
        {
            StartCoroutine(ShowFirstMessage());
        }
        else if (SaveManager.instance.currentLevel == 2)
        {
            StartCoroutine(ShowFirstMessageMiddleLevel());
        }
        else if (SaveManager.instance.currentLevel == 3)
        {
            StartCoroutine(ShowFirstMessageHardLevel());
        }

        //YandexAdvController.Instance.ShowAdvController();
    }

    public void SetActiveDynamite()
    {
        isDynamiteActive = true;
        _iconDynamite.SetActive(true);
    }

    private void ActiveEnemies()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].gameObject.SetActive(true);
        }
    }

    public void CreateDynamiteForWall(Transform transform)
    {
        if (isDynamiteActive)
        {
            Instantiate(_dymaniteForWall, transform.position, Quaternion.identity);
            _iconDynamite.SetActive(false);
            _destroyTriggerDinamite.SetActive(false);
        }
        else
        {
            if (Language.Instance.currentLanguage == "en")
                _splashWindow.AddToQueue("The wall looks flimsy, we need to look for explosives!");
            else if (Language.Instance.currentLanguage == "ru")
                _splashWindow.AddToQueue("—тена выгл€дит хлипкой, надо поискать взрывчатку!");
            else
                _splashWindow.AddToQueue("The wall looks flimsy, we need to look for explosives!");
        }
    }

    private IEnumerator ShowFirstMessage()
    {
        yield return new WaitForSeconds(1.5f);

        if (Language.Instance.currentLanguage == "en")
            _splashWindow.AddToQueue("Find the key and kill all the zombies before you get eaten, we need to get out of here!");
        else if (Language.Instance.currentLanguage == "ru")
            _splashWindow.AddToQueue("Ќайди ключ и убей всех зомби, пока теб€ не съели, нам нужно выбратьс€ отсюда!");
        else
            _splashWindow.AddToQueue("Find the key and kill all the zombies before you get eaten, we need to get out of here!");
    }

    private IEnumerator ShowFirstMessageHardLevel()
    {
        yield return new WaitForSeconds(1.5f);

        if (Language.Instance.currentLanguage == "en")
            _splashWindow.AddToQueue("I hope at least this time my helicopter doesnТt crash, itТs more difficult in this laboratory, but we will break through!");
        else if (Language.Instance.currentLanguage == "ru")
            _splashWindow.AddToQueue("Ќадеюсь хоть в этот раз мой вертолет не разобьетс€, в этой лаборатории сложнее, но мы прорвемс€!");
        else
            _splashWindow.AddToQueue("I hope at least this time my helicopter doesnТt crash, itТs more difficult in this laboratory, but we will break through!");
    }

    private IEnumerator ShowFirstMessageMiddleLevel()
    {
        yield return new WaitForSeconds(1.5f);

        if (Language.Instance.currentLanguage == "en")
            _splashWindow.AddToQueue("So good morning to you, it looks like there is a virus leak at the base, the boss said that I donТt have much time to get to the transport!!");
        else if (Language.Instance.currentLanguage == "ru")
            _splashWindow.AddToQueue("¬от тебе и доброе утро, похоже на базе утечка вируса, босс сказал что у мен€ мало времени чтобы добратьс€ до транспорта!!");
        else
            _splashWindow.AddToQueue("So good morning to you, it looks like there is a virus leak at the base, the boss said that I donТt have much time to get to the transport!");
    }

    public void ShowTextMessage(int message)
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            if (i == message)
            {
                if (Language.Instance.currentLanguage == "en")
                    _splashWindow.AddToQueue(englishSentences[message]);
                else if (Language.Instance.currentLanguage == "ru")
                    _splashWindow.AddToQueue(sentences[message]);
                else
                    _splashWindow.AddToQueue(englishSentences[message]);

            }
        }
    }
}
