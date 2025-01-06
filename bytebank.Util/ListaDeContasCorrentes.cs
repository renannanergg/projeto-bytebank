using System.ComponentModel;
using bytebank.Modelos.Conta;

namespace bytebank.Modelos.bytebank.Util;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private int _proximaPosicao = 0;

    public ListaDeContasCorrentes(int tamanho=5)
    {
        _itens = new ContaCorrente[tamanho];

    }
    public void ExibirLista()
    {
        for (int i = 0; i < _itens.Length; i++)
        {
            if(_itens[i] != null)
            {
                var conta = _itens[i];
                Console.WriteLine($"Índice {i} - Conta:{conta.Conta} - Agência: {conta.Numero_agencia}");
            }
        }
    }
    public void Adicionar(ContaCorrente item)
    {
        Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
        VerificarCapacidade(_proximaPosicao + 1);
        _itens[_proximaPosicao] = item;
        _proximaPosicao ++;

    }
    public void Remover(ContaCorrente conta)
    {
        int indiceItem = -1;
        for (int i = 0; i < _proximaPosicao; i++)
        {
            ContaCorrente contaAtual = _itens[i];
            if (contaAtual == conta)
            {
                indiceItem = i;
                break;
            }
        }

        for (int i = indiceItem; i < _proximaPosicao; i++)
        {
            _itens[i] = _itens[i + 1];

        }
        _proximaPosicao --;
        _itens[_proximaPosicao]= null;
    }
    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if (_itens.Length >= tamanhoNecessario)
        {
            return;
        }
        Console.WriteLine("Aumentando capacidade da lista....");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }

        _itens = novoArray;
    }
    public ContaCorrente RecuperarContaNoIndice(int indice)
    {
        if (indice <0 || indice >= _proximaPosicao)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }

        return _itens[indice];
    }
    public int Tamanho { 
        get
        {
            return _proximaPosicao;
        }
    }
    public ContaCorrente VerificarMaiorSaldo()
    {
        ContaCorrente conta = null;
        double maiorSaldo = 0;
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null)
            {
                if (_itens[i].Saldo > maiorSaldo)
                {
                    maiorSaldo = _itens[i].Saldo;
                    conta = _itens[i];
                }
            }
        }
        Console.WriteLine($"O maior saldo é de {maiorSaldo}");

        return conta;
    }

    public ContaCorrente this[int indice]
    {
        get
        {
            return RecuperarContaNoIndice(indice);
        }
    }


}