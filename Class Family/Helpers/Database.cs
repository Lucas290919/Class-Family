using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Class_Family.Models;

namespace Class_Family.SQLite
{
    public class Database
    {
        readonly SQLiteAsyncConnection _db;
        public Database(string path)
        {
            _db.CreateTableAsync<Usuario>().Wait();
            _db.CreateTableAsync<Professor>().Wait();
            _db.CreateTableAsync<Aluno>().Wait();
            _db.CreateTableAsync<Responsavel>().Wait();
            _db.CreateTableAsync<Turma>().Wait();
            _db.CreateTableAsync<Disciplina>().Wait();
            _db.CreateTableAsync<Boletim>().Wait();
            _db.CreateTableAsync<Frequencia>().Wait();
            _db.CreateTableAsync<Comunicado>().Wait();
            _db.CreateTableAsync<Agenda>().Wait();

            CriarDadosTeste().Wait();
        }

        // Inserir ou atualizar
        public async Task<int> Salvar<T>(T entity) where T : new()
        {
            if (await _db.UpdateAsync(entity) == 0)
            {
                return await _db.InsertAsync(entity);
            }
            return 1;
        }

        // Listar todos
        public Task<List<T>> Listar<T>() where T : new()
        {
            return _db.Table<T>().ToListAsync();
        }

        // Buscar por ID
        public Task<T> BuscarPorId<T>(object id) where T : new()
        {
            return _db.FindAsync<T>(id);
        }

        // Deletar
        public Task<int> Deletar<T>(T entity) where T : new()
        {
            return _db.DeleteAsync(entity);
        }

        // ========================
        // MÉTODOS ESPECÍFICOS
        // ========================

        // Login de usuário
        public Task<Usuario> Login(string email, string senha)
        {
            return _db.Table<Usuario>()
                      .Where(u => u.Email == email && u.Senha == senha)
                      .FirstOrDefaultAsync();
        }

        // Buscar alunos por turma
        public Task<List<Aluno>> ListarAlunosPorTurma(int turmaId)
        {
            return _db.Table<Aluno>()
                      .Where(a => a.TurmaId == turmaId)
                      .ToListAsync();
        }

        // Buscar boletim por aluno
        public Task<List<Boletim>> BuscarBoletimDoAluno(int alunoId)
        {
            return _db.Table<Boletim>()
                      .Where(b => b.AlunoId == alunoId)
                      .ToListAsync();
        }

        private async Task CriarDadosTeste()
        {
            var usuarios = await _db.Table<Usuario>().ToListAsync();

            if (usuarios.Count == 0)
            {
                var aluno = new Usuario { Nome = "João Silva", Email = "joao@escola.com", Senha = "123", Tipo = "Aluno" };
                var professor = new Usuario { Nome = "Maria Souza", Email = "maria@escola.com", Senha = "456", Tipo = "Professor" };
                var responsavel = new Usuario { Nome = "Carlos Silva", Email = "carlos@escola.com", Senha = "789", Tipo = "Responsavel" };

                await _db.InsertAsync(aluno);
                await _db.InsertAsync(professor);
                await _db.InsertAsync(responsavel);

                var turma = new Turma { Nome = "3º Ano A", Serie = "3º Ensino Médio" };
                await _db.InsertAsync(turma);

                await _db.InsertAsync(new Aluno { UsuarioId = aluno.ID, Matricula = "2025A001", TurmaId = turma.Id });
                await _db.InsertAsync(new Professor { UsuarioId = professor.ID, Disciplina = "Matemática" });
                await _db.InsertAsync(new Responsavel { UsuarioId = responsavel.ID });

                await _db.InsertAsync(new Comunicado
                {
                    Titulo = "Bem-vindos!",
                    Mensagem = "Início do ano letivo!",
                    Data = DateTime.Now,
                    Remetente = "Secretaria"
                });
            }
        }
    }
}