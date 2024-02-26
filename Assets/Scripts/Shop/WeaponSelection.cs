using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    [Header("Navigations Buttons")]
    [SerializeField] private Button backBtn;
    [SerializeField] private Button nextBtn;

    [Header("Purchased/Buy Buttons")]
    //[SerializeField] private Button purchasedBtn;
    [SerializeField] private Button buyBtn;
    [SerializeField] private Text priceText;

    [Header("Weapon Atributes")]
    [SerializeField] private int[] weaponPrices;
    private int currentWeapon;

    [SerializeField] private CharacteristicWeapons _characteristicWeapons;

    public UnityEvent chooseFirstWeapon;
    public UnityEvent chooseSecondWeapon;

    private void Start()
    {
        currentWeapon = SaveManager.instance.currentWeapon;
        SelectWeapon(currentWeapon);
        _characteristicWeapons.ShowInfoAboutWeapon(currentWeapon);
    }

    private void Update()
    {
        if (buyBtn.gameObject.activeInHierarchy)
        {
            buyBtn.interactable = SaveManager.instance.money >= weaponPrices[currentWeapon];
        }
    }

    private void SelectWeapon(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == index);

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (SaveManager.instance.weaponUnlocked[currentWeapon])
        {
            buyBtn.gameObject.SetActive(false);
        }
        else
        {
            buyBtn.gameObject.SetActive(true);
            priceText.text = weaponPrices[currentWeapon] + "$";
        }
    }

    public void ChangeWeapon(int change)
    {
        currentWeapon += change;

        if (currentWeapon > transform.childCount - 1)
            currentWeapon = 0;
        else if (currentWeapon < 0)
            currentWeapon = transform.childCount - 1;

        _characteristicWeapons.ShowInfoAboutWeapon(currentWeapon);

        SelectWeapon(currentWeapon);
    }

    public void ChooseFirstWeapon()
    {
        if (SaveManager.instance.currentWeaponTwo == currentWeapon)
        {
            Debug.Log("Уже выбрано это оружие");
            return;
        }
        if (SaveManager.instance.weaponUnlocked[currentWeapon])
        {
            SaveManager.instance.currentWeapon = currentWeapon;
            SaveManager.instance.Save();
            chooseFirstWeapon.Invoke();
            Debug.Log("CurrentWeapon " + currentWeapon);
        }
        else
        {
            Debug.Log("Оружие закрыто Слот 1");
            return;
        }

    }

    public void ChooseSecondWeapon()
    {
        if (SaveManager.instance.currentWeapon == currentWeapon)
        {
            Debug.Log("Уже выбрано это оружие");
            return;
        }
        if (SaveManager.instance.weaponUnlocked[currentWeapon])
        {
            SaveManager.instance.currentWeaponTwo = currentWeapon;
            SaveManager.instance.Save();
            chooseSecondWeapon.Invoke();
            Debug.Log("CurrentWeapon " + currentWeapon);
        }
        else
        {
            Debug.Log("Оружие закрыто Слот 2");
            return;
        }
    }

    public void BuyWeapon()
    {
        SaveManager.instance.money -= weaponPrices[currentWeapon];
        SaveManager.instance.weaponUnlocked[currentWeapon] = true;
        SaveManager.instance.Save();

        UpdateUI();
    }
}
