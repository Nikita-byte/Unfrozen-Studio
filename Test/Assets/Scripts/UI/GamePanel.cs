using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GamePanel : BasePanel
{
    // [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _skipTurn;
    [SerializeField] private Button _killNextWarrior;

    private void Awake()
    {
        //_mainMenu.onClick.AddListener(() => EventManager.Instance.Events[EventType.MainMenu].Invoke());
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