using System;
using System.ComponentModel.DataAnnotations;


namespace Floricultura.Domain.Entities
{
public class Flor
{
public Guid Id { get; private set; }


[Required]
[StringLength(100)]
public string Nome { get; private set; }


[StringLength(500)]
public string Descricao { get; private set; }


[Range(0.0, double.MaxValue)]
public decimal Preco { get; private set; }


[Range(0, int.MaxValue)]
public int Estoque { get; private set; }


public DateTime CriadoEm { get; private set; }


public bool Disponivel => Estoque > 0;


// Construtor para EF
protected Flor() { }


public Flor(string nome, string descricao, decimal preco, int estoque)
{
Id = Guid.NewGuid();
SetNome(nome);
SetDescricao(descricao);
SetPreco(preco);
SetEstoque(estoque);
CriadoEm = DateTime.UtcNow;
}


// métodos para encapsular regras do domínio
public void SetNome(string nome)
{
if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome é obrigatório");
if (nome.Length > 100) throw new ArgumentException("Nome muito longo");
Nome = nome;
}


public void SetDescricao(string descricao)
{
Descricao = descricao?.Trim();
}


public void SetPreco(decimal preco)
{
if (preco < 0) throw new ArgumentException("Preço não pode ser negativo");
Preco = preco;
}


public void SetEstoque(int estoque)
{
if (estoque < 0) throw new ArgumentException("Estoque não pode ser negativo");
Estoque = estoque;
}


public void AbaterEstoque(int quantidade)
{
if (quantidade <= 0) throw new ArgumentException("Quantidade inválida");
if (quantidade > Estoque) throw new InvalidOperationException("Estoque insuficiente");
Estoque -= quantidade;
}
}
}