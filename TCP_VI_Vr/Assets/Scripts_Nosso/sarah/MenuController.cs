using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TMP_InputField tempoInput;
    public TMP_Text SOBRA;
    public GameObject[] checks;
    public GameObject macaneta;
    public GameObject TextTime1Ui;
    public GameObject vitoriaUI;
    public GameObject derrotaUI;
    public TMP_Text TextTimeHand;
    public GameObject iniciarBtn;
    public GameObject imageCheck0, imageCheck1;
    public GameObject imag0, imag1;
    public float valor;
    public Slider mental, comida, higiene;
    public TMP_Text mText, cText, hText;
    public static MenuController instance;
    contagemRegressiva Contador1 = new contagemRegressiva();
    public TMP_Text TextTime1;
    public int vitoryCond=0;

    // Start is called before the first frame update
    void Start() {
        instance = this;
        mental.value=0.5f;
        
        comida.value=0.5f;
        
        higiene.value=0.5f;
        
    }
    public void atualizarSliders(int i){
        if(i==0){
            mText.text=(mental.value*100).ToString()+"%";
        }
        if(i==1){
            cText.text=(comida.value*100).ToString()+"%";
        }
        if(i==2){
            hText.text=(higiene.value*100).ToString()+"%";
        }
    }
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void panelTrue(GameObject go){
        go.SetActive(true);
    }
     public void panelFalse(GameObject go){
        go.SetActive(false);
    }
    public void nextScene(int nextSceneIndex){
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void movimentacaoConfig(int mov){
        if(mov==0){//tp
            //movimentaciontConfig.instance.teleportEnable=true;
        }
        if(mov==1){//joystick
            //movimentaciontConfig.instance.teleportEnable=false;
        }

    }
    public void quit()
    {
        Application.Quit();
    }
    public void contagemRegressiva(float v)
    {
        macaneta.SetActive(true);
        TextTime1Ui.SetActive(true);
        iniciarBtn.SetActive(false);
        valor = v;
        Contador1.IniciarContador((int)valor);
    }

    public void chooseMov(int i){
        if(i==0){
            imageCheck0.SetActive(true);
            imageCheck1.SetActive(false);
            imag0.SetActive(true);
            imag1.SetActive(false);
            //chamar analogico
        }
        if(i==1){
            imageCheck0.SetActive(false);
            imageCheck1.SetActive(true);
            imag0.SetActive(false);
            imag1.SetActive(true);
            //chamar teleporte
        }
        
    }

    
    private void FixedUpdate()
    {
        // Contador 1
        if (Contador1.IsRunning)
        {
            Contador1.Contagem(); // Contando...
            TextTime1.text = "Tempo:  " + Contador1.FormatarTempo((int)Contador1.tempoTotal);
             TextTimeHand.text = "Tempo:  " + Contador1.FormatarTempo((int)Contador1.tempoTotal);

             if(vitoryCond<2 && Contador1.tempoTotal<0){
                panelTrue(derrotaUI);
                 Time.timeScale = 0;
             }
            
        }
        if(vitoryCond==2){
            float tempoSobra = Contador1.tempoInicial - Contador1.tempoTotal;
             SOBRA.text = Contador1.FormatarTempo((int)tempoSobra);
            panelTrue(vitoriaUI);
            Time.timeScale = 0;
        }
        
    }
    
    
}
