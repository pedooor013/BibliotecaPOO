using BibliotecaPOO.Entidades;

namespace BibliotecaPOO.Services;

public class BibliotecaService
{
 public void RealizarEmprestimo(Usuario usuario, Livro livro)
 {
     if (usuario.StatusUsuario == Usuario.Status.Bloqueado)
     {
         Console.WriteLine("O seu status está BLOQUEADO! Não é possível realizar o emprestimo!");
         return;
     }

     if (!livro.Disponivel)
     {
         Console.WriteLine("O livro não está disponível para emprestimo!");
         return;
     }

     if (usuario.Emprestimos.Count > 3)
     {
         Console.WriteLine("Limite de emprestimos extrapolado! Não é possível realizar o emprestimo!");
         return;
     }
     Emprestimo emprestimo = new Emprestimo(livro, usuario);
     
     usuario.Emprestimos.Add(emprestimo);
 }   
 
 
}