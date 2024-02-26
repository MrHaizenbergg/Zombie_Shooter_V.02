using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashWindow : MonoBehaviour
{
    [SerializeField] private Text _textSplash;

    [SerializeField] private GameObject _window;
    [SerializeField] private Animator _splashAnimator;

    [SerializeField] private Queue<string> splashQueue;
    private Coroutine _queueChecker;

    private void Start()
    {
        _window.SetActive(false);
        splashQueue = new Queue<string>();
    }

    public void AddToQueue(string text)
    {
        splashQueue.Enqueue(text);
        if (_queueChecker == null)
        {
            StartCoroutine(ShowSplash(text));
        }
    }

    private IEnumerator ShowSplash(string text)
    {
        _window.SetActive(true);
        _textSplash.text = text;
        _splashAnimator.Play("SplashMessage");
        yield return new WaitForSeconds(12.5f);
        _window.SetActive(false);
        _queueChecker = null;
    }
}
