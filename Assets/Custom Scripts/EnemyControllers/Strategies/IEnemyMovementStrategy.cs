public interface IEnemyMovementStrategy
{
    public void Move();
    public void SetLooping(bool looping);
    public bool DoneMoving();
}