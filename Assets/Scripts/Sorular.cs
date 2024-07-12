using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sorular : MonoBehaviour
{

    
    public List<Soru> sorular; 

    public List<BilgiSoru> bilgiler;

}

[System.Serializable]

public class Soru
{

    public string soruText, secenekA, secenekB, secenekC, secenekD;
    
    public string aciklama, kategori;
    public int dogruCevap;


    public Soru(string soru, string secenek1, string secenek2, string secenek3, string secenek4, int dCevap, string ktgr, string acklma)
    {

        soruText = soru;
        secenekA = secenek1;
        secenekB = secenek2;
        secenekC = secenek3;
        secenekD = secenek4;
        dogruCevap = dCevap;
        kategori = ktgr;
        aciklama = acklma;
    }

}


[System.Serializable]

public class BilgiSoru
{

    public string soruText;

    public string aciklama, kategori;

    public BilgiSoru(string soru, string ktgr, string acklma)
    {

        soruText = soru;
        kategori = ktgr;
        aciklama = acklma;
    }


}