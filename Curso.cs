using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}");
            Console.WriteLine("Digite a Qtd. que você quer dar entrada");
            int entrada = int.Parse(Console.ReadLine());
            vagas = vagas + entrada;
            Console.WriteLine("Entrada Registrada!");
            Console.ReadLine();

        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}");
            Console.WriteLine("Digite a Qtd. que você quer dar entrada");
            int entrada = int.Parse(Console.ReadLine());
            vagas = vagas - entrada;
            Console.WriteLine("Saida Registrada!");
            Console.ReadLine();

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas Restantes: {vagas}");
            Console.WriteLine("===========================================");

        }
    }
}
