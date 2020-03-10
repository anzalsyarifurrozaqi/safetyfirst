using UnityEngine;

public class DirectionCommand : Command
{
    private Vector3 _direction;
    private float speedRotate = 5f;

    public DirectionCommand(IEntity entity, Vector3 direction) : base(entity)
    {
        _direction = direction;
    }

    public override void Execute()
    {
        //Quaternion targetRotation = Quaternion.LookRotation(_direction);        
        //_entity.transform.rotation = Quaternion.Slerp(_entity.transform.rotation, targetRotation, Time.deltaTime * 1f);


        _entity.transform.rotation *= Quaternion.Euler(_direction * speedRotate * Time.deltaTime);
    }
}
