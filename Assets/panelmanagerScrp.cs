using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelmanagerScrp : MonoBehaviour
{
    public bool[] contrasenia = { true, true, true, true, true };
    public bool[] correcta = { true, false, false, true, false };
    [SerializeField] GameObject caja;
    Vector3 newPosition = new Vector3(8, 2, 11);
    public float tiempoTransicion = 2f;
    private float tiempoTranscurrido;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ComprobarContrasenia()
    {
        bool sonIguales = correcta.SequenceEqual(contrasenia);
        Debug.Log(sonIguales);
        if (sonIguales)
        {
            StartCoroutine(MoverObjeto());
            //caja.transform.position = newPosition;
        }
    }
    IEnumerator MoverObjeto()
    {
        float tiempoTranscurrido = 0f;
        Vector3 posicionInicial = caja.transform.position;

        while (tiempoTranscurrido < tiempoTransicion)
        {
            float t = tiempoTranscurrido / tiempoTransicion;
            caja.transform.position = Vector3.Lerp(posicionInicial, newPosition, t);
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
    }
}
