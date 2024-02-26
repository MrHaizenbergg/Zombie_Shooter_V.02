using UnityEngine;
using UnityEngine.UI;

public class BestTimeLevelUI : MonoBehaviour
{
    [SerializeField] private Text _textBestTimeLevelFirst;
    [SerializeField] private Text _textBestTimeLevelSecond;
    [SerializeField] private Text _textBestTimeLevelThird;

    private void Start()
    {
        UpdateBestTimeText();
    }

    private void UpdateBestTimeText()
    {
        int minutes = Mathf.FloorToInt(SaveManager.instance.elapsedTimeFirstLevel / 60);
        int seconds = Mathf.FloorToInt(SaveManager.instance.elapsedTimeFirstLevel % 60);
        _textBestTimeLevelFirst.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        int minutesSecond = Mathf.FloorToInt(SaveManager.instance.elapsedTimeSecondLevel / 60);
        int secondsSecond = Mathf.FloorToInt(SaveManager.instance.elapsedTimeSecondLevel % 60);
        _textBestTimeLevelSecond.text = string.Format("{0:00}:{1:00}", minutesSecond, secondsSecond);

        int minutesThird = Mathf.FloorToInt(SaveManager.instance.elapsedTimeThirdLevel / 60);
        int secondsThird = Mathf.FloorToInt(SaveManager.instance.elapsedTimeThirdLevel % 60);
        _textBestTimeLevelThird.text = string.Format("{0:00}:{1:00}", minutesThird, secondsThird);
    }
}
