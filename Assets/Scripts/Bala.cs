using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private int tipoDeAntibiotico;

    public int danio;
    
    public Material[] materialesDeLaBala = new Material[6];

    public int yoSoy;

    public string nombreDeQuienMeLanzo;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material = materialesDeLaBala[yoSoy];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Escenario")
        {
            Destroy(this);
        }
       
    }
}
