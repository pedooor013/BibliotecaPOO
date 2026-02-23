using BibliotecaPOO.Entidades;
using BibliotecaPOO.Services;

namespace BibliotecaPOO
{
    class Program
    {
        public List<Emprestimo> EmprestimosCadastrados = new List<Emprestimo>();
        public List<Usuario> UsuariosCadastrados = new List<Usuario>();
        public List<Livro> LivrosCadastrados = new List<Livro>();
        BibliotecaService bibliotecaService = new BibliotecaService();

        public static void Main(string[] args)
        {
            MostrarMenuPrincipal();
        }

        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("Qual ação você deseja fazer: " +
                              "\n01) Usuários;" +
                              "\n02) Livros;" +
                              "\n03) Emprestimos;" +
                              "\n04) Sair;\n");
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
                    MostrarMenuEmprestimos();
                    break;
                case 4:
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
        void MostrarMenuUsuarios()
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

        void DecisaoUsuarioUsuarios(int escolhaUser)
        {
            switch (escolhaUser)
            {
                case 1:
                    CadastrarUsuarios();
                    break;
                case 2:
                    ListarUsuarios();
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

            Console.WriteLine("Usuário cadastrado com sucesso!");

            MostrarMenuPrincipal();
        }

        void ListarUsuarios()
        {
            foreach (var usuarios in UsuariosCadastrados)
            {
                Console.WriteLine($"Id: {usuarios.Id}" +
                                  $"\nNome: {usuarios.Nome}" +
                                  $"\nQntd. Emprestimos: {usuarios.QuantidadeDeEmprestimos(usuarios.Emprestimos)}" +
                                  $"\n====================================\n");
            }
        }

        void DetalharUsuarioEscolhido()
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
                    return;
                }
            }

            if (contador != 1)
            {
                Console.WriteLine("ID inválido! Digite novamente!");
                DetalharUsuarioEscolhido();
            }
        }

        void EscolherUsuario()
        {
            ListarUsuarios();
            Console.WriteLine("Digite o ID do usuario selecionado:");
            int id = int.Parse(Console.ReadLine());

            MenuUsuarioEscolhido(id);
        }

        void MenuUsuarioEscolhido(int id)
        {
            Console.WriteLine("01) Realizar um emprestimo;" +
                              "\n02) Devolver um livro;" +
                              "\n03) Listar emprestimos;" +
                              "\n04) Escolher outro usuário;" +
                              "\n05) Sair;");
            int escolha = int.Parse(Console.ReadLine());
            DecisaoAcaoUsuario(escolha, id);
        }

        void DecisaoAcaoUsuario(int escolha, int idUsuario)
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

        void ListarEmprestimosAtivos(int idUsuario)
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
                    return;
                }
            }
        }

        void CadastrarEmprestimo(int idUsuario)
        {
            ListarLivrosDisponiveis();
            Console.WriteLine("Digite o ID do livro escolhido:");
            int idLivro = int.Parse(Console.ReadLine());

            Livro livro = SelecionarLivroPorId(idLivro);
            Usuario usuario = SelecionarUsuarioPorId(idUsuario);

            bibliotecaService.RealizarEmprestimo(usuario, livro);
        }

        void ListarLivrosDisponiveis()
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

        void DevolverLivro(int idUsuario)
        {
            
        }

        Usuario SelecionarUsuarioPorId(int idUsuario)
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

        Livro SelecionarLivroPorId(int idLivro)
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
    }
}