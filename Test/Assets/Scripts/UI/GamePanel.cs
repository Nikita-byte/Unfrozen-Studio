using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GamePanel : BasePanel
{
    // [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _skipTurn;
    [SerializeField] private Button _killNextWarrior;
    [SerializeField] private GameObject _orderPanel;
    [SerializeField] private GameObject _buttonsPanel;

    private float _openningTime = 0.5f;

    private void Awake()
    {
        //_mainMenu.onClick.AddListener(() => EventManager.Instance.Events[EventType.MainMenu].Invoke());
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
        _orderPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-700, 0), _openningTime);
        _buttonsPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 200), _openningTime);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        _orderPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), _openningTime);
        _buttonsPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), _openningTime);
    }
}