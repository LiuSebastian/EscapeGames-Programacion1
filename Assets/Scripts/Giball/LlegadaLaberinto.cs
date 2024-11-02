using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegadaLaberinto : MonoBehaviour
{
    [SerializeField] Gimball gimbal;
    
    // Este m�todo se llama cuando cualquier objeto entra en el Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra tiene una etiqueta espec�fica, por ejemplo "Jugador"
        if (other.CompareTag("Bola"))
        {
            // Aqu� pones lo que quieres que suceda cuando el objeto llegue a la zona
            Debug.Log("�El jugador ha llegado a la meta!");
            other.gameObject.SetActive(false);
            var bola = other.gameObject.GetComponent<PlayerControllerbola>();
            if (bola != null)
            {
                bola.Interact(FindObjectOfType<PlayerViewController>());
                gimbal.OnExitInteraction();
            }
        }
    }
}
