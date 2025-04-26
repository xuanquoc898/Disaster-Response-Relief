using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.Admin
{
    public partial class StatusCampaignView : UserControl
    {
        private StatusCampaignViewModel _viewModel = new();

        public StatusCampaignView()
        {
            InitializeComponent();
        }

        private void LoadCampaigns(string status)
        {
            CampaignList.Items.Clear();

            List<Campaign> campaigns = _viewModel.GetCampaignsByStatus(status);

            foreach (var c in campaigns)
            {
                CampaignList.Items.Add(new
                {
                    c.CampaignId,
                    c.Note,
                    AreaName = c.Area?.Name ?? "Không rõ",
                    CreatedDate = c.CreatedDate?.ToString("dd/MM/yyyy") ?? "",
                    Status = c.Status
                });
            }
        }



        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (StatusFilter.SelectedItem as ComboBoxItem)?.Content?.ToString();
            LoadCampaigns(selected ?? "Tất cả");
        }


        private void ViewDetail_Click(object sender, RoutedEventArgs e)
        {
            var campaignId = (int)(sender as Button).Tag;
            var detailView = new CampaignDetailView(campaignId);
            var parent = Window.GetWindow(this);
            if (parent is MainWindow mainWin)
            {
                Content = detailView;
            }
        }
    }
}
