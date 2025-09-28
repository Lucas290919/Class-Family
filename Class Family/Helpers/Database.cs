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
        readonly SQLiteAsyncConnection _conn; 
        public Database(string path) 
        {
            _conn.CreateTableAsync<Usuario>().Wait();
            _conn.CreateTableAsync<Professor>().Wait();
            _conn.CreateTableAsync<Aluno>().Wait();
            _conn.CreateTableAsync<Responsavel>().Wait();
            _conn.CreateTableAsync<Turma>().Wait();
            _conn.CreateTableAsync<Disciplina>().Wait();
            _conn.CreateTableAsync<Boletim>().Wait();
            _conn.CreateTableAsync<Frequencia>().Wait();
            _conn.CreateTableAsync<Comunicado>().Wait();
            _conn.CreateTableAsync<Agenda>().Wait();
        }

        public Task<int> SaveLoguinAsync(Usuario usuario)  //Inserir Usuários
        {
            if (usuario.ID != 0)
            {
                return _conn.UpdateAsync(usuario);
            }
            else 
            {
                return _conn.InsertAsync(usuario);
            }
        }
        public Task<List<Usuario>> GetLoginAsync() // Busca de dados
        {
            return _conn.Table<Usuario>().ToListAsync();
        }

        public Task<Usuario> LoginAsync(string nome, string senha)  // Buscar por nome e senha
        {
            
        }
    }
}
