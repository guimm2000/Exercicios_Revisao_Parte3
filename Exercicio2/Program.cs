using System;

public class IndiceRemissivo
{
    public string PathTXT { get; private set; }
    public string PathIgnore { get; private set; }

    public IndiceRemissivo(string pathTXT, string pathIgnore = null) 
    {
        if (pathTXT == null) throw new FileLoadException("Nao foi possivel abrir o arquivo!");

        this.PathTXT = File.ReadAllText(pathTXT);

        if (pathIgnore != null) this.PathIgnore = File.ReadAllText(pathIgnore);
        else this.PathIgnore = null;
    }

    public void Imprime()
    {
        char[] separadores =
        { ' ', ',', '.', ';', '<', '>', ':', '\\', '/', '|', '~', '^', '´', '`', '[', ']', '{', '}', '‘', '“', '!', '@', '#', '$', '%', '&', '*', '(', ')', '_', '+', '=', '\n' };

        List<string> palavras = new List<string>();
        List<string> palavrastemp = PathTXT.Split(separadores).ToList();
        List<string> palavrasIgnoradas = null;
        if (PathIgnore != null) 
        {
            palavrasIgnoradas = PathIgnore.Split('\n').ToList();
        }

        foreach(string palavra in palavrastemp)
        {
            if (!palavras.Contains(palavra))
            {
                if (palavrasIgnoradas != null && !palavrasIgnoradas.Contains(palavra))
                {
                    if(!palavra.Contains(separadores.ToString())) palavras.Add(palavra);
                }
                else if(palavrasIgnoradas == null) if (!palavra.Contains(separadores.ToString())) palavras.Add(palavra);
            }
        }

        palavras.Sort();

        var lines = PathTXT.Split('\n').ToList();

        foreach(string palavra in palavras) 
        {
            List<int> linhas = new List<int>();
            for(int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Contains(palavra))
                {
                    linhas.Add(i+1);
                }
            }

            Console.Write("{0} ({1}) ", palavra.ToUpper(), linhas.Count());
            Console.Write(linhas[0]);

            for (int i = 1; i < linhas.Count(); i++)
            {
                Console.Write(", {0}", linhas[i]);
            }

            Console.WriteLine("\n");

        }
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        IndiceRemissivo ir = new IndiceRemissivo("C:\\Users\\Guilherme\\Downloads\\texto.txt", "C:\\Users\\Guilherme\\Downloads\\ignore.txt");
        ir.Imprime();
    }
}