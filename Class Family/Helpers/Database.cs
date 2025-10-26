using SQLite;
using Class_Family.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Class_Family.Helpers
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            Task.Run(() => InitializeAllTablesAsync()).Wait();
        }

        private async Task InitializeAllTablesAsync()
        {
            await _database.CreateTableAsync<Usuario>();
            await _database.CreateTableAsync<Aluno>();
            await _database.CreateTableAsync<Professor>();
            await _database.CreateTableAsync<Responsavel>();
            await _database.CreateTableAsync<Disciplina>();
            await _database.CreateTableAsync<Boletim>();
            await _database.CreateTableAsync<Comunicado>();
            await _database.CreateTableAsync<Agenda>();
            await _database.CreateTableAsync<Frequencia>();

            await SeedInitialDataAsync();
        }

        private async Task SeedInitialDataAsync()
        {
            if (await _database.Table<Usuario>().CountAsync() > 0)
            {
                return;
            }

            // --- 1. CRIAÇÃO DE USUÁRIOS E REGISTROS RELACIONADOS ---

            // Cria usuário Professor
            var userProf = new Usuario { Nome = "João Professor", Email = "joao@escola.com", Senha = "123", Tipo = "Professor" };
            await _database.InsertAsync(userProf);

            // Cria registro Professor
            await _database.InsertAsync(new Professor { UsuarioId = userProf.Id });

            // Cria usuário Aluno
            var userAluno = new Usuario { Nome = "Maria Aluna Teste", Email = "maria@escola.com", Senha = "123", Tipo = "Aluno" };
            await _database.InsertAsync(userAluno);

            // Cria registro Aluno linkado ao usuário
            await _database.InsertAsync(new Aluno { UsuarioId = userAluno.Id, Matricula = "2025001", TurmaId = 1 });

            // --- 2. CRIAÇÃO DE DISCIPLINAS ---
            await _database.InsertAsync(new Disciplina { Nome = "Matemática", ProfessorId = userProf.Id, TurmaId = 1 });
            await _database.InsertAsync(new Disciplina { Nome = "Português", ProfessorId = userProf.Id, TurmaId = 1 });
        }

        public async Task SalvarUsuario(Usuario usuario)
        {
            if (usuario.Id == 0)
                await _database.InsertAsync(usuario);
            else
                await _database.UpdateAsync(usuario);
        }

        public async Task SalvarAluno(Aluno aluno)
        {
            if (aluno.Id == 0)
                await _database.InsertAsync(aluno);
            else
                await _database.UpdateAsync(aluno);
        }

        public async Task SalvarProfessor(Professor professor)
        {
            if (professor.Id == 0)
                await _database.InsertAsync(professor);
            else
                await _database.UpdateAsync(professor);
        }

        public async Task SalvarResponsavel(Responsavel responsavel)
        {
            if (responsavel.Id == 0)
                await _database.InsertAsync(responsavel);
            else
                await _database.UpdateAsync(responsavel);
        }

        public async Task SalvarComunicado(Comunicado comunicado)
        {
            if (comunicado.Id == 0)
                await _database.InsertAsync(comunicado);
            else
                await _database.UpdateAsync(comunicado);
        }

        public async Task SalvarAgenda(Agenda agenda)
        {
            if (agenda.Id == 0)
                await _database.InsertAsync(agenda);
            else
                await _database.UpdateAsync(agenda);
        }

        public async Task SalvarBoletim(Boletim boletim)
        {
            if (boletim.Id == 0)
                await _database.InsertAsync(boletim);
            else
                await _database.UpdateAsync(boletim);
        }

        // MÉTODO QUE ESTAVA GERANDO ERRO:
        public Task<Aluno> ObterAlunoPorUsuarioId(int usuarioId)
        {
            // O uso de .Where() e .FirstOrDefaultAsync() exige 'using System.Linq' e 'using SQLite'
            return _database.Table<Aluno>().Where(a => a.UsuarioId == usuarioId).FirstOrDefaultAsync();
        }

        public Task<List<Usuario>> ListarUsuarios()
            => _database.Table<Usuario>().ToListAsync();

        public Task<List<Aluno>> ListarAlunos()
            => _database.Table<Aluno>().ToListAsync();

        public Task<List<Disciplina>> ListarDisciplinas()
            => _database.Table<Disciplina>().ToListAsync();

        public Task<List<Comunicado>> ListarComunicados()
            => _database.Table<Comunicado>().OrderByDescending(c => c.DataEnvio).ToListAsync();

        public Task<List<Agenda>> ListarEventos()
            => _database.Table<Agenda>().OrderByDescending(a => a.Data).ToListAsync();

        public Task<List<Boletim>> ListarBoletins()
        {
            return _database.Table<Boletim>().ToListAsync();
        }

        public Task<int> DeletarUsuario(Usuario usuario)
            => _database.DeleteAsync(usuario);

        public Task<int> DeletarComunicado(Comunicado comunicado)
            => _database.DeleteAsync(comunicado);

        public Task<int> DeletarEvento(Agenda agenda)
            => _database.DeleteAsync(agenda);
    }
}