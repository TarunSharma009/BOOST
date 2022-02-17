using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket: MonoBehaviour

{


    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    Rigidbody r1;
    AudioSource audio1;
    enum State {Alive,Dead,Transcending}
    State state = State.Alive;
    

    void Start()
    {
        r1 = GetComponent<Rigidbody>();
        audio1 = GetComponent<AudioSource>();


    }


    void Update()
    {
        Process_Input();
    }

    void Process_Input()
    {
        rotate();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Friendly")
        {


        }
        else if (collision.gameObject.tag == "Finish")

        {
            state = State.Transcending;
            Invoke("loadlevel2", 1f);
        }
       

        
        else
        {
            SceneManager.LoadScene(0);
        }

    }

    private void loadlevel2()
    {
        Invoke("loadlvel2", 1f);
    }

    private void loadlvel2()
    {
        SceneManager.LoadScene(1);
    }

    private void Thrust()
    {
        if (audio1.isPlaying)
        {
            audio1.Play();
        }
        else
        {
            audio1.Stop();

        }
    }

    private void rotate()
    {
        r1.freezeRotation = true;

        if (Input.GetKey(KeyCode.Space))
        {
            float rotationspeed = mainThrust * Time.deltaTime;
            r1.AddRelativeForce(Vector3.up);
            Thrust();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            float rotationspeed = rcsThrust * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotationspeed);

            transform.Rotate(Vector3.forward);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
            float rotationspeed = rcsThrust * Time.deltaTime;
            transform.Rotate(-Vector3.forward * rotationspeed);

        }
        r1.freezeRotation = false;
    }


}
