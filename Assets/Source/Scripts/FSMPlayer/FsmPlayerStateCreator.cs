public class FsmPlayerStateCreator
{
    private readonly FsmPlayer _fsmPlayer;
    private readonly PlayerAnimator _playerAnimator;
    private readonly InputReader _inputReader;
    private readonly Backpack _backpack;
    private readonly OreDetector _oreDetector;

    public FsmPlayerStateCreator(FsmPlayer fsmPlayer, PlayerAnimator playerAnimator, InputReader inputReader, Backpack backpack, OreDetector oreDetector)
    {
        _fsmPlayer = fsmPlayer;
        _playerAnimator = playerAnimator;
        _inputReader = inputReader;
        _backpack = backpack;
        _oreDetector = oreDetector;
    }

    public FsmPlayerState CreateStateIdle(BuildZoneDetector buildZoneDetector) =>
         new FsmPlayerStateIdle(_fsmPlayer, _playerAnimator, _inputReader, _oreDetector, _backpack, buildZoneDetector);
    
    public FsmPlayerState CreateStateRun(PlayerMover playerMover) =>
         new FsmPlayerStateRun(_fsmPlayer, _playerAnimator, _inputReader, playerMover);
    
    public FsmPlayerState CreateStateCollect(float collectTime, ExperienceBalance experienceBalance) =>
        new FsmPlayerStateCollect(_fsmPlayer, _playerAnimator, _inputReader, _oreDetector, _backpack, collectTime, experienceBalance);
    
    public FsmPlayerState CreateStateDischarge(float dischargeTime) =>
        new FsmPlayerStateDischarge(_fsmPlayer, _playerAnimator, _inputReader, _backpack, dischargeTime);
}