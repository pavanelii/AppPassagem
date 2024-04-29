using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Appviagem
{
    public partial class MainPage : ContentPage
    {
        private object resultLabel;

        public MainPage()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            var origem = new Label { Text = "Local de saída:" };
            var origemR = new Entry();
            var destino = new Label { Text = "Destino:" };
            var destinoR = new Entry();
            var distancia = new Label { Text = "Distância da Viagem (km):" };
            var distanciaR = new Entry();
            var eficiencia = new Label { Text = "Eficiência de Combustível (km/L):" };
            var eficienciaR = new Entry();
            var custocombustivel = new Label { Text = "Custo do Combustível por Litro (R$):" };
            var custocombustivelR = new Entry();
            var pedagio = new Button { Text = "Ver Pedágio" };
            var calcular = new Button { Text = "Calcular" };
            var resultLabel = new Label();

            calcular.Clicked += (sender, e) =>
            {
                if (double.TryParse(distanciaR.Text, out double distancia) &&
                    double.TryParse(eficienciaR.Text, out double eficiencia) &&
                    double.TryParse(custocombustivelR.Text, out double custocombustivel)
                    )
                {
                    double totalcustocombustivel = (distancia / eficiencia) * custocombustivel;
                    double totalviagem = totalcustocombustivel;

                    resultLabel.Text = $"Custo Total da Viagem: R$ {totalviagem:F2}";
                }
                else
                {
                    resultLabel.Text = "Por favor, insira valores válidos.";
                }
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    distancia,
                    distanciaR,
                    eficiencia,
                    eficienciaR,
                    custocombustivel,
                    custocombustivelR,
                    pedagio,
                    calcular,
                    resultLabel
                }
            };
        }
    }
}
