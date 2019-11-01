using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManos : MonoBehaviour
{
    public GameObject hijo;
    // Start is called before the first frame update
    void Start()
    {
        hijo.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hijo.transform.position = this.transform.position;
    }
}
