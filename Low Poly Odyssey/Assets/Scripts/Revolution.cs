using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{

    [SerializeField] private float rev;
    [SerializeField] private float rot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rot * Time.deltaTime);
        transform.RotateAround(Vector3.zero, Vector3.up, rev * Time.deltaTime);
    }
}
