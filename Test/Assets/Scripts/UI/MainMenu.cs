using System;
using UnityEngine.UI;
using UnityEngine;


public class MainMenu : BasePanel
{
    [SerializeField] private Button _play;

    private void Awake()
    {
        _play.onClick.AddListener(()=> EventManager.Instance.Events[EventType.StartGame].Invoke());
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }
}
