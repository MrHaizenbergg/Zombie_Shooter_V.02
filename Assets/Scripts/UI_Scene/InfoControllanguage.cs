using UnityEngine;
using UnityEngine.UI;

public class InfoControllanguage : MonoBehaviour
{
    private Button _infoBtn;

    [SerializeField] private GameObject _infoWindowRu;
    [SerializeField] private GameObject _infoWindowEn;

    private void Awake()
    {
        _infoBtn = GetComponent<Button>();
    }

    private void Start()
    {
        if (Language.Instance.currentLanguage=="ru")
        {
            _infoBtn.onClick.AddListener(ActiveWindowRU);
            _infoBtn.onClick.RemoveListener(ActiveWindowEN);
        }
        else if (Language.Instance.currentLanguage=="en")
        {
            _infoBtn.onClick.AddListener(ActiveWindowEN);
            _infoBtn.onClick.RemoveListener(ActiveWindowRU);
        }
        else
        {
            _infoBtn.onClick.AddListener(ActiveWindowEN);
            _infoBtn.onClick.RemoveListener(ActiveWindowRU);
        }
    }

    private void ActiveWindowRU()
    {
        _infoWindowRu.SetActive(true);
    }

    private void ActiveWindowEN()
    {
        _infoWindowEn.SetActive(true);
    }
}
