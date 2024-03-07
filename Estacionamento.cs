namespace DesafioFundamentos
{
    public class Estacionamento
    {
        private double _precoInicial;
        private double _precoPorHora;
        private string _removido = " ";
        private List<string> _listaVeiculos = new List<string>();

        public void AbrirEstacionamento()
        {
            TelaInicial();

            MenuInterativo();

        }

        //Metodos para a criação de tela incial e menu interativo

        private void TelaInicial()
        {
            Console.WriteLine("Seja bem vindo ao sistema de estacionamento!" + "\nDigite o preço incial: ");
            Double.TryParse(Console.ReadLine(), out _precoInicial);
            Console.WriteLine("Digite o preço por hora: ");
            Double.TryParse(Console.ReadLine(), out _precoPorHora);

            Console.Clear();
        }

        private void MenuInterativo()
        {
            int opcao;
            do
            {
                Console.WriteLine("Escolha uma opção: " +
                "\n1 - Cadastrar veículo" +
                "\n2 - Remover veículo" +
                "\n3 - Listar veículos" +
                "\n4 - Encerrar");

                           
                int.TryParse(Console.ReadLine(), out opcao);
                
                switch(opcao)
                {
                    case 1:
                        CadastrarVeiculo();
                        break;
                    case 2:
                        RemoverVeiculo();
                        break;
                    case 3:
                        ListarVeiculos();
                        break;
                    case 4: 
                        Console.WriteLine("O programa será encerrado");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
                LimparTela();

            }while(opcao != 4);

        }
        private void LimparTela()
        {
            Console.WriteLine("Aperte qualquer tecla para continuar: ");
            Console.ReadLine();
            Console.Clear();
        }

        //Metodos de controle de cadastro e remoção de veiculos

        private void CadastrarVeiculo()
        {
            Console.WriteLine(" Digite a placa do veículo para estacionar: (Formato AAA-0000)");
             string adicionar = Console.ReadLine().ToUpper();
             _listaVeiculos.Add(adicionar);
            
        }

        private void RemoverVeiculo()
        {
            ListarVeiculos();
            Console.WriteLine("\nEscolha um veículo da lista acima para remover");
            _removido = Console.ReadLine().ToUpper();
            if (_listaVeiculos.Contains(_removido))
            {
                _listaVeiculos.Remove(_removido);
                PagarEstacionameto();
            }
            else
            {
                Console.WriteLine("Veiculo não encontrado na lista");
            }
        }

        private void ListarVeiculos()
        {
            Console.WriteLine("Os veículos estacionados são: ");
            foreach(string carros in _listaVeiculos)
            {
                Console.WriteLine(carros);
            }
        }

        private void PagarEstacionameto()
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            
            int.TryParse(Console.ReadLine(), out int totalHora);

            double precoFinal = totalHora * _precoPorHora + _precoInicial;

            Console.WriteLine($"O veículo {_removido} foi removido e o preço total foi de: R${precoFinal}");

        }

       
    }

        
}