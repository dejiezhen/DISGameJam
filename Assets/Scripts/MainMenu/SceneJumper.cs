using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;   //required
using UnityEngine.SceneManagement;

public class SceneJumper : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private PickerWheel pickerWheel;
    void Start()
    {

        pickerWheel.OnSpinEnd(wheelPiece => {

            SceneManager.LoadScene(wheelPiece.Label);
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
