using UnityEngine;

public class MoveCommand : Command
{
    private Vector2 _move;
    private float _speed;
    private float direction;

    public MoveCommand(IEntity entity, Vector2 move, float speed) : base(entity)
    {
        _move = move;
        _speed = speed;
        direction = 2.22222f;
    }

    public override void Execute()
    {
        //_entity.transform.Translate(_move * 1f * Time.deltaTime);
        //Vector2 tPosition = new Vector2(_entity.rigidbody.position.x, _entity.rigidbody.position.y + 1f * _speed * Time.deltaTime);

        //Vector2 tPosition = new Vector2(_move.x, _entity.rigidbody.position.y);
        //_entity.rigidbody.MovePosition(tPosition + (1f * Time.fixedDeltaTime * Vector2.one));
        //_entity.rigidbody.MovePosition(_entity.rigidbody.position + tPosition);
        //_entity.rigidbody.velocity = Vector2.up * _speed + _move * 1f;

        //_entity.rigidbody.MovePosition(tPosition  + _move * 1f * Time.deltaTime);
        //Debug.Log($"rigid {_entity.rigidbody.position + tPosition}");
        //Debug.Log($"rigid {(Vector2)_entity.transform.position + tPosition}");
        //Debug.Log($"tposition {tPosition}");
        //Debug.Log($"move {_move}");

        _entity.transform.position = new Vector3(Mathf.Lerp(-direction, direction, _move.x), _entity.transform.position.y, _entity.transform.position.z);
    }
}
