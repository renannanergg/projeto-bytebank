using bytebank.Modelos.Conta;
using bytebank.Exceptions;

namespace projeto_bytebank.bytebank.Atendimento;

#nullable disable
internal class ByteBankAtendimento
{
    private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>{
    new ContaCorrente(95, "123456-X") {Saldo=1000, Titular = new Cliente{Cpf = "222222",Nome = "João", Profissao = "Dev"}},
    new ContaCorrente(95, "951258-X") {Saldo=280, Titular = new Cliente{Cpf = "333333",Nome = "Maria", Profissao = "Cantora"}},
    new ContaCorrente(94, "987321-W") {Saldo=605, Titular = new Cliente{Cpf = "444444",Nome = "Ana", Profissao = "Dentista"}}
    };

    public void AtendimendoCliente()
    {
        try
        {
            char opcao = '0';
            while(opcao != '6')
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       Atendimento       ===");
                Console.WriteLine("===1 - Cadastrar Conta      ===");
                Console.WriteLine("===2 - Listar Contas        ===");
                Console.WriteLine("===3 - Remover Conta        ===");
                Console.WriteLine("===4 - Ordenar Contas       ===");
                Console.WriteLine("===5 - Pesquisar Conta      ===");
                Console.WriteLine("===6 - Sair do Sistema      ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n\n");
                Console.Write("Digite a opção desejada: ");
                try
                {
                    opcao = Console.ReadLine()[0];
                }
                catch (Exception excecao)
                {
                    
                    throw new ByteBankException(excecao.Message);
                }
                
                switch(opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverContas();
                        break;
                    case '4':
                        OrdenarContas();
                        break;
                    case '5':
                        ConsultarConta();
                        break;
                    case '6':
                        Encerrar();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
        }
        catch (ByteBankException excecao)
        {
            
            Console.WriteLine($"{excecao.Message}");
        }
        
    }
    private void Encerrar()
    {
        Console.WriteLine("Encerrando.....");
        Console.ReadKey();
    }

    private void ConsultarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===    PESQUISAR CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("(1) CONTA || (2) CPF TITULAR || (3) AGÊNCIA");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine()!);
        switch (opcao)
        {
            case 1:
                {
                    Console.Clear();
                    Console.Write("Informe o número da Conta: ");
                    string _numeroConta = Console.ReadLine()!;
                    ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                    Console.WriteLine(consultaConta.ToString());
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    Console.Clear();
                    Console.Write("Informe o CPF do Titular: ");
                    string _cpf = Console.ReadLine()!;
                    ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                    Console.WriteLine(consultaCpf.ToString());
                    Console.ReadKey();
                    break;
                }
            case 3:
                {
                    Console.Clear();
                    Console.Write("Informe o Numero da Agência: ");
                    int _numeroAgencia = int.Parse(Console.ReadLine()!);
                    var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                    ExibirContas(contasPorAgencia);
                    Console.ReadKey();
                    break;
                }
            default:
                Console.WriteLine("Opção não implementada.");
                break;
        }
    }

    private void ExibirContas(List<ContaCorrente> contasPorAgencia)
    {
        if (contasPorAgencia == null)
        {
            Console.WriteLine("Nenhum dado encontrado :(");
        }
        else
        {
            foreach (var conta in contasPorAgencia)
            {
                Console.WriteLine(conta.ToString());
            };
        }
    }

    private void OrdenarContas()
    {
        _listaDeContas.Sort();
        Console.WriteLine("Contas ordenadas com sucesso !");
        Console.ReadKey();
        
    }

    private void RemoverContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      REMOVER CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Informe o número da Conta: ");
        string numeroConta = Console.ReadLine()!;
        ContaCorrente conta = null;
        foreach (var item in _listaDeContas)
        {
            if (item.Equals(numeroConta))
            {
                conta = item;
            }
        }
        if (conta !=null)
        {
            _listaDeContas.Remove(conta);
            Console.WriteLine("Conta removida com sucesso !");
        }
        else
        {
            Console.WriteLine("Conta não localizada na nossa base de dados");
        }
        Console.ReadKey();
    }

    private void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===");

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine()!);

        ContaCorrente conta = new ContaCorrente(numeroAgencia);

        Console.WriteLine($"Número da conta [NOVA]: {conta.Conta}");

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine()!);

        Console.Write("Informe nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine()!;

        Console.Write("Informe CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine()!;

        Console.Write("Informe Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine()!;

        _listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }

    private void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     LISTA DE CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");

        if (_listaDeContas.Count < 0)
        {
            Console.WriteLine("Não há contas registradas!");
            Console.ReadKey();
            return;
        }
        foreach (ContaCorrente conta in _listaDeContas)
        {
            Console.WriteLine(conta.ToString());
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }

    List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
    {
        var consulta = (
            from conta in _listaDeContas
            where conta.Numero_agencia == numeroAgencia
            select conta).ToList();

        return consulta;
    }

    ContaCorrente ConsultaPorCPFTitular(string? cpf)
    {
    
    return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
    }

    ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
    {
        
        return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
    }


}
