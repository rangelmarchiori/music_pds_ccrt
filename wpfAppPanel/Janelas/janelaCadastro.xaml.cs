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
    /// Lógica interna para janelaCadastro.xaml
    /// </summary>
    public partial class janelaCadastro : Window {

        private MySqlConnection _conexao;

        public janelaCadastro()
        {
            InitializeComponent();

            
        }

        private void ConexaoBD()
        {
            string conexaoString = "server=localhost;database=bd_wpf_musicas;user=root;password=root;port=3306";

            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
        }

        private void btSalvar(object sender, RoutedEventArgs e)
        {
            if (edNome.Text != "" && edDuracao.Text != "" && edAlbum.Text != "" && edBanda.Text != "" && edEstilo.Text != "")
            {
                try
                {
                    var nome = edNome.Text;
                    var duracao = edDuracao.Text;
                    var album = edAlbum.Text;
                    var banda = edBanda.Text;
                    var estilo = edEstilo.Text;

                    var sql = "insert into Musica (nome_mus, duracao_mus, album_mus, banda_mus, estilo_mus) values (@_nome, @_duracao, @_album, @_banda, @_estilo)";
                    var comando = new MySqlCommand(sql, _conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_duracao", duracao);
                    comando.Parameters.AddWithValue("@_album", album);
                    comando.Parameters.AddWithValue("@_banda", banda);
                    comando.Parameters.AddWithValue("@_estilo", estilo);

                    comando.ExecuteNonQuery();

                    _conexao.Close();

                    MessageBox.Show("CALVO COM CUCEGO INFELIZ");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("FOI DESGRAÇA");
                }
            }


            else
            {
                MessageBox.Show("VOCÊ É UM FRACASSO");
            }
        }
    }
}
