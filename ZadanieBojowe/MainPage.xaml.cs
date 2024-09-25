using System.Collections.ObjectModel;

namespace ZadanieBojowe
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<string> tasks;

        public MainPage()
        {
            InitializeComponent();

            tasks = new ObservableCollection<string>
            {
                "zakupy: chleb, masło, ser",
                "do zrobienia: obiad, umyć podłogi",
                "weekend: kino, spacer z psem"
            };

            TaskListView.ItemsSource = tasks;
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewItemEntry.Text))
            {
                tasks.Add(NewItemEntry.Text);
                NewItemEntry.Text = string.Empty;
            }
        }
    }
}