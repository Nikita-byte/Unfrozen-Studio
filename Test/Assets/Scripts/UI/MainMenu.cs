using System;
using UnityEngine.UI;
using UnityEngine;


public class MainMenu : BasePanel
{
    [SerializeField] private Button _play;
    //[SerializeField] private Button _settings;

    private void Awake()
    {
        _play.onClick.AddListener(()=> EventManager.Instance.Events[EventType.StartGame].Invoke());
        //_settings.onClick.AddListener(() => ScreenInterface.Instance.Execute(PanelType.Settings));
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
