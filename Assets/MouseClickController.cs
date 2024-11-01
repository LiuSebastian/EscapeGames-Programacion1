using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseClickController : MonoBehaviour
{
    public TextMeshPro visorText;
    public GameObject door;
    const int MAX_NUMBER = 5;
    const string password = "06549";
    string buttonValue;
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                NumberCube numberCube = hit.transform.GetComponent<NumberCube>();
                buttonValue = numberCube.GetNumber();
                if (numberCube != null)
                {
                    buttonValue = numberCube.GetNumber();

                    switch (buttonValue)
                    {

                        case "C":
                            visorText.text = "";
                            break;

                        case "E":
                            if (visorText.text == password)
                            {
                                Debug.Log("CORRECTO");
                                if (door != null)
                                {
                                    Animator doorAnimator = door.GetComponent<Animator>();
                                    if (doorAnimator != null)
                                    {
                                        doorAnimator.SetTrigger("OpenDoor");
                                        visorText.text = "";
                                    }
                                    else
                                    {
                                        Debug.LogWarning("No se encontró el componente Animator en el objeto door.");
                                    }
                                }
                                else
                                {
                                    Debug.LogWarning("La puerta no está asignada en el Inspector.");
                                }
                            }
                    
                            else
                            {
                                Debug.Log("INCORRECTO");
                            }
                            break;

                        default:
                            if (visorText.text.Length < MAX_NUMBER)
                            {
                                visorText.text += numberCube.GetNumber();
                            }
                            break;
                }



                }
            }
        }
    }
}
