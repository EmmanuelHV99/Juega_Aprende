using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class MovimientoJugador : MonoBehaviour
{

    public float runSpeed = 7, rotationSpeed = 150;
    public Animator animator;
    private int NivelActual, EscenaFinal;
    public Text TVida;
    public Slider BVida;
    private double VidaTotal=2;
    private float x, y;

    void Start(){
        EscenaFinal=SceneManager.sceneCountInBuildSettings;
        NivelActual = SceneManager.GetActiveScene().buildIndex;
        if(NivelActual==1){
            VidaTotal=1.25;
        }
        if(NivelActual==2){
            VidaTotal=1;
        }
        if(NivelActual==3){
            VidaTotal=.75;
        }
        if(NivelActual==4){
            VidaTotal=.6;
        }
        if(NivelActual==5){
            VidaTotal=0.4;
        }
        if(NivelActual==6){
            VidaTotal=0.3;
        }
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        
        y = Input.GetAxis("Vertical");
        
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        transform.Translate(0, 0, y * Time.deltaTime *runSpeed);
        
        
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
        
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="falsa"){
			SceneManager.LoadScene (NivelActual);
		}
        if(col.gameObject.tag=="avanzar"){
            SceneManager.LoadScene((EscenaFinal-1));
        }
        
        
    }
    void OnTriggerStay(Collider stay){
		if(stay.gameObject.tag=="generarpregunta"){
            BVida.value-=(float)(VidaTotal);
            TVida.text="Vida "+(int)(BVida.value/10)+" %";
            VidaCero((int)BVida.value);
        }
	}
    void VidaCero(int vida){
        if(vida==0)
            SceneManager.LoadScene(NivelActual);
        
    }
}
