using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public class UsuarioRepository
    {
        // Lista de usuários como propriedade da classe
        private List<Usuario> _usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "Vitor Rubim Passos", Email = "RM97092@fiap.com.br", Senha = "senha123", Cnpj = "62.668.078/0001-36", UrlImagem = "https://avatars.githubusercontent.com/u/48107882?v=4", IsFornecedor = true },
            new Usuario { Id = 2, Nome = "Natan Cruz", Email = "RM97324@fiap.com.br", Senha = "senha456", Cnpj = "99.755.179/0001-54", UrlImagem = "https://avatars.githubusercontent.com/u/111809342?v=4", IsFornecedor = false }
        };

        public UsuarioRepository() {}

        public IEnumerable<Usuario> FindAll()
        {
            return _usuarios;
        }

        public Usuario FindById(long id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void Create(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            // Atribuir um novo ID ao novo usuário
            usuario.Id = GetNextId();
            _usuarios.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var existingUser = _usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (existingUser != null)
            {
                // Atualizando as propriedades do usuário existente com as do usuário fornecido
                existingUser.Nome = usuario.Nome;
                existingUser.Email = usuario.Email;
                existingUser.Senha = usuario.Senha;
                existingUser.UrlImagem = usuario.UrlImagem;
                existingUser.Cnpj = usuario.Cnpj;
                existingUser.IsFornecedor = usuario.IsFornecedor;
            }
            else
            {
                throw new InvalidOperationException($"Usuário com ID {usuario.Id} não encontrado.");
            }
            
        }

        public void Delete(long id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
            }
            else
            {
                throw new InvalidOperationException($"Usuário com ID {id} não encontrado.");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            UsuarioRepository other = (UsuarioRepository)obj;
            return _usuarios.SequenceEqual(other._usuarios);
        }

        public override int GetHashCode()
        {
            return _usuarios.GetHashCode();
        }

        public override string ToString()
        {
            return $"UsuarioRepository: Contém {_usuarios.Count} usuários.";
        }

        // Método auxiliar para obter o próximo ID disponível
        private long GetNextId()
        {
            return _usuarios.Count > 0 ? _usuarios.Max(u => u.Id) + 1 : 1;
        }
    }
}