using UnityEngine;
using UnityEngine.Events;

public class HelicopterEndLevel : MonoBehaviour
{
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private AudioSource _musicOnLevelAuSource;
    private WeaponSwitching _weaponSoundOff;

    private void Start()
    {
        _weaponSoundOff = FindObjectOfType<WeaponSwitching>();
    }

    public UnityEvent isVictoryInLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _weaponSoundOff.gameObject.SetActive(false);
            _musicOnLevelAuSource.gameObject.SetActive(false);
            isVictoryInLevel.Invoke();
            Time.timeScale = 0;
            _victoryScreen.CallVictoryScreen();
        }
    }
}
