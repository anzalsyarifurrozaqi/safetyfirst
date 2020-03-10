using UnityEngine;

public class BreakCommand : Command
{
    private bool _isBreak;
    private float _speed;
    public BreakCommand(IEntity entity, bool isBreak, float speed) : base(entity)
    {
        _isBreak = isBreak;
        _speed = speed;        
    }

    public override void Execute()
    {

        //Debug.Log(Entity.Instance.speed);
        if (_speed > 0.0f)
            Entity.Instance.speed -= 0.02f;
    }
}
