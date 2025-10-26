using Class_Family.Models;
using Class_Family.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Class_Family.Views
{
    public partial class AtribuirNotaPage : ContentPage
    {
        private readonly DatabaseService _db;
        private readonly Usuario _professor;
        private List<AlunoComNome> _alunosComNomes;
        private List<Disciplina> _disciplinas;

        public AtribuirNotaPage(DatabaseService db, Usuario professor)
        {
            InitializeComponent();
            _db = db;
            _professor = professor;
            CarregarDados();
        }

        private async void CarregarDados()
        {
            var todosUsuarios = await _db.ListarUsuarios();
            var todosAlunos = await _db.ListarAlunos();
            _disciplinas = await _db.ListarDisciplinas();

            // Junção manual (JOIN) para obter o nome do aluno a partir da tabela Usuario
            _alunosComNomes = (from aluno in todosAlunos
                               join usuario in todosUsuarios on aluno.UsuarioId equals usuario.Id
                               select new AlunoComNome
                               {
                                   AlunoId = aluno.Id,
                                   NomeCompleto = usuario.Nome
                               }).ToList();

            if (_alunosComNomes.Any())
            {
                alunoPicker.ItemsSource = _alunosComNomes.Select(a => a.NomeCompleto).ToList();
            }
            else
            {
                await DisplayAlert("Atenção", "Nenhum aluno encontrado ou dados de usuário ausentes.", "OK");
            }

            if (_disciplinas.Any())
            {
                // Assume que Disciplina tem a propriedade 'Nome'
                disciplinaPicker.ItemsSource = _disciplinas.Select(d => d.Nome).ToList();
            }
            else
            {
                await DisplayAlert("Atenção", "Nenhuma disciplina encontrada.", "OK");
            }
        }

        private async void OnLancarNotaClicked(object sender, EventArgs e)
        {
            if (alunoPicker.SelectedItem == null || disciplinaPicker.SelectedItem == null || string.IsNullOrWhiteSpace(notaEntry.Text))
            {
                await DisplayAlert("Erro", "Por favor, preencha o aluno, a disciplina e a nota.", "OK");
                return;
            }

            if (!double.TryParse(notaEntry.Text, out double nota))
            {
                await DisplayAlert("Erro", "A nota deve ser um número válido.", "OK");
                return;
            }

            var nomeAlunoSelecionado = (string)alunoPicker.SelectedItem;
            var alunoSelecionado = _alunosComNomes.FirstOrDefault(a => a.NomeCompleto == nomeAlunoSelecionado);

            var nomeDisciplinaSelecionada = (string)disciplinaPicker.SelectedItem;
            var disciplinaSelecionada = _disciplinas.FirstOrDefault(d => d.Nome == nomeDisciplinaSelecionada);

            if (alunoSelecionado == null || disciplinaSelecionada == null)
            {
                await DisplayAlert("Erro", "Seleção inválida de Aluno ou Disciplina. Recarregue a página.", "OK");
                return;
            }

            var novoBoletim = new Boletim
            {
                AlunoId = alunoSelecionado.AlunoId,
                DisciplinaId = disciplinaSelecionada.Id,
                Nota = nota,
                Observacao = observacaoEntry.Text,
                DataLancamento = DateTime.UtcNow
            };

            await _db.SalvarBoletim(novoBoletim);
            await DisplayAlert("Sucesso", "Nota lançada com sucesso!", "OK");

            await Navigation.PopAsync();
        }
    }

    public class AlunoComNome
    {
        public int AlunoId { get; set; }
        public string NomeCompleto { get; set; }
    }
}