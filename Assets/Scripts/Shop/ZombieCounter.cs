using UnityEngine;
using UnityEngine.UI;

public class ZombieCounter : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = SaveManager.instance.killedZombies.ToString();
    }
}
