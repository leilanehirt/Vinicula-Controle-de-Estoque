//Leilane Catherine John Hirt - Sistemas Para Internet  - Senac
namespace ControleDeEstoque_Vinícula
{
    public class Funcoes
    {
        Vinho[] vinhos = new Vinho[0];

        public void Novo(Vinho novoVinho)
        {
            // CRIA UM VETOR COM UMA POSIÇÃO A MAIS
            Vinho[] novoVetor = new Vinho[vinhos.Length + 1];

            // COPIA OS ITENS DO VETOR PRINCIPAL PARA O NOVO VETOR
            for (int pos = 0; pos < vinhos.Length; pos++)
            {
                novoVetor[pos] = vinhos[pos];
            }

            // INCLUI O NOVO ITEM
            novoVetor[novoVetor.Length - 1] = novoVinho;

            // ATUALIZA O VETOR PRINCIPAL
            vinhos = novoVetor;
        }

        public void Listar()
        {
            Console.WriteLine("\n\t ------------------- Lista de Produtos ------------------ \n");

            for (int pos = 0; pos < vinhos.Length; pos++)
            {
                Vinho item = vinhos[pos];
                Console.WriteLine($"{pos + 1}. {item.Produto} {item.Tipo} ({item.Litros} l), Safra: {item.Safra} | R$ {item.Valor:N2} | {item.Estoque} no estoque.");
                //na listagem ficará assim:
                //1.Vinho Branco Seco(1,5 l), Safra: 2020| R$ 45,00 | 10 no estoque.
            }
        }

        public void Remover(int posRemove)
        {
            // CRIA UM VETOR COM UMA POSIÇÃO A MENOS
            Vinho[] novoVetor = new Vinho[vinhos.Length - 1];

            for (int pos = 0; pos < novoVetor.Length; pos++)
            {
                if (pos >= posRemove)
                {
                    novoVetor[pos] = vinhos[pos + 1];
                }
                else
                {
                    novoVetor[pos] = vinhos[pos];
                }
            }

            vinhos = novoVetor;
        }

        public void Entrada(int posicao, int qtd)
        {
            vinhos[posicao].Estoque += qtd;
        }

        public void Saida(int posicao, int qtd)
        {
            if (vinhos[posicao].Estoque < qtd)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nA quantidade atual em estoque ({vinhos[posicao].Estoque} unidades) não é suficiente para realizar esta ação!");
                Console.ResetColor();                
                Console.WriteLine("\nDigite uma quantia válida!");
            }
            else
            {
                vinhos[posicao].Estoque -= qtd;
                Console.WriteLine("\nEstoque atualizado com sucesso!\n");
            }

        }

        public void CaixaCerteza()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            //Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t--------------------------------------------------------");
            Console.WriteLine("\t| VOCÊ TEM CERTEZA QUE DESEJA REALIZAR ESSA AÇÃO??     |");
            Console.WriteLine("\t| Uma vez realizada, a ação não poderá ser desfeita.   |");
            Console.WriteLine("\t|         |1|sim, remover     |0|não, cancelar         |");
            Console.WriteLine("\t--------------------------------------------------------");
            Console.ResetColor(); 
        }

        public void Menu()
        {
            Vinho vn = new Vinho();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n[1] Novo | [2] Listar Produtos | [3] Remover Produtos | [4] Entrada Estoque | [5] Saída Estoque | [0] Sair");
            Console.ResetColor(); 
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1) //cadastro
            {
                Console.WriteLine("\n\t--------------- Cadastro de Novo Produto ---------------\n");
                Console.Write("Informe o nome do produto: \t");
                vn.Produto = Console.ReadLine();

                Console.Write("informe o tipo do vinho: \t");
                vn.Tipo = Console.ReadLine();

                Console.Write("Informe o tamanho (litros): \t");
                vn.Litros = double.Parse(Console.ReadLine());

                Console.Write("Informe o ano da safra: \t");
                vn.Safra = int.Parse(Console.ReadLine());

                while(vn.Safra > 2023) {
                    Console.WriteLine("\n\tSafra do futuro? Digite um ano válido!");
                    Console.Write("\nInforme o ano da safra: \t");
                    vn.Safra = int.Parse(Console.ReadLine());
                }

                Console.Write("Informe o valor do produto: \tR$ ");
                vn.Valor = double.Parse(Console.ReadLine());

                Novo(vn);

                Console.WriteLine("\n\nProduto cadastrado com sucesso!\n");
                //Console.WriteLine($"{vn.Produto} {vn.Tipo} ({vn.Litros} l), Safra: {vn.Safra} | R$ {vn.Valor:N2} |{vn.Estoque} no estoque.");

                Menu();
            }
            else if (opcao == 2) //listar
            {
                Listar();
                Menu();
            }
            else if (opcao == 3) //Remover item da lista
            {
                Console.WriteLine("\n\t -------------------- Remover Produto -------------------\n");
                Console.WriteLine("Informe o índice do item que deseja remover: ");
                int indice = int.Parse(Console.ReadLine());
                CaixaCerteza();
                Console.Write("\nDigite: ");
                int confirma = int.Parse(Console.ReadLine());
                
                if (confirma == 1)
                {
                    Console.WriteLine("\nRemovendo...");
                    Remover(indice - 1);
                    Console.WriteLine("Removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nAção cancelada com sucesso!\n");
                }

                Menu();
            }
            else if(opcao == 4) //Entrada no estoque
            {
                Console.WriteLine("\n\t---------------- Atualização de Estoque ----------------");
                Console.WriteLine("\t----------------------- Entrada ------------------------\n");

                Console.WriteLine("Informe o índice do item: ");
                 int indice = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe a quantidade: ");
                int qnt = int.Parse(Console.ReadLine());

                Entrada(indice-1, qnt);
                Console.WriteLine("\nEstoque atualizado com sucesso!\n");
                Menu();
            }
            else if(opcao == 5) // Saída
            {
                Console.WriteLine("\n\t---------------- Atualização de Estoque ----------------");
                Console.WriteLine("\t------------------------- Saída ------------------------\n");


                Console.WriteLine("Informe o índice do item: ");
                int indice = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe a quantidade: ");
                int qnt = int.Parse(Console.ReadLine());

                Saida(indice - 1, qnt);
                
                Menu();
            }
            else
            {
                Console.WriteLine("\nFim do programa........................");
            }
        }

    }

}
