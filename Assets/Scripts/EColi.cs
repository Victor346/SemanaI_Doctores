using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EColi : Bacteria
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //Movimiento


        if (other.gameObject.tag == "bala")
        {
            switch (other.GetComponent<Bala>().yoSoy)
            {
                case 0:
                    Debug.Log("Me disparo Trimetoprim");
                    // Bajar vida del Game Master's bacteria life



                    break;
                case 1:
                    Debug.Log("Me disparo Eritromicina");
                    break;
                case 2:
                    Debug.Log("Me disparo Lincomicina");
                    break;
                case 3:
                    Debug.Log("Me disparo Amoxilina");
                    break;
                case 4:
                    Debug.Log("Me disparo Cefadroxil");
                    break;
                case 5:
                    Debug.Log("Me disparo Estreptomicina");
                    break;
                default:
                    break;
            }


            //other.GetComponent<Bala>().nombreDeQuienMeLanzo;

            //gameManager.GetComponent<GameManager>().RegistrarGolpe(nombre, other.GetComponent<Bala>().nombreDeQuienMeLanzo);
            Destroy(other.gameObject);
        }


    }
}
