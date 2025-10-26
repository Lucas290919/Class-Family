using SQLite;
using Class_Family.Models;

namespace Class_Family.Helpers
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Usuario>().Wait();
            _database.CreateTableAsync<Aluno>().Wait();
            _database.CreateTableAsync<Professor>().Wait();
            _database.CreateTableAsync<Responsavel>().Wait();
            _database.CreateTableAsync<Disciplina>().Wait();
            _database.CreateTableAsync<Boletim>().Wait();
            _database.CreateTableAsync<Comunicado>().Wait();
            _database.CreateTableAsync<Agenda>().Wait();
            _database.CreateTableAsync<Frequencia>().Wait();
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

        public Task<List<Usuario>> ListarUsuarios()
            => _database.Table<Usuario>().ToListAsync();

        public Task<List<Comunicado>> ListarComunicados()
            => _database.Table<Comunicado>().OrderByDescending(c => c.DataEnvio).ToListAsync();

        public Task<List<Agenda>> ListarEventos()
            => _database.Table<Agenda>().OrderByDescending(a => a.Data).ToListAsync();

        public Task<int> DeletarUsuario(Usuario usuario)
            => _database.DeleteAsync(usuario);

        public Task<int> DeletarComunicado(Comunicado comunicado)
            => _database.DeleteAsync(comunicado);

        public Task<int> DeletarEvento(Agenda agenda)
            => _database.DeleteAsync(agenda);
        public Task<List<Boletim>> ListarBoletins()
        {
            return _database.Table<Boletim>().ToListAsync();
        }
    }
}
