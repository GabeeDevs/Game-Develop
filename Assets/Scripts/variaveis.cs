using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class variaveis : MonoBehaviour {

    int moedas;
    void Start(){ // Aqui roda uma vez só, quando iniciado.

        moedas = 10;
        print(moedas);

    }


    void Update() // Vai ficar rodando sempre
    {
        moedas = 10;
        print($"marquim tem {moedas}");
    }



}
