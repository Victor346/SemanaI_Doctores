using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPositionController : NetworkBehaviour
{

    public GameObject padre;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = padre.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = padre.transform.position;
    }
}
