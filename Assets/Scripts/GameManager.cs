using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Doctor[] doctores = new Doctor[3];
    public Bacteria[] bacterias = new Bacteria[3];

    public Dictionary<string, int> bacteriasMap;

    public Dictionary<string, int> doctoresMap;
    // Start is called before the first frame update
    void Start()
    {
        //Crear un map usando el indice y el nombre
        bacteriasMap = new Dictionary<string, int>();
        for (int i = 0; i < 3; i++)
        {
            bacteriasMap.Add(bacterias[i].nombre, i);
        }
        
        doctoresMap = new Dictionary<string, int>();
        for (int i = 0; i < 3; i++)
        {
            doctoresMap.Add(doctores[i].nombre, i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegistrarGolpe(string bacteria, string doctor)
    {
        int indiceDoctor = doctoresMap[doctor];
        doctores[indiceDoctor].GetComponent<Doctor>().experiencia += 1;
    }
}
