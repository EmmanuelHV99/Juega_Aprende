using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GenerarPreguntaL : MonoBehaviour {
	private string [] preguntas= null;
	private string[] respuestas=null;
	private bool funciona =  false;
	private int indice, materia;
	public Text Pregunta;
	public TextMesh RespuestaCorrecta, RIncorrecta1, RIncorrecta2, RIncorrecta3, RIncorrecta4;
	// Use this for initialization
	void Start () {
		/*preguntas [0] = "¿Cuál es la montaña más alta del mundo?";
		respuestas [0] = "Monte Everest";
		preguntas [1] = "¿Cuál es la capital de Jalisco?";
		preguntas [2] = "¿A qué temperatura se congela el agua?";
		preguntas [3] = "¿Cuál es el océano más grande del mundo?";
		preguntas [4] = "¿En qué continente está Australia?";*/
		materia= Random.Range(0,5);
        switch(materia){
            case 0:
                preguntas= File.ReadAllLines("Assets/Preg-Resp/Preguntas/Ciencias.txt");
                respuestas= File.ReadAllLines("Assets/Preg-Resp/Respuestas/RCiencias.txt");
                if(preguntas!=null){
                    funciona=true;
                }
                break;
            case 1:
                preguntas= File.ReadAllLines("Assets/Preg-Resp/Preguntas/Fisica.txt");
                respuestas= File.ReadAllLines("Assets/Preg-Resp/Respuestas/RFisica.txt");
                if(preguntas!=null){
                    funciona=true;
                }
                break;
            case 2:
                preguntas= File.ReadAllLines("Assets/Preg-Resp/Preguntas/Geografia.txt");
                respuestas= File.ReadAllLines("Assets/Preg-Resp/Respuestas/RGeografia.txt");
                if(preguntas!=null){
                    funciona=true;
                }
                break;
            case 3:
                preguntas= File.ReadAllLines("Assets/Preg-Resp/Preguntas/Historia.txt");
                respuestas= File.ReadAllLines("Assets/Preg-Resp/Respuestas/RHistoria.txt");
                if(preguntas!=null){
                    funciona=true;
                }
                break;
            case 4:
                preguntas= File.ReadAllLines("Assets/Preg-Resp/Preguntas/Matematicas.txt");
                respuestas= File.ReadAllLines("Assets/Preg-Resp/Respuestas/RMatematicas.txt");
                if(preguntas!=null){
                    funciona=true;
                }
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider trig){
        if(trig.gameObject.tag=="Player"){
            NuevaPregunta();
        }
    }
	
	void OnTriggerExit(Collider exit){
        if(exit.gameObject.tag=="Player"){
            Pregunta.text="";
            RespuestaCorrecta.text="";
            RIncorrecta1.text="";
            RIncorrecta2.text="";
        }
    }
	void NuevaPregunta(){
        int indiceI, indiceC;
        if(funciona){
            indiceC=Random.Range(0,30);
            Pregunta.text= AcomodoTexto(preguntas[indiceC]);
            RespuestaCorrecta.text= AcomodoTexto(respuestas[indiceC]);//Respuesta correcta
            indiceI=Random.Range(0,30);
            while(indiceC==indiceI){
                indiceI=Random.Range(0,30);
            };
            RIncorrecta1.text=AcomodoTexto(respuestas[indiceI]);//respuesta incorrecta 1
            indiceI=Random.Range(0,30);
            while(indiceC==indiceI){
                indiceI=Random.Range(0,30);
            };
            RIncorrecta2.text= AcomodoTexto(respuestas[indiceI]);//respuesta incorrecta 2
            indiceI=Random.Range(0,30);
            while(indiceC==indiceI){
                indiceI=Random.Range(0,30);
            };
            RIncorrecta3.text= AcomodoTexto(respuestas[indiceI]);//respuesta incorrecta 2
            indiceI=Random.Range(0,30);
            while(indiceC==indiceI){
                indiceI=Random.Range(0,30);
            };
            RIncorrecta4.text= AcomodoTexto(respuestas[indiceI]);//respuesta incorrecta 2
        }
        
    }
	string AcomodoTexto(string linea){
        char caracter;
        string sublinea="";
        byte contador=0;
        for (int i = 0; i < linea.Length; i++)
        {
            caracter=linea[i];
            sublinea=sublinea+caracter;
            if(caracter==' ')
                contador++;
            if(contador==4){
                sublinea=sublinea+" \n";
                contador=0;
            }
        }
        return sublinea;
    }
}
