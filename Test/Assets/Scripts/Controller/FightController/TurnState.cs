


public class TurnState : BaseState
{
    private FightController _fightController;

    public TurnState(FightController fightController)
    {
        _fightController = fightController;
        EventManager.Instance.AddListener(EventType.Turn, StartTurn);
    }

    public override void Enter()
    {
        ScreenInterface.Instance.Execute(PanelType.GamePanel);
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
    }

    public void StartTurn()
    {
        _fightController.SetState(StateCreator.Instance.TurnState);
        _fightController.UpdateOrder();
    }
}
