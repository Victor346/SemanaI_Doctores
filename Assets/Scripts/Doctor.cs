using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    public string nombre;
    public float multiplicadorDeDanio;

    public GameObject pistola;

    private bool presCambiar;
    private float timerDisparo;
    private bool estaCargandoDisparo;

    public GameObject bala;

    private float nivelDeDisparo;

    private bool presionado;

    private bool presionadoCambio;

    private int nivel;

    public int experiencia;
    private int objetivoDeExperiencia;

    private string[] antibioticos =
    {
        "Trimetoprim", "Eritromicina", "Lincomicina", "Amoxilina", "Cefadroxil", "Estreptomicina"
    };

    private int[] daniosDeAntibiotico = {10, 20, 30};


    private int antibioticoActual;

    // Start is called before the first frame update
    void Start()
    {
        presCambiar = false;
        presionadoCambio = false;
        presionado = false;
        antibioticoActual = 0;
        multiplicadorDeDanio = 1.0f;
        timerDisparo = 0.0f;
        estaCargandoDisparo = false;
        nivel = 0;
        objetivoDeExperiencia = 10;
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

       
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f && presionado == false)
        {
            presionado = true;
            estaCargandoDisparo = true;
        }


        //Va a ser el trigger derecho pero por ahora es X

        if (estaCargandoDisparo)
        {
            timerDisparo += Time.deltaTime;
        }
        bool dispara = false;
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) < 0.5f && presionado == true)
        {
            dispara = true;
            presionado = false;
        }


            if (Input.GetKeyUp("x") || dispara)
        {
            estaCargandoDisparo = true;

            Debug.Log("Dispare");
            //Aqui seleccionas cuanto tiempo paso
            int danioActual = 0;

            GameObject balaTemp = Instantiate(bala);
            if (timerDisparo < 1)
            {
                //Primer nivel de disparo
                nivelDeDisparo = 1;
                //Debug.Log("Se disparo un nivel 1, disparaste " + antibioticos[antibioticoActual] );
                //Dos factores: nivel XP y nivelDeDisapro
                // La bacteria recibe el tipo
               


            }
            else if (timerDisparo < 2)
            {
                nivelDeDisparo = 2;
                //Debug.Log("Se disparo un nivel 2 disparaste " + antibioticos[antibioticoActual]);
            }
            else
            {
                nivelDeDisparo = 3;
                //Debug.Log("Se disparo un nivel 3 disparaste " + antibioticos[antibioticoActual]);
            }
            danioActual = (int)Mathf.Round( (nivel+1) * nivelDeDisparo * 100);
            balaTemp.GetComponent<Transform>().position = pistola.GetComponent<Transform>().position + new Vector3(0, 0.1f, 0.1f);
            balaTemp.GetComponent<Transform>().rotation = pistola.GetComponent<Transform>().rotation;
            balaTemp.GetComponent<Bala>().yoSoy = antibioticoActual;
            balaTemp.GetComponent<Bala>().nombreDeQuienMeLanzo = nombre;
            balaTemp.GetComponent<Bala>().danio = danioActual;
            balaTemp.GetComponent<Rigidbody>().AddForce(pistola.transform.forward * 1000);

            timerDisparo = 0f;
            estaCargandoDisparo = false;
        }



        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.5f && presionadoCambio == false)
        {
            presionadoCambio = true;
            
        }

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.5f && presionadoCambio == true)
        {
            presionadoCambio = false;
            presCambiar = true;
        }

        //Cambiar tipo de antibiotico
        if (Input.GetKeyDown("z") || presCambiar)
        {
            antibioticoActual++;
            antibioticoActual %= 6;
            Debug.Log("Cambiaste a " + antibioticos[antibioticoActual]);
            presCambiar = false;
        }

        
        
        
        
    }
}