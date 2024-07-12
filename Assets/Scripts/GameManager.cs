using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

 
    public Button buttonA, buttonB, buttonC, buttonD;
    public Color yesilRenk, kirmiziRenk, beyazRenk, sariRenk;
    public Text soruText, secenekA, secenekB, secenekC, secenekD;   int dogruCevap;   

    public float sure;     public Text sureText;
    public int puan;       public Text puanText;
    public int soruSayisi; public Text soruSayisiText;

    public GameObject aciklamaPanel, aciklamaButton, yeniSoruButton; public Text panelText;

    public GameObject ogrenPanel, yarisPanel;
    public Text ogrenSoruText; public int ogrenSoruSayisi; public Text ogrenSoruSayisiText;
   


    Sorular sr; 
    public List<bool> sorulanlar;
    public List<bool> bilgiSorulanlar;


    void Start()
    {

        sr = GetComponent<Sorular>();

        aciklamaPanel.SetActive(false);
     

        if (MainMenu.mod == "Yaris")
        {
            ogrenPanel.SetActive(false);
            yarisPanel.SetActive(true);

            

            aciklamaButton.gameObject.SetActive(false);
            yeniSoruButton.gameObject.SetActive(false);

            for (int i = 0; i < sr.sorular.Count; i++)
            {
                sorulanlar.Add(false);

            }

              SoruEkle();

        }
        else if((MainMenu.mod == "Ogren"))
        {
            Debug.Log("Öðrenme");

            ogrenPanel.SetActive(true);
            yarisPanel.SetActive(false);

            for (int i = 0; i < sr.bilgiler.Count; i++)
            {
                bilgiSorulanlar.Add(false);

            }
            OgrenSoruEkle();


        }



    }


    public void OgrenSoruEkle()
    {

        if (ogrenSoruSayisi < 8) 
        {

            int sorusayi = Random.Range(0, bilgiSorulanlar.Count);

            if (bilgiSorulanlar[sorusayi] == false)
            {
                bilgiSorulanlar[sorusayi] = true;


                ogrenSoruText.text = sr.bilgiler[sorusayi].soruText;
                
                panelText.text = sr.bilgiler[sorusayi].aciklama;



                ogrenSoruSayisi++; ogrenSoruSayisiText.text = ogrenSoruSayisi.ToString();

               
            }
            else
            {
                OgrenSoruEkle();
            }

        }
        else
        {

            Debug.Log("Bu Test Bitti. ");

          
        }

    }

  
    void Update()
    {
        
            if (sure > 0 && sure != 99)                                                                       
            {
                sure -= Time.deltaTime;
                sureText.text = sure.ToString("00");
            }
            if (sure < 0)  
            {
                Debug.Log("Süre Bitti Kaybettin");

                puan -= 1; puanText.text = puan.ToString();

                sure = 99;

                aciklamaButton.gameObject.SetActive(true);
                yeniSoruButton.gameObject.SetActive(true);

            }
        

        

    }



    public void SoruEkle()
    {


        aciklamaButton.gameObject.SetActive(false);
        yeniSoruButton.gameObject.SetActive(false);

        buttonA.image.color = beyazRenk;
        buttonB.image.color = beyazRenk;
        buttonC.image.color = beyazRenk;
        buttonD.image.color = beyazRenk;

        if (soruSayisi < 5) 
        {

            int sorusayi = Random.Range(0, sorulanlar.Count);

            if (sorulanlar[sorusayi] == false)
            {
                sorulanlar[sorusayi] = true;


                soruText.text = sr.sorular[sorusayi].soruText;
                secenekA.text = sr.sorular[sorusayi].secenekA;
                secenekB.text = sr.sorular[sorusayi].secenekB;
                secenekC.text = sr.sorular[sorusayi].secenekC;
                secenekD.text = sr.sorular[sorusayi].secenekD;

                panelText.text = sr.sorular[sorusayi].aciklama;

                dogruCevap = sr.sorular[sorusayi].dogruCevap;

                soruSayisi++; soruSayisiText.text = soruSayisi.ToString();

                sure = 15;
            }
            else
            {
                SoruEkle();
            }

        }
        else
        {

            Debug.Log("Bu Test Bitti. ");

            sure = 99;
        }



    }

    public void CevapVer(int deger)
    {


        if (sure != 99)
        {

            if (deger == dogruCevap)
            {
                Debug.Log("Doðru Cevap");
                sure = 99;

                if (deger == 1)
                    buttonA.image.color = yesilRenk;
                if (deger == 2)
                    buttonB.image.color = yesilRenk;
                if (deger == 3)
                    buttonC.image.color = yesilRenk;
                if (deger == 4)
                    buttonD.image.color = yesilRenk;

                puan += 2; puanText.text = puan.ToString();



            }
            else
            {
                Debug.Log("Yanlýþ Cevap");
                sure = 99;

                if (dogruCevap == 1) 
                    buttonA.image.color = sariRenk;
                if (dogruCevap == 2)
                    buttonB.image.color = sariRenk;
                if (dogruCevap == 3)
                    buttonC.image.color = sariRenk;
                if (dogruCevap == 4)
                    buttonD.image.color = sariRenk;

                if (deger == 1)
                    buttonA.image.color = kirmiziRenk;
                if (deger == 2)
                    buttonB.image.color = kirmiziRenk;
                if (deger == 3)
                    buttonC.image.color = kirmiziRenk;
                if (deger == 4)
                    buttonD.image.color = kirmiziRenk;

                puan -= 1; puanText.text = puan.ToString();



            }

            if(MainMenu.mod == "Yaris")
            {
                aciklamaButton.gameObject.SetActive(true);
                yeniSoruButton.gameObject.SetActive(true);

            }

        }
    }

    public void PanelYonetimi(int x)
    {
        if(x==0)
        {
            aciklamaPanel.SetActive(true);
        }
        else if(x==1)
        {
            aciklamaPanel.SetActive(false);
        }

    }

    public void AnaMenuDon()
    {
        SceneManager.LoadScene(0);
    }






}
