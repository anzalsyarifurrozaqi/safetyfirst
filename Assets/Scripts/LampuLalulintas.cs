using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LampuLalulintas : MonoBehaviour, IRambu
{
    protected IEntity _entitiy;
    private bool _merah = true;
    private TextManager _textManager;
    PanelRintangan panelRintangan;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _merah)
        {
            Debug.Log("gagal");            
            GameObject newObject = new GameObject();
            newObject.AddComponent<Panel>();
            Panel panel = newObject.GetComponent<Panel>();
            panel.SetText("GAGAL", "MENEROBOS LAMPU MERAH");
            panel.openPanel();            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            //_textManager.clearText();
            panelRintangan.closePanel();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void Start()
    {
        _entitiy = Entity.Instance;
        _textManager = new TextManager();
        GameObject rintanganObject = new GameObject();
        rintanganObject.AddComponent<PanelRintangan>();
        panelRintangan = rintanganObject.GetComponent<PanelRintangan>();        
    }

    private void Update()
    {
        if (_entitiy.transform.position.y < transform.position.y)
        {
            var vectorToTarget = _entitiy.transform.position - transform.position;
            vectorToTarget.x = 0;
            var distanceToTarget = vectorToTarget.magnitude;
            if (distanceToTarget < 40 && _merah)
            {
                //Debug.Log($"distance {distanceToTarget}");
                //_textManager.setText("lampu lalu lintas didepan merah berhenti sebelum garis");
                panelRintangan.SetText("lampu lalu lintas didepan merah, jalan pelan-pelan dan berhenti sebelum garis");
                panelRintangan.openPanel();
                if (_entitiy.playerSpeed < 0 && _merah)
                {
                    panelRintangan.SetText("tunggu hingga lampu hijau");
                    StartCoroutine(ubahKEHijau());
                }
            }
        }
    }

    IEnumerator ubahKEHijau()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            _merah = false;
            //_textManager.setText("Lampu hijau silahkan jalan");
            panelRintangan.SetText("Lampu hijau silahkan jalan");
        }

    }


    //float distance;
    //bool _merah = true;
    //Entity player;
    //InstructionText instructionText;

    //private void Start()
    //{
    //    player = Entity.Instance;
    //    instructionText = InstructionText.Instance;
    //}

    //private void Update()
    //{
    //    if (Entity.Instance.transform.position.y < transform.position.y)
    //    {
    //        var vectorToTarget = player.transform.position - transform.position;
    //        vectorToTarget.x = 0;
    //        var distanceToTarget = vectorToTarget.magnitude;
    //        if (distanceToTarget < 60 && _merah)
    //        {
    //            //Debug.Log($"distance {distanceToTarget}");
    //            instructionText.noInstructions = 4;
    //            if (player.speed < 0 && _merah)
    //            {
    //                StartCoroutine(ubahKEHijau());
    //            }
    //        }           
    //    }       


    //}

    //IEnumerator ubahKEHijau()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(5f);
    //        _merah = false;
    //        instructionText.noInstructions = 5;
    //    }

    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player") && _merah)
    //    {
    //        Debug.Log("gagal");
    //        SceneManager.LoadScene("Main Menu");
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        StopAllCoroutines();
    //        instructionText.noInstructions = 0;            
    //    }
    //}
}
