public interface IPlayerState
{
    void OnStart(PlayerController playerController);
    void OnUpdate(PlayerController playerController);
    void OnEnd(PlayerController playerController);
}