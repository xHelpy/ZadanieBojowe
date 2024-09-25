namespace ZadanieBojowe
{
    public partial class MainPage : ContentPage
    {
        private int liczbaPolubien = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void KliknieteLubieTo(object sender, EventArgs e)
        {
            liczbaPolubien++;
            AktualizujEtykietePolubien();
        }

        private void KliknieteNieLubie(object sender, EventArgs e)
        {
            if (liczbaPolubien > 0)
            {
                liczbaPolubien--;
            }
            AktualizujEtykietePolubien();
        }

        private void AktualizujEtykietePolubien()
        {
            EtykietaPolubien.Text = $"{liczbaPolubien} polubień";
        }
    }


}
