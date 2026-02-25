using BibliotecaPOO.Entidades;
using BibliotecaPOO.Services;

namespace BibliotecaPOO
{
    class Program
    {
        static public List<Usuario> UsuariosCadastrados = new List<Usuario>();
        static public List<Livro> LivrosCadastrados = new List<Livro>();
        static BibliotecaService bibliotecaService = new BibliotecaService();

        static public void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de gerenciamento da biblioteca ===");
            MostrarMenuPrincipal();
        }

        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("Qual ação você deseja fazer: " +
                              "\n01) Usuários;" +
                              "\n02) Livros;" +
                              "\n03) Sair;\n");
            int escolhaUser = int.Parse(Console.ReadLine());

            DecisaoUsuario(escolhaUser);
        }

        static void DecisaoUsuario(int escolhaUser)
        {
            switch (escolhaUser)
            {
                case 1:
                    MostrarMenuUsuarios();
                    break;
                case 2:
                    MostrarMenuLivros();
                    break;
                case 3:
                    Console.WriteLine("Saindo...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Valor inválido! Digite novamente!");
                    MostrarMenuPrincipal();
                    break;
            }
        }

        //Usuários
        static void MostrarMenuUsuarios()
        {
            Console.WriteLine("Qual dessas ações você deseja fazer: " +
                              "\n01) Cadastrar usuários;" +
                              "\n02) Listar usuários;" +
                              "\n03) Detalhes de um usuário;" +
                              "\n04) Escolher um usuário;" +
                              "\n05) Menu principal;\n");
            int escolhaUser = int.Parse(Console.ReadLine());
            DecisaoUsuarioUsuarios(escolhaUser);
        }

        static void DecisaoUsuarioUsuarios(int escolhaUser)
        {
            switch (escolhaUser)
            {
                case 1:
                    CadastrarUsuarios();
                    break;
                case 2:
                    ListarUsuarios();
                    MostrarMenuPrincipal();
                    break;
                case 3:
                    DetalharUsuarioEscolhido();
                    break;
                case 4:
                    EscolherUsuario();
                    break;
                case 5:
                    MostrarMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Digite novamente!");
                    MostrarMenuUsuarios();
                    break;
            }
        }

        static void CadastrarUsuarios()
        {
            Console.WriteLine("\nCadastro de usuário:" +
                              "\nNome usuário:");
            string nome = Console.ReadLine();
            Usuario usuario = new Usuario(nome);

            UsuariosCadastrados.Add(usuario);

            Console.WriteLine("Usuário cadastrado com sucesso!");

            MostrarMenuPrincipal();
        }

        static void ListarUsuarios()
        {
            foreach (var usuarios in UsuariosCadastrados)
            {
                Console.WriteLine($"Id: {usuarios.Id}" +
                                  $"\nNome: {usuarios.Nome}" +
                                  $"\nQntd. Emprestimos: {usuarios.QuantidadeDeEmprestimos(usuarios.Emprestimos)}" +
                                  $"\n====================================\n");
            }
        }

        static void DetalharUsuarioEscolhido()
        {
            ListarUsuarios();

            Console.WriteLine("Digite o ID do usuario escolhido: ");
            int id = int.Parse(Console.ReadLine());

            int contador = 0;
            foreach (var usuario in UsuariosCadastrados)
            {
                if (usuario.Id == id)
                {
                    Console.WriteLine($"Informações Usuário:" +
                                      $"\nId: {usuario.Id}" +
                                      $"\nNome: {usuario.Nome}" +
                                      $"\nStatus: {usuario.StatusUsuario}");
                    Console.WriteLine("Lista de Emprestimos: ");
                    usuario.ListarEmprestimos();
                    contador++;
                    MostrarMenuPrincipal();
                }
            }

            if (contador != 1)
            {
                Console.WriteLine("ID inválido! Digite novamente!");
                DetalharUsuarioEscolhido();
            }
        }

        static void EscolherUsuario()
        {
            ListarUsuarios();
            Console.WriteLine("Digite o ID do usuario selecionado:");
            int id = int.Parse(Console.ReadLine());

            MenuUsuarioEscolhido(id);
        }

        static void MenuUsuarioEscolhido(int id)
        {
            Console.WriteLine("01) Realizar um emprestimo;" +
                              "\n02) Devolver um livro;" +
                              "\n03) Listar emprestimos;" +
                              "\n04) Escolher outro usuário;" +
                              "\n05) Sair;");
            int escolha = int.Parse(Console.ReadLine());
            DecisaoAcaoUsuario(escolha, id);
        }

        static void DecisaoAcaoUsuario(int escolha, int idUsuario)
        {
            switch (escolha)
            {
                case 1:
                    CadastrarEmprestimo(idUsuario);
                    break;
                case 2:
                    DevolverLivro(idUsuario);
                    break;
                case 3:
                    ListarEmprestimosAtivos(idUsuario);
                    break;
                case 4:
                    EscolherUsuario();
                    break;
                case 5:
                    MostrarMenuUsuarios();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Digite novamente...");
                    MenuUsuarioEscolhido(idUsuario);
                    break;
            }
        }

        static void ListarEmprestimosAtivos(int idUsuario)
        {
            foreach (var usuario in UsuariosCadastrados)
            {
                if (usuario.Id == idUsuario)
                {
                    Console.WriteLine($"Informações Usuário:" +
                                      $"\nId: {usuario.Id}" +
                                      $"\nNome: {usuario.Nome}" +
                                      $"\nStatus: {usuario.StatusUsuario}");
                    Console.WriteLine("Lista de Emprestimos: ");
                    usuario.ListarEmprestimos();
                }
            }
            MostrarMenuPrincipal();
        }

        static void CadastrarEmprestimo(int idUsuario)
        {
            ListarLivrosDisponiveis();
            Console.WriteLine("Digite o ID do livro escolhido:");
            int idLivro = int.Parse(Console.ReadLine());

            Livro livro = SelecionarLivroPorId(idLivro);
            Usuario usuario = SelecionarUsuarioPorId(idUsuario);

            bibliotecaService.RealizarEmprestimo(usuario, livro);
            MostrarMenuPrincipal();
        }

        static void ListarLivrosDisponiveis()
        {
            foreach (var livro in LivrosCadastrados)
            {
                if (livro.Disponivel)
                {
                    Console.WriteLine($"\nID: {livro.Id};" +
                                      $"Titulo: {livro.Titulo};" +
                                      $"\nAutor: {livro.Autor};" +
                                      $"\n===============================");
                }
            }
        }

        static void DevolverLivro(int idUsuario)
        {
            ListarEmprestimosUsuarioPorId(idUsuario);

            Console.WriteLine("Digite o ID do livro que deseja devolver: ");
            int idEmprestimo = int.Parse(Console.ReadLine());


            Usuario usuario = SelecionarUsuarioPorId(idUsuario);

            Emprestimo emprestimo = SelecionarEmprestimoPorId(usuario, idEmprestimo);

            if (emprestimo == null)
            {
                Console.WriteLine("Nenhum emprestimo encontrado! Digite novamente!");
                DevolverLivro(idUsuario);
            }

            bibliotecaService.DevolverLivro(emprestimo);
            MostrarMenuPrincipal();
        }

        static void ListarEmprestimosUsuarioPorId(int idUsuario)
        {
            foreach (var usuario in UsuariosCadastrados)
            {
                if (usuario.Id == idUsuario)
                {
                    usuario.ListarEmprestimos();
                }
            }
        }

        static Emprestimo SelecionarEmprestimoPorId(Usuario usuario, int idEmprestimo)
        {
            foreach (var emprestimo in usuario.Emprestimos)
            {
                if (emprestimo.Livro.Id == idEmprestimo)
                {
                    return emprestimo;
                }
            }

            return null;
        }

        static Usuario SelecionarUsuarioPorId(int idUsuario)
        {
            foreach (var usuario in UsuariosCadastrados)
            {
                if (usuario.Id == idUsuario)
                {
                    return usuario;
                }
            }

            return null;
        }

        static Livro SelecionarLivroPorId(int idLivro)
        {
            foreach (var livro in LivrosCadastrados)
            {
                if (livro.Id == idLivro)
                {
                    return livro;
                }
            }

            return null;
        }

        //Livros

        static void MostrarMenuLivros()
        {
            Console.WriteLine($"Menu de Livros:" +
                              $"\n01) Cadastrar um livro;" +
                              $"\n02) Listar todos os livros;" +
                              $"\n03) Sair;");

            Console.WriteLine("Escolha o que deseja fazer:");
            int escolhaUsuario = int.Parse(Console.ReadLine());

            DecisaoUsuarioLivros(escolhaUsuario);
        }

        static void DecisaoUsuarioLivros(int escolha)
        {
            switch (escolha)
            {
                case 1:
                    CadastrarLivro();
                    break;
                case 2:
                    ListarTodosLivros();
                    break;
                case 3:
                    MostrarMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Digite novamente...");
                    MostrarMenuLivros();
                    break;
            }
        }

        static void CadastrarLivro()
        {
            Console.WriteLine("Digite o titulo do livro:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o nome do autor do livro:");
            string nomeAutor = Console.ReadLine();

            Livro livro = new Livro(titulo, nomeAutor);

            LivrosCadastrados.Add(livro);

            Console.WriteLine("Livro cadastrado com sucesso!");

            MostrarMenuPrincipal();
        }

        static void ListarTodosLivros()
        {
            Console.WriteLine("Todos os livros cadastrados no sistema: ");

            foreach (var livro in LivrosCadastrados)
            {
                Console.WriteLine($"ID: {livro.Id}, " +
                                  $"\nTitulo: {livro.Titulo};" +
                                  $"\nAutor: {livro.Autor};");
                if (livro.Disponivel)
                {
                    Console.WriteLine("Status: Disponivel;");
                }
                else
                {
                    Console.WriteLine("Status: Não disponivel;");
                }

                Console.WriteLine("==================");
            }

            MostrarMenuPrincipal();
        }
    }
}