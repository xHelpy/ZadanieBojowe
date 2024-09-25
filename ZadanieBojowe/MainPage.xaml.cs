namespace ZadanieBojowe
{
    public partial class MainPage : ContentPage
    {
        private int liczbaPolubien = 0;
        private List<string> recenzje = new List<string>();
        private List<string> obrazy = new List<string> { "a1a.jpg", "a2a.jpg", "a3a.jpg", "a4a.jpg", "a5a.jpg", "a6a.jpg" };
        private int aktualneZdjecieIndex = 0;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainPage()
        {
            InitializeComponent();
            RecenzjeCollectionView.ItemsSource = recenzje;
            ZmienObraz();
            StartTimer();
        }

        [Obsolete]
        private void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(4), () =>
            {
                ZmienObraz();
                return !cancellationTokenSource.IsCancellationRequested;
            });
        }

        private void ZmienObraz()
        {
            aktualneZdjecieIndex = (aktualneZdjecieIndex + 1) % obrazy.Count;
            ZmieniajaceZdjecie.Source = obrazy[aktualneZdjecieIndex];
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

        private void KliknieteDodajRecenzje(object sender, EventArgs e)
        {
            string nowaRecenzja = RecenzjaEditor.Text;

            if (!string.IsNullOrWhiteSpace(nowaRecenzja))
            {
                recenzje.Add(nowaRecenzja);
                RecenzjeCollectionView.ItemsSource = null;
                RecenzjeCollectionView.ItemsSource = recenzje;
                RecenzjaEditor.Text = string.Empty;
            }
        }
    }
}
