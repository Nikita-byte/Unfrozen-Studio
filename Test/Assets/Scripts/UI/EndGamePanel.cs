using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class EndGamePanel : BasePanel
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Text _highScore;
    [SerializeField] private Text _score;
    [SerializeField] private Button _startButton;

    private void Awake()
    {
        _play.onClick.AddListener(() => EventManager.Instance.Events[EventType.StartGame].Invoke());
        _mainMenu.onClick.AddListener(() => EventManager.Instance.Events[EventType.MainMenu].Invoke());
    }

    public void SetScore(int score, int highscore)
    {
        _score.text = score.ToString();
        _highScore.text = highscore.ToString();
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetScreen(Sprite screen)
    {
        GetComponent<Image>().sprite = screen;
    }

    public void SetPlayButton(Sprite playButton)
    {
        _play.GetComponent<Image>().sprite = playButton;
    }

    public void SetMenuButton(Sprite sprite)
    {
        _mainMenu.GetComponent<Image>().sprite = sprite;
    }

    public void StartButton()
    {
        _startButton.gameObject.SetActive(false);
    }
}