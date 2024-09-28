public class FsmPlayerStateRun : FsmPlayerState
{
    private readonly PlayerMover _playerMover;

    public FsmPlayerStateRun(
        FsmPlayer fsmPlayer, 
        PlayerAnimator playerAnimator, 
        InputReader inputReader,
        PlayerMover playerMover) 
        : base(fsmPlayer, playerAnimator, inputReader)
    {
        _playerMover = playerMover;
    }

    public override void Enter() =>
        PlayerAnimator.PlayRunAnimation();

    public override void Update()
    {
        if (InputReader.NotHaveInput())
            FsmPlayer.SetState<FsmPlayerStateIdle>();

        _playerMover.Move(InputReader.Input);
    }
}