using System;

public class Cliente
{
    public string Nome { get; private set; }
    public long Cpf { get; private set; }

    public Cliente(string nome, long cpf)
    {
        this.Nome = nome;
        this.Cpf = cpf;
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Cliente)) return false;

        return (this.Cpf.Equals(((Cliente)obj).Cpf) && this.Nome.Equals(((Cliente)obj).Nome));
    }
}

