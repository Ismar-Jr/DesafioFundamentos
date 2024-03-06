using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DesafioFundamentos
{
    public class Estacionamento
    {
        private double precoInicial;
        private double precoPorHora;
        private string removido = " ";
        private List<string> listaVeiculos = new List<string>();
    
        public void abrirEstacionamento()
        {
            telaInicial();

            menuInterativo();

        }

        //Metodos para a criação de tela incial e menu interativo

        private void telaInicial()
        {
            Console.WriteLine("Seja bem vindo ao sistema de estacionamento!" + "\nDigite o preço incial: ");
            Double.TryParse(Console.ReadLine(), out precoInicial);
            Console.WriteLine("Digite o preço por hora: ");
            Double.TryParse(Console.ReadLine(), out precoPorHora);

            Console.Clear();
        }

        private void menuInterativo()
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
                        cadastrarVeiculo();
                        break;
                    case 2:
                        removerVeiculo();
                        break;
                    case 3:
                        listarVeiculos();
                        break;
                    case 4: 
                        Console.WriteLine("O programa será encerrado");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
                limparTela();

            }while(opcao != 4);

        }
        private void limparTela()
        {
            Console.WriteLine("Aperte qualquer tecla para continuar: ");
            Console.ReadLine();
            Console.Clear();
        }

        //Metodos de controle de cadastro e remoção de veiculos

        private void cadastrarVeiculo()
        {
            Console.WriteLine(" Digite a placa do veículo para estacionar: (Formato AAA-0000)");
            string adicionar  = Console.ReadLine().ToUpper();
            if(adicionar != null){
                listaVeiculos.Add(adicionar);
            }
        }

        private void removerVeiculo()
        {
            listarVeiculos();
            Console.WriteLine("\nEscolha um veículo da lista acima para remover");
            removido = Console.ReadLine().ToUpper();
            if (listaVeiculos.Contains(removido) && removido != null)
            {
                listaVeiculos.Remove(removido);
                pagarEstacionameto();
            }
            else
            {
                Console.WriteLine("Veiculo não encontrado na lista");
            }
        }

        private void listarVeiculos()
        {
            Console.WriteLine("Os veículos estacionados são: ");
            foreach(string carros in listaVeiculos)
            {
                Console.WriteLine(carros);
            }
        }

        private void pagarEstacionameto()
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            
            int.TryParse(Console.ReadLine(), out int totalHora);

            double precoFinal = totalHora * precoPorHora + precoInicial;

            Console.WriteLine($"O veículo {removido} foi removido e o preço total foi de: R${precoFinal}");

        }

       
    }

        
}