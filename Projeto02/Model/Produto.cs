using System.ComponentModel.DataAnnotations;

namespace Projeto02.Model;

public class ProdutoModel
{
	private long _id;
	private string? _nome;
	private decimal _preco;
	private int _quantidade;

	[Key]
	public long ProdutoID
	{
		get { return _id; }
		set { _id = value; }
	}

	public string Nome
	{
		get { return _nome; }
		set
		{
			if (!string.IsNullOrEmpty(value))
				_nome = value;
			else
				throw new ArgumentException("O nome não pode ser vazio.");
		}
	}

	public decimal Preco
	{
		get { return _preco; }
		set
		{
			if (value > 0)
				_preco = value;
			else
				throw new ArgumentException("O preço deve ser maior que zero.");
		}
	}

	public int Quantidade
	{
		get { return _quantidade; }
		set
		{
			if (value >= 0)
				_quantidade = value;
			else
				throw new ArgumentException("A quantidade não pode ser negativa.");
		}
	}
}
