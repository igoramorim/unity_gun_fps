using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    // Esse script e responsavel pelas acoes da arma: disparar, recarregar e mirar com zoom

    public Transform spawnPoint;    // Posicao onde o tiro sera criado. E um GameObject vazio que fica na ponta da arma
    public GameObject tiro;         // Objeto 3D do tiro. Deve possuir o script Tiro para funcionar
    public int municaoAtual;        // Quantidade de municao carregada na arma
    public int municaoTotal;        // Quantidade de municao para recarregar
    public int pente;               // Quantidade de balas em um pente
    public float delay;             // Delay entre os tiros
    public bool podeAtirar;         // Variavel responsavel por controlar quando o jogador pode ou nao atirar
    private float timer;            // Timer usado para fazer o delay do tiro
    public GameObject cameraZoom;   // Camera usada para fazer a mira com zoom. Ela e criada na Unity e posicionada atras da arma
    public bool zoom;               // Variavel responsavel por controlar quando a mira com zoom esta ativda ou nao

	// Configuracoes iniciais
	void Start () {
        podeAtirar = true;          // Habilitamos o tiro no inicio do jogo
        timer = 0;                  // Resetamos o timer
        zoom = false;               // Desligamos a mira com zoom   
	}
	
	// A todo momento verificamos se ja passou o delay para o jogador poder atirar novamente
    // E se a mira com zoom esta ativada ou nao
	void Update () {
        ChecarDelay();
        ChangeZoom();
    }

    // Funcao que recarrega a arma
    public void Recarregar() {
        // Para recarregar a arma, a municaoAtual precisa ser diferente da quantidade de balas do pente
        // Exemplo: se a arma do seu jogo tem um pente de 30 balas, voce nao consegue recarregar se estiver assim 30/100
        // Se voce disparar uma bala e ficar 29/100 voce ja consegue e apos recarregar, ficaria 30/99
        if (municaoAtual != pente) {
            // Variavel local para descobrir a quantidade de balas que precisamos recarregar
            // Para descobrir esse valor, fazemos a quantidade do pente MENOS a quantidade de municao carregada
            // No exemplo acima seria: 29 (municao atual carregada) - 30 (pente) = 1
            int recarregar = pente - municaoAtual;
            // Temos que verificar se a municao total e maior ou igual a quantidade que precisamos carregar
            // E assim retirar da municao total a quantidade que precisamos e adicionar na municao atual
               
            // Caso a municao total seja menor que a quantidade que precisamos para preencher o pente, a programacao entra no ELSE
            // Exemplo: 15/10 e o pente e de 30
            // Preciso recarregar 15 balas para ficar com o pente cheio, mas so tenho 10 para recarregar
            // Nesse caso, pegamos toda a municao total e colocamos na atual
            if (municaoTotal >= recarregar) {
                municaoTotal -= recarregar;
                municaoAtual += recarregar;
            } else {
                municaoAtual += municaoTotal;
                municaoTotal -= municaoTotal;
            }
        }
    }

    // Funcao que dispara o tiro. Ela e executada no script Atirar que fica no Player
    public void TiroPrincipal() {
        // O jogador so pode atirar se possui municao carregada, por isso, municaoAtual > 0
        // E (&&) se o delay ja passou, ou seja, podeAtirar em TRUE
        if (municaoAtual > 0 && podeAtirar) {
            // Cria o objeto tiro na posicao do spawnPoint e
            // com a rotacao do GameObject GunPoint (objeto vazio que "guarda" as armas),
            // por isso, o spawnPoint.parent.parent. Parent significa objeto pai
            Instantiate(tiro, spawnPoint.position, spawnPoint.parent.parent.rotation);
            // Diminui 1 da municao atual
            municaoAtual -= 1;
            // Troca o podeAtirar para FALSE, assim o jogador precisa esperar o delay acabar
            podeAtirar = false;
        }
        // Se a municaoAtual acabar, ou seja, for menor do que 0, recarregue!!!
        if(municaoAtual <= 0) {
            Recarregar();
        }
    }

    // Funcao que faz o delay da arma
    void ChecarDelay() {
        // Se a variavel podeAtirar estiver em FALSE , ou seja, quando o jogador nao puder atirar
        if (!podeAtirar) {
            // Aumentamos o valor de timer em 1 segunda (Time.deltaTime)
            timer += Time.deltaTime;
            // Se o timer for maior ou igual ao delay
            if (timer >= delay) {
                // Trocamos a variavel podeAtirar para TRUE, assim o jogador podera atirar novamente
                podeAtirar = true;
                // E zeramos o timer para começar de novo
                timer = 0;
            }
        }
    }

    // Funcao TiroSecundario() e executada quando o jogador clica com o botao direito no script Atirar
    public void TiroSecundario() {
        // Invertemos o valor da variavel zoom
        // Se ela estiver TRUE, vai para FALSE    Se estiver FALSE, vai para TRUE
        // Fazemos isso usando o sinal ! que significa negacao
        // Exemplo: porta aberta, porta fechada, quente, frio, chato, legal
        zoom = !zoom;
    }

    // Funcao que ativa e desativa a camera que fica atras da arma (mira com zoom)
    void ChangeZoom() {
        // Se o zoom  estiver desativado e o jogador apertar o botao direito, ative a mira com zoom
        // Senao, desligue a mira
        if (zoom) {
            cameraZoom.SetActive(true);     // Liga a mira
        } else {                               
            cameraZoom.SetActive(false);    // Desliga a mira
        }
    }

    // Funcao responsavel por aumentar a municao da arma
    public void AumentarMunicao(int municao) {
        // A arma recebe a municao da CaixaMunicao e aumenta esse valor em sua municaoTotal
        municaoTotal += municao;
    }
}
