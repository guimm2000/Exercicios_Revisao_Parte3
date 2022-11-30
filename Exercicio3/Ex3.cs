using System;

public static class MetodoExtensao
{

    private static int Digitos(int valor)
    {
        int ordem = 0;
        while(valor != 0) 
        {
            valor /= 10;
            ordem++;
        }
        return ordem;
    }
    public static bool isArmstrong(this int valor)
    {
        int digitos = Digitos(valor);
        int soma = 0;
        int temp = valor;

        for(int i = 0; i < digitos; i++)
        {
            soma += Convert.ToInt32(Math.Pow(temp%10, digitos));
            temp /= 10;
        }
        Console.WriteLine("Os numeros a seguir sao numeros de Armstrong:");

        for(int i = 0; i < 10000; i++)
        {
            int digitosi = Digitos(i);
            int somai = 0;
            int tempi = i;

            for (int j = 0; j < digitosi; j++)
            {
                somai += Convert.ToInt32(Math.Pow(tempi % 10, digitosi));
                tempi /= 10;
            }
            if (somai == i) Console.WriteLine(i);
        }

        return soma == valor;
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite um numero para ver se e um numero de Armstrong:");
        int numero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine(numero.isArmstrong()?"O numero e um numero de Armstrong!":"O numero nao e um numero de Armstrong!");
    }
}