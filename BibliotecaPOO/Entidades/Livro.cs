namespace BibliotecaPOO.Entidades;

public class Livro
{
    public int Id { get; private set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public bool Disponivel { get; private set; }
    private static int _contador = 0;

    public static int GerarId()
    {
        _contador++;
        return _contador;
    }

    //Metodos
    public void DefinirComoEmprestado()
    {
        Disponivel = false;
    }

    public void DefinirComoNaoEmprestado()
    {
        Disponivel = true;
    }

    public void PodeEmprestar()
    {
        if (Disponivel)
        {
            Console.WriteLine($"O livro {Titulo} pode ser emprestado!");
        }
        else
        {
            Console.WriteLine($"O livro {Titulo} não pode ser emprestado!");
        }
    }

    //Construtor
    public Livro(string titulo, string autor)
    {
        Id = GerarId();
        Titulo = titulo;
        Autor = autor;
        Disponivel = true;
    }
}