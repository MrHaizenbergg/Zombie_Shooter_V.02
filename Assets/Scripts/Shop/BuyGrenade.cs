using UnityEngine;
using UnityEngine.UI;

public class BuyGrenade : MonoBehaviour
{
    [SerializeField] private Text _grenadeText;
    [SerializeField] private Text _costText;
    [SerializeField] private int _costOfGrenade;
    [SerializeField] private Button _buyButton;

    private void Start()
    {
        _costText.text = _costOfGrenade + "$";
        _grenadeText.text = SaveManager.instance.amountGrenade.ToString();
    }

    private void Update()
    {
        if (_buyButton.gameObject.activeInHierarchy)
        {
            _buyButton.interactable = SaveManager.instance.money >= _costOfGrenade;
        }
    }

    public void BuyOneGrenade()
    {
        SaveManager.instance.money -= _costOfGrenade;
        SaveManager.instance.amountGrenade++;
        _grenadeText.text=SaveManager.instance.amountGrenade.ToString();
        SaveManager.instance.Save();
    }
}