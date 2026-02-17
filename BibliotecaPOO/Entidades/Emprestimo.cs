namespace BibliotecaPOO.Entidades;

public class Emprestimo
{
    public Livro Livro { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucao { get; private set; }
    public DateTime? DataQueFoiDevolvido { get; private set; }

    public void RegistrarDevolucao()
    {
        DataQueFoiDevolvido = DateTime.Now;
    }

    public bool EstaAtivo()
    {
        return DataQueFoiDevolvido != null;
    }

    public bool EstaAtrasado()
    {
        if (DataQueFoiDevolvido > DataDevolucao)
        {
            return true;
        }

        return false;
    }

    public int CalcularDiasAtrasados()
    {
        if (DataQueFoiDevolvido == null)
        {
            return 0;
        }
        else
        {
            int diasDiferenca = (DataQueFoiDevolvido.Value - DataDevolucao).Days;
            return diasDiferenca;
        }
    }

    private static int _contador = 0;

    public static int GerarId()
    {
        _contador++;
        return _contador;
    }

    //Construtor
    public Emprestimo(Livro livro, Usuario usuario)
    {
        Livro = livro;
        Usuario = usuario;
        DataEmprestimo = DateTime.Now.Date;
        DataDevolucao = DataEmprestimo.AddDays(7);
    }
}