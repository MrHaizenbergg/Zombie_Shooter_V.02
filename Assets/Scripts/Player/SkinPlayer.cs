using System.Threading;
using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] skinPlayer;

    private void Awake()
    {
        ChooseSkinPlayer(SaveManager.instance.currentSkin);
    }

    private void ChooseSkinPlayer(int index)
    {
        if (SaveManager.instance.skinsUnlocked[index])
        {
            Instantiate(skinPlayer[index], transform.position, Quaternion.identity);
        }
        else
            Instantiate(skinPlayer[0], transform.position, Quaternion.identity);
    }
}
