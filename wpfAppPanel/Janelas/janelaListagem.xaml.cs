using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using wpfAppPanel.Janelas;
using wpfAppPanel.RegrasDeNegocio;

namespace wpfAppPanel.Janelas
{
    /// <summary>
    /// Lógica interna para janelaListagem.xaml
    /// </summary>
    public partial class janelaListagem : Window
    {

        private MySqlConnection _conexao;

        public janelaListagem()
        {
            InitializeComponent();

            CarregarLista();
        }

        private void ConexaoBD()
        {
            string conexaoString = "server=localhost;database=bd_wpf_musicas;user=root;password=root;port=3306";

            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();

        }

        public void CarregarLista()
        {
            // tentativa DE GPT

            ConexaoBD();

            try
            {

                string query = "select * from Musica;";
                var comando = new MySqlCommand(query, _conexao);
                var reader = comando.ExecuteReader();
                var lista = new List<Musica>();
                while (reader.Read())
                {

                    Musica musica = new Musica();

                    musica.nome = reader.GetString(1);
                    musica.duracao = reader.GetString(2);
                    musica.album = reader.GetString(3);
                    musica.banda = reader.GetString(4);
                    musica.estilo = reader.GetString(5);

                    lista.Add(musica);
                }

                dgvListagemMusica.ItemsSource = lista;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Você é um fracasso total.");
            }
        }
    }
}
