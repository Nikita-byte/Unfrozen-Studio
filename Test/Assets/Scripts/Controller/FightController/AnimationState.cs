using UnityEngine;


public class AnimationState : BaseState
{
    private FightController _fightController;

    private float _timeForAnimation = 0.5f;
    private float _currentTime = 0;

    public AnimationState(FightController fightController)
    {
        _fightController = fightController;
        EventManager.Instance.AddListener(EventType.Animation, StartAnimation);
    }

    public override void Enter()
    {
        ScreenInterface.Instance.Execute(PanelType.EndGamePanel);
        _currentTime = 0;
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
    }

    public override void LateUpdate()
    {
    }

    public override void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeForAnimation)
        {
            EventManager.Instance.Events[EventType.Turn].Invoke();
            _currentTime = 0;
        }
    }

    public void StartAnimation()
    {
        _fightController.SetState(StateCreator.Instance.AnimationState);
        _fightController.ActiveWarrior.Die();
        _fightController.UpdateOrder();
    }
}
