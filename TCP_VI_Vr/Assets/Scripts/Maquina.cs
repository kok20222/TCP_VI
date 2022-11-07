using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Maquina : MonoBehaviour
{

    contagemRegressiva Contador1 = new contagemRegressiva();

    public TMP_Text lavarroupa1;
    public int roupas = 2;
    bool aux=false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Contador1.IsRunning)
        {
            Contador1.Contagem(); // Contando...
            lavarroupa1.text = "Tempo:  " + Contador1.FormatarTempo((int)Contador1.tempoTotal);
            if (roupas==3 && Contador1.tempoTotal <= 0)
            {
               roupas=4;
            }
        }

        

        if(roupas == 3 && Contador1.IsRunning==false){
            contagemRegressiva();
            

        }
        if(roupas < 3){

            
        lavarroupa1.text =  roupas + "/3";

        } 
         if(roupas ==4){
            lavarroupa1.text =   "Lavagem finalizada!";
            MenuController.instance.panelTrue(MenuController.instance.checks[1]);
            MenuController.instance.panelTrue(MenuController.instance.checks[3]);
            if(aux==false){
                MenuController.instance.vitoryCond++;
                aux=true;
            }
            
        }


        
        
    }
    void OnTriggerEnter(Collider other){

            if(other.tag == "roupa"){ 


                 roupas ++;

            }
            



        }



        void OnTriggerExit(Collider other){

            if(other.tag == "roupa"){


                roupas --;

            }
            



        }

        public void contagemRegressiva()
    {
        
            Contador1.IniciarContador(20f);
        
        //chamar funcao para abrir porta e come�ar o jogo
    }
    private void FixedUpdate()
    {
        // Contador 1
        
    }
}
