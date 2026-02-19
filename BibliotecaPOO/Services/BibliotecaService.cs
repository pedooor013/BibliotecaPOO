using BibliotecaPOO.Entidades;

namespace BibliotecaPOO.Services;

public class BibliotecaService
{
    public void RealizarEmprestimo(Usuario usuario, Livro livro)
    {
        if (usuario.EhBloqueado())
        {
            Console.WriteLine("O seu status está BLOQUEADO! Não é possível realizar o emprestimo!");
            return;
        }

        if (!livro.Disponivel)
        {
            Console.WriteLine("O livro não está disponível para emprestimo!");
            return;
        }

        if (usuario.Emprestimos.Count >= 3)
        {
            Console.WriteLine("Limite de emprestimos extrapolado! Não é possível realizar o emprestimo!");
            return;
        }

        Emprestimo emprestimo = new Emprestimo(livro, usuario);

        livro.DefinirComoEmprestado();

        usuario.Emprestimos.Add(emprestimo);
    }

    public void DevolverLivro(Emprestimo emprestimo)
    {
        emprestimo.RegistrarDevolucao();

        bool ehAtrasado = emprestimo.EstaAtrasado();

        if (ehAtrasado)
        {
            int diasAtrasados = emprestimo.CalcularDiasAtrasados();

            double valorMultaPorAtraso = diasAtrasados * 0.75;
            Console.WriteLine(
                $"O livro está atrasado a {diasAtrasados} dias! Você tera que pagar uma multa de {valorMultaPorAtraso:C}!");
            Console.WriteLine("Por conta disso o seu status ficará como BLOQUEADO!");
            emprestimo.Usuario.BloquearUsuario();
        }

        emprestimo.Livro.DefinirComoNaoEmprestado();
    }
}