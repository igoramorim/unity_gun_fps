using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atirar : MonoBehaviour {

    // Esse script e responsvel pelas acoes do Player com a arma: atirar, mira com zoom, recarregar e trocar de arma
    // Ele tambem exibe na tela o nome da arma atual e a municao

    public GameObject[] armas;
    public int armaAtual = 0;

    public Text nomeArma;
    public Text municaoArma;

    // Use this for initialization
    void Start() {
        EsconderArmas();
        ExibirArma(armaAtual);
    }

    // Update is called once per frame
    void Update() {
        Disparar();
        Recarregar();
        AtualizarStatus();
        TrocarArma();
    }

    void AtualizarStatus() {
        nomeArma.text = armas[armaAtual].name;
        var arma = armas[armaAtual].GetComponent<Arma>();
        municaoArma.text = arma.municaoAtual + " / " + arma.municaoTotal;
    }

    void Disparar() {
        if (Input.GetButton("Fire1")) {
            armas[armaAtual].GetComponent<Arma>().TiroPrincipal();

        } else if(Input.GetButtonDown("Fire2")) {
            armas[armaAtual].GetComponent<Arma>().TiroSecundario();
        }
    }

    void Recarregar() {
        if (Input.GetKeyDown(KeyCode.R)) {
            armas[armaAtual].GetComponent<Arma>().Recarregar();
        }
    }

    void TrocarArma() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            armaAtual++;
            if (armaAtual > armas.Length - 1) {
                armaAtual = 0;
            }
            EsconderArmas();
            ExibirArma(armaAtual);
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            armaAtual--;
            if (armaAtual < 0) {
                armaAtual = armas.Length - 1;
            }
            EsconderArmas();
            ExibirArma(armaAtual);
        }
    }

    void ExibirArma(int i) {
        armas[i].SetActive(true);
    }

    void EsconderArmas() {
        for(int i = 0; i < armas.Length; i++) {
            armas[i].SetActive(false);
        }
    }
}
