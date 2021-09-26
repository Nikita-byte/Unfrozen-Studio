using UnityEngine;
using System.Collections.Generic;


public class FightController : ITurnOn, IUpdate
{
    private TeamFactory _teamFactory;
    private List<BaseWarrior> _warriors;
    private BaseTeam _redTeam;
    private BaseTeam _blueTeam;

    public FightController()
    {
        _warriors = new List<BaseWarrior>();
        _teamFactory = new TeamFactory();
        _redTeam = _teamFactory.RedTeam;
        _blueTeam = _teamFactory.BlueTeam;
    }

    public void TurnOn()
    {
        _warriors.AddRange(_redTeam.Warriors);
        _warriors.AddRange(_blueTeam.Warriors);
        _warriors.Sort();
        _warriors.Reverse();

        foreach (BaseWarrior baseWarrior in _warriors)
        {
            Debug.Log(baseWarrior.Initiative.ToString() + "  " + baseWarrior.Speed.ToString() + "  " + baseWarrior.ArmyType.ToString());
        }

        EventManager.Instance.Round.Invoke(1);
    }

    public void TurnOff()
    {
        _warriors.Clear();
        _redTeam.Clean();
        _blueTeam.Clean();
    }

    public void Update()
    {
    }

    public void FixedUpdate()
    {
    }

    public void LateUpdate()
    {
    }
}
