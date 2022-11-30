using System;

public static class ExtensaoLista
{
    public static void RemoveRepetidos<T>(this List<T> lista)
    {
        for(int i = 0; i < lista.Count(); i++)
        {
            for(int j = i+1; j < lista.Count(); j++)
            {
                if (lista[i].Equals(lista[j])) lista.RemoveAt(j);
            }
        }
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        //Testando Lista de Inteiros
        List<int> testeInt = new List<int>();
        testeInt.Add(10);
        testeInt.Add(20);
        testeInt.Add(30);
        testeInt.Add(10);
        testeInt.Add(20);
        testeInt.Add(30);
        testeInt.RemoveRepetidos();
        foreach(int i in testeInt)
        {
            Console.WriteLine(i);
        }

        //Pula linha
        Console.WriteLine();
        Console.WriteLine();

        List<string> testeString = new List<string>();
        testeString.Add("Hello");
        testeString.Add("World");
        testeString.Add("!");
        testeString.Add("Hello");
        testeString.Add("World");
        testeString.Add("!");
        testeString.RemoveRepetidos();
        foreach (string s in testeString)
        {
            Console.WriteLine(s);
        }

        //Pula linha
        Console.WriteLine();
        Console.WriteLine();

        List<Cliente> testeCliente = new List<Cliente>();
        testeCliente.Add(new Cliente("Henrique", 10));
        testeCliente.Add(new Cliente("Joao", 10));
        testeCliente.Add(new Cliente("Henrique", 11));
        testeCliente.Add(new Cliente("Henrique", 10));
        testeCliente.Add(new Cliente("Joao", 10));
        testeCliente.Add(new Cliente("Carlos", 15));
        testeCliente.RemoveRepetidos();
        foreach (Cliente c in testeCliente)
        {
            Console.WriteLine("Nome: {0}\tCPF: {1}", c.Nome, c.Cpf);
        }
    }
}