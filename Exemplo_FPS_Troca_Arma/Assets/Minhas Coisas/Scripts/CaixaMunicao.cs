using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaMunicao : MonoBehaviour {

    //A caixa de municao praticamente nao possui acoes no jogo
    //Usamos um script nela simplesmente para dizer a quantidade de municao que ela "carrega"
    //A parte boa de ter um script para isso, e que podemos ter varias caixas no jogo com quantidade de
    //municoes diferentes usando o mesmo script!!!

    public int quantidadeMunicao;   //Variavel que guarda a quantidade de municao que a caixa possui
                                    //e vai "dar" para o jogador, caso ele encoste nela

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
