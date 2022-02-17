using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ROCKET : MonoBehaviour

{
    // todo fix lighting bug
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField]AudioClip mainengine;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip sucesss;
    [SerializeField] ParticleSystem fire;
    [SerializeField] ParticleSystem Wow;
    [SerializeField] ParticleSystem explode;
    [SerializeField] float levelloadtime=2f;
  


    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // todo somewhere stop sound on death
        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; } // ignore collisions when dead

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                break;
            case "Finish":
                state = State.Transcending;
                Wow.Play();
                audioSource.PlayOneShot(sucesss);
                Invoke("LoadNextLevel", levelloadtime); // parameterise time
                break;
            default:
                print("Hit something deadly");
                state = State.Dying;
                audioSource.PlayOneShot(death);
                Invoke("LoadFirstLevel", levelloadtime); // parameterise time
                explode.Play();
                
                break;
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1); // todo allow for more than 2 levels
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) // can thrust while rotating
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying) // so it doesn't layer
            {
                audioSource.PlayOneShot(mainengine);
                fire.Play();
            }
        }
        else
        {
            audioSource.Stop();
            fire.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }
}