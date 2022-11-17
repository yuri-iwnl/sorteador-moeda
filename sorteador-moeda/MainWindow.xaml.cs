using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sorteador_moeda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float contadorSorteios = 0;
        float contadorCara = 0;
        float contadorCoroa = 0;
        public MainWindow()
        {
            InitializeComponent();
            OcultaMoedas();
        }

        private void SortearMoeda(object sender, RoutedEventArgs e)
        {
            OcultaMoedas();
            ContaJogadas();
            Random random = new Random();
            int numeroSorteado = random.Next(0,2);
            if (numeroSorteado == 0)
            {
                contadorCara++;
                imgCara.Visibility = Visibility.Visible;
                txtMoeda.Text = "Cara";
            }
            else
            {
                contadorCoroa++;
                imgCoroa.Visibility = Visibility.Visible;
                txtMoeda.Text = "Coroa";
            }
            DefinePorcentagemCara();
            DefinePorcentagemCoroa();
        }

        private void ContaJogadas()
        {
            contadorSorteios++;
            txtJogadas.Text = $"{contadorSorteios}";
        }

        private void DefinePorcentagemCara()
        {
            float porcentagem = (contadorCara / contadorSorteios)*100f;
            txtPorcentagemCara.Text = $"{porcentagem.ToString("F")}";
        }
        private void DefinePorcentagemCoroa()
        {
            float porcentagem = (contadorCoroa / contadorSorteios)*100f;
            txtPorcentagemCoroa.Text = $"{porcentagem.ToString("F")}";
        }

        private void OcultaMoedas()
        {
            imgCara.Visibility = Visibility.Hidden;
            imgCoroa.Visibility = Visibility.Hidden;
        }
    }
}
