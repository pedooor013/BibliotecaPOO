namespace BibliotecaPOO.Entidades;

public class Usuario
{
    public int Id { get; private set; }
    public string Nome { get; set; }
    public List<Emprestimo> Emprestimos { get; private set; }
    public enum Status
    {
        Ativo,
        Bloqueado
    }

    Status StatusUsuario { get; set; }

    //Metodos 
    
    public void BloquearUsuario()
    {
        StatusUsuario = Status.Bloqueado;
    }
    
    public void DesbloquearUsuario()
    {
        StatusUsuario = Status.Ativo;
    }

    public bool EhBloqueado()
    {
        return StatusUsuario == Status.Bloqueado;
    }

    public void AdicionarEmprestimo(Emprestimo emprestimo)
    {
        Emprestimos.Add(emprestimo);
    }

    public void RemoverEmprestimo(Emprestimo emprestimo)
    {
        Emprestimos.Remove(emprestimo);
    }

    public int QuantidadeDeEmprestimos(List<Emprestimo> emprestimos)
    {
        return Emprestimos.Count;
    }
    
    
    //Gerador de ID
    private static int _contador = 0;
    public static int GerarId()
    {
        _contador++;
        return _contador;
    }
    
    //Construtor
    public Usuario(string nome)
    {
        Id = GerarId();
        Nome = nome;
        Emprestimos = new List<Emprestimo>();
        StatusUsuario = Status.Ativo;
    }
}