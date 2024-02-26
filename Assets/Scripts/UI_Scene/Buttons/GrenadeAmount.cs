using UnityEngine;
using UnityEngine.UI;

public class GrenadeAmount : MonoBehaviour
{
    [SerializeField] private Text _amountOfGrenadeText;

    public void UpdateGrenadeUI(int grenade)
    {
        _amountOfGrenadeText.text = grenade.ToString();
    }
}
