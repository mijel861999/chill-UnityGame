 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0.2f, 0.2f, -15f); //Distancia a la que sigue al personaje

    public float dampingTime = 0.3f;

    public Vector3 velocity = Vector3.zero;

    public static Camera_follow sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null) {
            sharedInstance = this;
        }
        //frames a los que debe ir el juego
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera(true);    
    }

    void ResetCameraPosition() {
        MoveCamera(false);
    }

    void MoveCamera(bool smooth) {
        Vector3 destination = new Vector3(target.position.x - offset.x, target.position.y - offset.y, offset.z);

        if (smooth == true)
        {
            //El smoothdamp cambia el valor del vector de manera gradual, no será de golpe
            this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dampingTime);
        }
        else {
            //Acá si será de golpe
            this.transform.position = destination;
        }
    }
}
