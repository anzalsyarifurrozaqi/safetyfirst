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
    private int noIntruction = 0;
    private Vector2 _direction;


    CommandProcessor _commandProcessor;
    InputReader _inputReader;
    InstructionText instructionText;

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
        //instructionText = InstructionText.Instance;
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

    //void OnTriggerEnter2D(Collider2D other)
    //{        
    //    if (other.CompareTag("Jalur Motor"))
    //    {
    //        instructionText.noInstructions = 3;
    //        Debug.Log("jalur motor");            
    //    }

    //    if (other.CompareTag("Enemy"))
    //    {
    //        Debug.Log("menabrak");
    //        SceneManager.LoadScene("Main Menu");
    //    }

    //    if (other.CompareTag("instruction"))
    //    {
    //        //Debug.Log($"i{noIntriction}");
    //        if (noIntruction < 3)
    //        {
    //            noIntruction += 1;
    //        }
    //        StartCoroutine(IntructionTiming());
    //    }

    //    if (other.CompareTag("finish"))
    //    {
    //        Debug.Log("finish");
    //        SceneManager.LoadScene("Main Menu");
    //    }
    //}

    //void OnTriggerStay2D(Collider2D other)
    //{

    //    float i = 0;
    //    if (other.CompareTag("Jalur Motor"))
    //    {
    //        StartCoroutine(Gagal(i));
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{        
    //    if (other.CompareTag("Jalur Motor"))
    //    {
    //        StopAllCoroutines();
    //        instructionText.noInstructions = 0;
    //    }
    //}

    //private IEnumerator Gagal(float limitTime)
    //{        
    //    while (true)
    //    {
    //        //Debug.Log($"limitTime{limitTime}");
    //        if (Mathf.Round((speed * 12)) > 50)
    //        {
    //            if (limitTime > 3f)
    //            {
    //                yield return null;
    //                Debug.Log("gagal");
    //                //Time.timeScale = 0;
    //                SceneManager.LoadScene("Main Menu");
    //            }
    //            else
    //            {
    //                yield return new WaitForSeconds(Time.deltaTime);
    //                limitTime += Time.deltaTime;
    //            }
    //        }
    //        else
    //        {
    //            yield return null;
    //            limitTime = 0;
    //        }
    //    }

    //}

    //IEnumerator IntructionTiming()
    //{
    //    instructionText.noInstructions = noIntruction;
    //    yield return new WaitForSeconds(2f);
    //    instructionText.noInstructions = 0;        
    //}

}
