using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarNivel : MonoBehaviour
{
    private int nivelAnterior;
    private bool bandera=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RegresarElNivel(){
        if(bandera){
            SceneManager.LoadScene(nivelAnterior);
            bandera=false;
        }
        
    }
    public void GuardarNivel(int e){
        nivelAnterior=e;
        bandera=true;
    }
}
