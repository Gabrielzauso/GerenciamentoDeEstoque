using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel adicionar entrada para E-Book, pois se trata de um produto virtual");
            Console.ReadLine();
            
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no e-book {nome}");
            Console.WriteLine("Digite a Qtd. de vendas que você quer da entrada");
            int entrada = int.Parse(Console.ReadLine());
            vendas = vendas + entrada;
            Console.WriteLine("Saida Registrada!");
            Console.ReadLine();

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas realizadas: {vendas}");
            Console.WriteLine("===========================================");
        }
    }
}
