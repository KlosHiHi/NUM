namespace Gaussi
{
    public partial class MainPage : ContentPage
    {
        double[] X = new double[4];

        double[] B = new double[4];

        double[,] A = new double[4, 4];

        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            SetValues();

            X[0] = CalculateFirstX();
            X[1] = CalculateSecondX();
            X[2] = CalculateThirdX();
            X[3] = CalculateFourthX();

            XOne.Text = $"X1 = {X[0]}";
            XTwo.Text = $"X2 = {X[1]}";
            XThree.Text = $"X3 = {X[2]}";
            XFour.Text = $"X4 = {X[3]}";
        }

        private void SetValues()
        {
            B[0] = Double.Parse(BOne.Text);
            B[1] = Double.Parse(BTwo.Text);
            B[2] = Double.Parse(BThree.Text);
            B[3] = Double.Parse(BFour.Text);

            A[0, 0] = Double.Parse(AOneOneEntry.Text);
            A[0, 1] = Double.Parse(AOneTwoEntry.Text);
            A[0, 2] = Double.Parse(AOneThreeEntry.Text);
            A[0, 3] = Double.Parse(AOneFourEntry.Text);

            A[1, 0] = Double.Parse(ATwoOneEntry.Text);
            A[1, 1] = Double.Parse(ATwoTwoEntry.Text);
            A[1, 2] = Double.Parse(ATwoThreeEntry.Text);
            A[1, 3] = Double.Parse(ATwoFourEntry.Text);

            A[2, 0] = Double.Parse(AThreeOneEntry.Text);
            A[2, 1] = Double.Parse(AThreeTwoEntry.Text);
            A[2, 2] = Double.Parse(AThreeThreeEntry.Text);
            A[2, 3] = Double.Parse(AThreeFourEntry.Text);

            A[3, 0] = Double.Parse(AFourOneEntry.Text);
            A[3, 1] = Double.Parse(AFourTwoEntry.Text);
            A[3, 2] = Double.Parse(AFourThreeEntry.Text);
            A[3, 3] = Double.Parse(AFourFourEntry.Text);
        }

        private double CalculateFirstX()
        {
            var C6 = Math.Round((A[0, 1] / A[0, 0]) * 10000) / 10000;
            var D6 = Math.Round((A[0, 2] / A[0, 0]) * 10000) / 10000;
            var E6 = Math.Round((A[0, 3] / A[0, 0]) * 10000) / 10000;
            var F6 = Math.Round((B[0] / A[0, 0]) * 10000) / 10000;

            var C7 = Math.Round((A[1, 1] - (A[1, 0] * C6)) * 10000) / 10000;
            var D7 = Math.Round((A[1, 2] - (A[1, 0] * D6)) * 10000) / 10000;
            var E7 = Math.Round((A[1, 3] - (A[1, 0] * E6)) * 10000) / 10000;
            var F7 = Math.Round((B[1] - (A[1, 0] * F6)) * 10000) / 10000;

            var C8 = Math.Round((A[2, 1] - (A[2, 0] * C6)) * 10000) / 10000;
            var D8 = Math.Round((A[2, 2] - (A[2, 0] * D6)) * 10000) / 10000;
            var E8 = Math.Round((A[2, 3] - (A[2, 0] * E6)) * 10000) / 10000;
            var F8 = Math.Round((B[2] - (A[2, 0] * F6)) * 10000) / 10000;

            var C9 = Math.Round((A[3, 1] - (A[3, 0] * C6)) * 10000) / 10000;
            var D9 = Math.Round((A[3, 2] - (A[3, 0] * D6)) * 10000) / 10000;
            var E9 = Math.Round((A[3, 3] - (A[3, 0] * E6)) * 10000) / 10000;
            var F9 = Math.Round((B[3] - (A[3, 0] * F6)) * 10000) / 10000;

            var D10 = Math.Round((D7 / C7) * 10000) / 10000;
            var E10 = Math.Round((E7 / C7) * 10000) / 10000;
            var F10 = Math.Round((F7 / C7) * 10000) / 10000;

            var D11 = Math.Round((D8 - (C8 * D10)) * 10000) / 10000;
            var E11 = Math.Round((E8 - (C8 * E10)) * 10000) / 10000;
            var F11 = Math.Round((F8 - (C8 * F10)) * 10000) / 10000;

            var D12 = Math.Round((D9 - (C9 * D10)) * 10000) / 10000;
            var E12 = Math.Round((E9 - (C9 * E10)) * 10000) / 10000;
            var F12 = Math.Round((F9 - (C9 * F10)) * 10000) / 10000;

            var E13 = Math.Round((E11 / D11) * 10000) / 10000;
            var F13 = Math.Round((F11 / D11) * 10000) / 10000;

            return Math.Round(((F12 - (D12 * F13)) / (E12 - (D12 * E13))) * 10000) / 10000;
        }

        private double CalculateSecondX()
        {
            var C6 = Math.Round((A[0, 1] / A[0, 0]) * 10000) / 10000;
            var D6 = Math.Round((A[0, 2] / A[0, 0]) * 10000) / 10000;
            var E6 = Math.Round((A[0, 3] / A[0, 0]) * 10000) / 10000;
            var F6 = Math.Round((B[0] / A[0, 0]) * 10000) / 10000;

            var C7 = Math.Round((A[1, 1] - (A[1, 0] * C6)) * 10000) / 10000;
            var D7 = Math.Round((A[1, 2] - (A[1, 0] * D6)) * 10000) / 10000;
            var E7 = Math.Round((A[1, 3] - (A[1, 0] * E6)) * 10000) / 10000;
            var F7 = Math.Round((B[1] - (A[1, 0] * F6)) * 10000) / 10000;

            var C8 = Math.Round((A[2, 1] - (A[2, 0] * C6)) * 10000) / 10000;
            var D8 = Math.Round((A[2, 2] - (A[2, 0] * D6)) * 10000) / 10000;
            var E8 = Math.Round((A[2, 3] - (A[2, 0] * E6)) * 10000) / 10000;
            var F8 = Math.Round((B[2] - (A[2, 0] * F6)) * 10000) / 10000;

            var D10 = Math.Round((D7 / C7) * 10000) / 10000;
            var E10 = Math.Round((E7 / C7) * 10000) / 10000;
            var F10 = Math.Round((F7 / C7) * 10000) / 10000;

            var D11 = Math.Round((D8 - (C8 * D10)) * 10000) / 10000;
            var E11 = Math.Round((E8 - (C8 * E10)) * 10000) / 10000;
            var F11 = Math.Round((F8 - (C8 * F10)) * 10000) / 10000;

            return Math.Round(((F11 / D11) - ((E11 / D11) * X[0])) * 10000) / 10000;
        }

        private double CalculateThirdX()
        {
            var C6 = Math.Round((A[0, 1] / A[0, 0]) * 10000) / 10000;
            var D6 = Math.Round((A[0, 2] / A[0, 0]) * 10000) / 10000;
            var E6 = Math.Round((A[0, 3] / A[0, 0]) * 10000) / 10000;
            var F6 = Math.Round((B[0] / A[0, 0]) * 10000) / 10000;

            var C7 = Math.Round((A[1, 1] - (A[1, 0] * C6)) * 10000) / 10000;
            var D7 = Math.Round((A[1, 2] - (A[1, 0] * D6)) * 10000) / 10000;
            var E7 = Math.Round((A[1, 3] - (A[1, 0] * E6)) * 10000) / 10000;
            var F7 = Math.Round((B[1] - (A[1, 0] * F6)) * 10000) / 10000;

            var C8 = Math.Round((A[2, 1] - (A[2, 0] * C6)) * 10000) / 10000;
            var D8 = Math.Round((A[2, 2] - (A[2, 0] * D6)) * 10000) / 10000;
            var E8 = Math.Round((A[2, 3] - (A[2, 0] * E6)) * 10000) / 10000;
            var F8 = Math.Round((B[2] - (A[2, 0] * F6)) * 10000) / 10000;

            return Math.Round(((F7 / C7) - (E7 / C7) * X[0] - (D7 / C7) * X[1]) * 10000) / 10000;
        }

        private double CalculateFourthX()
        {
            return Math.Round(((B[0] / A[0, 0]) - (A[0, 3] / A[0, 0]) * X[0] - (A[0, 2] / A[0, 0]) * X[1] - (A[0, 1] / A[0, 0]) * X[2]) * 10000) / 10000;
        }
    }
}
