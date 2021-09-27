using UnityEngine;
using System.Collections.Generic;


public class FightController : ITurnOn, IUpdate
{
    private TeamFactory _teamFactory;
    private List<BaseWarrior> _warriors;
    private BaseWarrior _activeWarrior;
    private BaseTeam _redTeam;
    private BaseTeam _blueTeam;
    private GamePanel _gamePanel;
    private BaseState _currentFightState;
    private int _currentRound = 1;

    public BaseWarrior ActiveWarrior => _activeWarrior;


    public FightController()
    {
        _warriors = new List<BaseWarrior>();
        _teamFactory = new TeamFactory();
        _redTeam = _teamFactory.RedTeam;
        _blueTeam = _teamFactory.BlueTeam;

        StateCreator.Instance.SetFightController(this);
        SetState(StateCreator.Instance.TurnState);
        EventManager.Instance.AddListener(EventType.SkipTurn, SkipTurn);
    }

    public void SetState(BaseState state)
    {
        if (_currentFightState != null)
        {
            _currentFightState.Exit();
        }

        _currentFightState = state;
        _currentFightState.Enter();
    }

    public void TurnOn()
    {
        if (_gamePanel == null)
        {
            _gamePanel = GameObject.FindObjectOfType<GamePanel>();
        }

        _warriors.AddRange(_redTeam.Warriors);
        _warriors.AddRange(_blueTeam.Warriors);
        _warriors.Sort();
        _warriors.Reverse();
        _activeWarrior = _warriors[0];

        _gamePanel.SetWarriors(_warriors.ToArray(), _warriors.ToArray());

        EventManager.Instance.Round.Invoke(_currentRound);
    }

    public void TurnOff()
    {
        _warriors.Clear();
        _redTeam.Clean();
        _blueTeam.Clean();
    }

    public void Update()
    {
        _currentFightState.Update();
    }

    public void FixedUpdate()
    {
        _currentFightState.FixedUpdate();
    }

    public void LateUpdate()
    {
        _currentFightState.LateUpdate();
    }

    public void UpdateOrder()
    {
        List<BaseWarrior> thisRoundWarriors;
        List<BaseWarrior> nextRoundWarriors;

        nextRoundWarriors = _warriors.FindAll(delegate (BaseWarrior baseWarrior) { return !baseWarrior.IsDead; });

        thisRoundWarriors = nextRoundWarriors.FindAll(delegate(BaseWarrior baseWarrior) { return !baseWarrior.IsInactive; });
        thisRoundWarriors.Sort();
        thisRoundWarriors.Reverse();

        if (thisRoundWarriors.Count > 0)
        {
            _activeWarrior = thisRoundWarriors[0];
        }
        else
        {
            EventManager.Instance.Round.Invoke(++_currentRound);
            _activeWarrior = nextRoundWarriors[0];

            foreach (BaseWarrior baseWarrior in nextRoundWarriors)
            {
                baseWarrior.IsInactive = false;
            }
        }

        nextRoundWarriors.Sort();
        nextRoundWarriors.Reverse();

        _gamePanel.SetWarriors(thisRoundWarriors.ToArray(), nextRoundWarriors.ToArray());
    }

    public void SkipTurn()
    {
        ActiveWarrior.IsInactive = true;
        UpdateOrder();
    }
}
