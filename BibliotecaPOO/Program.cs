using BibliotecaPOO.Entidades;
using BibliotecaPOO.Services;

namespace BibliotecaPOO
{
    class Program
    {
        public List<Emprestimo> emprestimosCadastrados = new List<Emprestimo>();
        public List<Usuario> usuariosCadastrados = new List<Usuario>();
        public List<Livro> Livros = new List<Livro>();

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
        static void MostrarMenuUsuarios()
        {
            Console.WriteLine("Qual dessas ações você deseja fazer: " +
                              "\n01) Cadastrar usuários;" +
                              "\n02) Listar usuários;" +
                              "\n03) Detalhes de um usuário;" +
                              "\n04) Escolher um usuário;\n");
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
                    break;
                case 3:
                    DetalhesUsuarios();
                    break;
                case 4:
                    EscolherUsuarios();
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
            foreach (var usuarios in usuariosCadastrados)
            {
                Console.WriteLine($"Id: {usuarios.Id}" +
                                  $"\nNome: {usuarios.Nome}" +
                                  $"\nQntd. Emprestimos: {usuarios.QuantidadeDeEmprestimos(usuarios.Emprestimos)}" +
                                  $"\n====================================\n");
            }
        }

        void DetalhesUsuarios()
        {
            ListarUsuarios();
            Console.WriteLine("Digite o ID do usuario selecionado:");
            int id = int.Parse(Console.ReadLine());
            DetalharUsuarioEscolhido(id);
        }

        void DetalharUsuarioEscolhido(int id)
        {
            foreach (var usuario in usuariosCadastrados)
            {
                if (usuario.Id == id)
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
        void EscolherUsuario()
        {
            ListarUsuarios();
            Console.WriteLine("Digite o ID do usuario selecionado:");
            int id = int.Parse(Console.ReadLine());
            
            MenuUsuarioEscolhido(id);
            
        }
        void MenuUsuarioEscolhido(int id)
        {
            Console.WriteLine();
        }
    }
}