using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Estoque
{   
    [System.Serializable]
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (escolheuSair == false)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar entrada\n5-Registrar Saida\n6-Sair");
                int OpcSelecionada = int.Parse(Console.ReadLine());


                if (OpcSelecionada > 0 && OpcSelecionada < 7)
                {
                    Menu escolha = (Menu)OpcSelecionada;

                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastrar();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:                            
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }else{
                    escolheuSair = true;
                }
                Console.Clear();
            }
            
        }

        enum MenuCadastro { Produto = 1, Ebook, Curso };
        static void Cadastrar()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            int OpcSelecionada = int.Parse(Console.ReadLine());
            MenuCadastro escolha = (MenuCadastro)OpcSelecionada;

            switch (escolha)
            {
                case MenuCadastro.Produto:
                    CadastroPFisico();
                    break;
                case MenuCadastro.Ebook:
                    CadastrarEbook();
                    break;
                case MenuCadastro.Curso:
                    CadastrarCurso();
                    break;
            }
                 


        }

        static void CadastroPFisico()
        {
            Console.WriteLine("Cadastrando Produto Fisico");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);

            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, produtos);

            stream.Close();

        }

        static void Carregar()
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>) enconder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }


            }
            catch(Exception e)
            {

                produtos = new List<IEstoque>();

            }
            stream.Close();
        }

        static void Listagem()
        {
            
            Console.WriteLine("Lista de Produtos");
            int i = 0;
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine($"ID: {i}");
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }   

        static void Remover()
        {
            Console.WriteLine("Digite o Id do produto que deseja remover");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }

        }

        static void Entrada()
        {
            Console.WriteLine("Digite o Id que você quer da entrada");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }
        
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }


        }
    }

}
