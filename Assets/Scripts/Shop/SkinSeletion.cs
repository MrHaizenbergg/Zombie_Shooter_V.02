using UnityEngine;
using UnityEngine.UI;

public class SkinSeletion : MonoBehaviour
{
    [Header("Navigations Buttons")]
    [SerializeField] private Button backBtn;
    [SerializeField] private Button nextBtn;

    [Header("Purchased/Buy Buttons")]
    //[SerializeField] private Button purchasedBtn;
    [SerializeField] private Button buyBtn;
    [SerializeField] private Text priceText;

    [Header("Skin Atributes")]
    [SerializeField] private int[] skinPrices;
    private int currentSkin;

    [SerializeField] private OpisaniePlayers _opisaniePlayers;

    private void Start()
    {
        currentSkin = SaveManager.instance.currentSkin;
        SelectSkin(currentSkin);
        _opisaniePlayers.ShowInfoAboutPlayer(currentSkin);
    }

    private void Update()
    {
        if(buyBtn.gameObject.activeInHierarchy)
        {
            buyBtn.interactable = SaveManager.instance.money >= skinPrices[currentSkin];
        }
    }

    private void SelectSkin(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == index);

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (SaveManager.instance.skinsUnlocked[currentSkin])
        {
            buyBtn.gameObject.SetActive(false);
        }
        else
        {
            buyBtn.gameObject.SetActive(true);
            priceText.text = skinPrices[currentSkin] + "$";
        }      
    }

    public void ChangeSkin(int change)
    {
        currentSkin += change;

        if (currentSkin > transform.childCount - 1)
            currentSkin = 0;
        else if (currentSkin < 0)
            currentSkin = transform.childCount - 1;

        _opisaniePlayers.ShowInfoAboutPlayer(currentSkin);

        SaveManager.instance.currentSkin = currentSkin;
        SaveManager.instance.Save();

        SelectSkin(currentSkin);
    }

    public void BuySkin()
    {
        SaveManager.instance.money -= skinPrices[currentSkin];
        SaveManager.instance.skinsUnlocked[currentSkin] = true;
        SaveManager.instance.Save();

        UpdateUI();
    }
}
