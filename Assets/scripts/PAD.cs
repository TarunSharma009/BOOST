using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class PAD : MonoBehaviour


{
    [SerializeField] float period=2f;
    [SerializeField] Vector3 movement_vector=new Vector3(2f,0,0);
    [Range(0,1)]
    [SerializeField]
    float movementfactor;
    Vector3 startingpos;
    void Start()
    {
        startingpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period == Mathf.Epsilon) { return; }
        float cycle = Time.time /period ;
        const float tau = Mathf.PI * 2f;
        float rawsineewav = Mathf.Sin(cycle * tau);
        movementfactor = rawsineewav / 2f + 0.5f;

        Vector3 offset = movement_vector * movementfactor;
        transform.position = startingpos + offset;

    }
}
