using UnityEngine;

public interface IEntity
{
    //tambahan
    //Quaternion quaternion { get; }
    float playerSpeed { get; set; }
    Rigidbody2D rigidbody { get; set; }
   
    Transform transform { get; }
}