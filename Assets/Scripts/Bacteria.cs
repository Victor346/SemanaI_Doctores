using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    public string nombre;
    public GameObject gameManager;
    private int nivel;


    public int vidaMaxima;
    public float tiempoDeVida;

    private float timerVida;

    public int vida;
    
    private int experiencia;
    private int objetivoDeExperiencia;
    public float limiteDeCongelacion;

    private bool danioBacteriostatico;

    private float cantidadCongelada;

    private float timerCongelacion;
    private int danioActual;
    private string[] antibioticos =
    {
        "Trimetoprim", "Eritromicina", "Lincomicina", "Amoxilina", "Cefadroxil", "Estreptomicina"
    };

    // Start is called before the first frame update
    void Start()
    {
        danioBacteriostatico = false;
        vida = 100;
        nivel = 0;
        timerVida = 0.0f;

        //Este se reinicia cada ciclo de reprod
        timerCongelacion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Aumentar vida
        if (!danioBacteriostatico)
        {
            timerVida += Time.deltaTime;
        } else
        {
            timerCongelacion += Time.deltaTime;
            if(timerCongelacion > cantidadCongelada)
            {
                danioBacteriostatico = false;
            }
        } 





        if (timerVida > tiempoDeVida)
        {
            vida *= vida;
            if (vida > vidaMaxima)
            {
                vida = vidaMaxima;
                
            }
            cantidadCongelada = 0;
            timerVida = 0;
        }

    }

   public void MajerDanioBacteriostatico(int cantidadDeSegundos)
    {
        danioBacteriostatico = true;
        cantidadCongelada = (float)cantidadDeSegundos;
        if(cantidadCongelada > limiteDeCongelacion)
        {
            cantidadCongelada = limiteDeCongelacion;
        }
    }


}
