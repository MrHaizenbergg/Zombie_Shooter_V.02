using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpisaniePlayers : MonoBehaviour
{
    [SerializeField] private Text _speedPlayer;
    [SerializeField] private Text _healthPlayer;
    [SerializeField] private Text _defencePlayer;

    [SerializeField] private List<GameObject> _skinPlayers;

    public void ShowInfoAboutPlayer(int currentPlayer)
    {
        for (int i = 0; i < _skinPlayers.Count; i++)
        {
            InfoCharacteristicPlayers(currentPlayer);
        }
    }

    private void InfoCharacteristicPlayers(int info)
    {
        if (info == 0)
        {
            _speedPlayer.text = 2.3.ToString();
            _healthPlayer.text = 60.ToString();
            _defencePlayer.text = 1.ToString();
        }
        else if (info == 1)
        {
            _speedPlayer.text =   2.4.ToString();
            _healthPlayer.text =  63.ToString();
            _defencePlayer.text =  1.1.ToString();
        }
        else if (info == 2)
        {
            _speedPlayer.text =  2.3.ToString();
            _healthPlayer.text = 80.ToString();
            _defencePlayer.text = 1.3.ToString();
        }
        else if (info == 3)
        {
            _speedPlayer.text = 2.5.ToString();
            _healthPlayer.text = 67.ToString();
            _defencePlayer.text = 1.2.ToString();
        }
        else if (info == 4)
        {
            _speedPlayer.text =  2.4.ToString();
            _healthPlayer.text =  90.ToString();
            _defencePlayer.text = 1.5.ToString();
        }
        else if (info == 5)
        {
            _speedPlayer.text = 2.6.ToString();
            _healthPlayer.text = 80.ToString();
            _defencePlayer.text = 1.4.ToString();
        }
        else if (info == 6)
        {
            _speedPlayer.text = 2.6.ToString();
            _healthPlayer.text = 100.ToString();
            _defencePlayer.text = 1.7.ToString();
        }
        else if (info == 7)
        {
            _speedPlayer.text = 2.7.ToString();
            _healthPlayer.text = 110.ToString();
            _defencePlayer.text = 1.8.ToString();
        }
        else if (info == 8)
        {
            _speedPlayer.text = 2.9.ToString();
            _healthPlayer.text = 100.ToString();
            _defencePlayer.text = 1.7.ToString();
        }
        else if (info == 9)
        {
            _speedPlayer.text = 3.1.ToString();
            _healthPlayer.text = 130.ToString();
            _defencePlayer.text = 2.5.ToString();
        }
    }
}
