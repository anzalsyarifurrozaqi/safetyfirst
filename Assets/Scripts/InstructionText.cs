using UnityEngine;
using UnityEngine.UI;

public class InstructionText : MonoBehaviour
{
    #region Instance
    private static InstructionText instance;
    public static InstructionText Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InstructionText>();
                if (instance == null)
                {
                    instance = new GameObject("Player", typeof(InstructionText)).GetComponent<InstructionText>();

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
    public Text instructionText;
    public int noInstructions;
    
    // Start is called before the first frame update
    private void Start()
    {
        noInstructions = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log($"noInstructions {noInstructions}");
        switch (noInstructions)
        {
            case 1:
                {
                    instructionText.text = "Swipe ke kanan dan kiri untuk belok";
                    break;
                }

            case 2:
                {
                    instructionText.text = "Swipe kebawah untuk rem";
                    break;
                }
            case 3:
                {
                    instructionText.text = "memasuki jalur lambat, tidak boleh lebih dari 50 km / jam";                    
                    break;
                }
            case 4:
                {
                    instructionText.text = "lampu lalu lintas didepan merah berhenti sebelum garis";
                    break;
                }
            case 5:
                {
                    instructionText.text = "Lampu hijau silahkan jalan";
                    break;
                }
            default:
                {
                    instructionText.text = "";
                    break;
                }
        }
    }    
}
