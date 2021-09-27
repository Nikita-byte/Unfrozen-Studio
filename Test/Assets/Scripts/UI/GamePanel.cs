using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GamePanel : BasePanel
{
    [SerializeField] private Button _skipTurn;
    [SerializeField] private Button _killNextWarrior;
    [SerializeField] private GameObject _orderPanel;
    [SerializeField] private GameObject _buttonsPanel;
    [SerializeField] private GameObject[] _warriorIcon;

    private float _openningTime = 0.5f;

    private void Awake()
    {
        _skipTurn.onClick.AddListener(()=> EventManager.Instance.Events[EventType.SkipTurn].Invoke());
        _killNextWarrior.onClick.AddListener(() => EventManager.Instance.Events[EventType.Animation].Invoke());
    }

    public void SetWarriors(BaseWarrior[] thisRound, BaseWarrior[] nextRound)
    {
        for (int i = 0; i < thisRound.Length; i++)
        {
            if (thisRound[i].ArmyType == ArmyType.Red)
            {
                _warriorIcon[i].GetComponentInChildren<Image>().color = Color.red;
            }
            else
            {
                _warriorIcon[i].GetComponentInChildren<Image>().color = Color.blue;
            }

            _warriorIcon[i].GetComponentInChildren<Text>().text = "Инициатива: " + thisRound[i].Initiative +
                "  Скорость: " + thisRound[i].Speed;
        }

        _warriorIcon[thisRound.Length].GetComponentInChildren<Image>().color = Color.white;
        _warriorIcon[thisRound.Length].GetComponentInChildren<Text>().text = "NEXT ROUND";


        if (thisRound.Length + nextRound.Length + 1 < _warriorIcon.Length)
        {
            int countEmptyIcons = _warriorIcon.Length - (thisRound.Length + 1);
            int count = thisRound.Length;

            while (countEmptyIcons > 0)
            {
                foreach (BaseWarrior baseWarrior in nextRound)
                {
                    if (countEmptyIcons > 0)
                    {
                        ++count;
                        if (baseWarrior.ArmyType == ArmyType.Red)
                        {
                            _warriorIcon[count].GetComponentInChildren<Image>().color = Color.red;
                        }
                        else
                        {
                            _warriorIcon[count].GetComponentInChildren<Image>().color = Color.blue;
                        }

                        _warriorIcon[count].GetComponentInChildren<Text>().text = "Инициатива: " + baseWarrior.Initiative +
                            "  Скорость: " + baseWarrior.Speed;
                        countEmptyIcons--;
                    }
                    else break;
                }

                if (countEmptyIcons > 0)
                {
                    _warriorIcon[++count].GetComponentInChildren<Image>().color = Color.white;
                    _warriorIcon[count].GetComponentInChildren<Text>().text = "NEXT ROUND";
                    countEmptyIcons--;
                }
            }
        }
        else
        {
            for (int i = 0; i < _warriorIcon.Length - thisRound.Length - 1; i++)
            {
                if (nextRound[i].ArmyType == ArmyType.Red)
                {
                    _warriorIcon[thisRound.Length + 1 + i].GetComponentInChildren<Image>().color = Color.red;
                }
                else
                {
                    _warriorIcon[thisRound.Length + 1 + i].GetComponentInChildren<Image>().color = Color.blue;
                }

                _warriorIcon[thisRound.Length + 1 + i].GetComponentInChildren<Text>().text = "Инициатива: " + nextRound[i].Initiative +
                    "  Скорость: " + nextRound[i].Speed;
            }
        }
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