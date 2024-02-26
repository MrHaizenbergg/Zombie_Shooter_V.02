using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowAdvVictoryLevel()
    {
        //YandexAdvController.Instance.ShowAdvController();
    }

    public void SetTimeScaleOn()
    {
        Time.timeScale = 1;
    }
}
