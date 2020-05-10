using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CommandProcessor))]
public class Entity : MonoBehaviour, IEntity
{
    #region Instance
    private static Entity instance;
    public static Entity Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Entity>();
                if (instance == null)
                {
                    instance = new GameObject("Player", typeof(Entity)).GetComponent<Entity>();

                }
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }   
    #endregion

    #region PUBLIC VARIABLE
    public float speed = 0;    
    public Text speedMeterText;
    #endregion
    private bool _isBreak = false;
    private Vector2 _move;
    private Vector2 _direction;


    CommandProcessor _commandProcessor;
    InputReader _inputReader;

    private Rigidbody2D rb;
    public float playerSpeed { get => speed; set => speed = value; }
    public new Rigidbody2D rigidbody { get => rb ; set => rb = value; }
    private void Awake()
    {
        _commandProcessor = GetComponent<CommandProcessor>();
        _inputReader = GetComponent<InputReader>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;        
    }
    private void Start()
    {
        Input.multiTouchEnabled = true;
    }
    private void FixedUpdate()
    {
        if (speed < 10f && !_isBreak)
            speed += 0.01f;
        int i = 0;
        while (i < Input.touchCount)
        {
                  
           

            _isBreak = _inputReader.ReadBreak(Input.GetTouch(i));
            if (_isBreak)
            {
                var BreakCommand = new BreakCommand(this, _isBreak, speed);
                _commandProcessor.ExecuteCommand(BreakCommand);
            }

            _move = _inputReader.ReadMove(Input.GetTouch(i));
            //Debug.Log($"move {move}");
            if (_move != Vector2.zero)
            {
                var moveCommand = new MoveCommand(this, _move, speed);
                _commandProcessor.ExecuteCommand(moveCommand);
            }
            //else
            //{
            //    rigidbody.MovePosition(rigidbody.position + (Vector2.up * speed * Time.fixedDeltaTime));
            //}

            _direction = _inputReader.ReadDirection(Input.GetTouch(i));
            if (_direction != Vector2.zero)
            {
                Debug.Log($"direction{ _direction}");                
            }

           
            ++i;
        }

        //float angle = Mathf.Atan2(1, 0) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //var locVel = transform.InverseTransformDirection(_direction);


        //rigidbody.velocity = locVel * Mathf.Round(speed);


        rigidbody.velocity = new Vector2(rigidbody.velocity.x, Mathf.Round(speed) * 1f);

        float textSpeedMeter = speed;
        textSpeedMeter = Mathf.Round((textSpeedMeter * 12));
        speedMeterText.text = $"{textSpeedMeter.ToString()} Km/h";
        //transform.Translate(Vector2.up * Mathf.Round(speed) * Time.deltaTime);

    }
}
