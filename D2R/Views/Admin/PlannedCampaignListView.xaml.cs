using System.Windows;
using System.Windows.Controls;
using D2R.ViewModels;
using D2R.Views.Admin;

namespace D2R.Views.Admin
{
    public partial class PlannedCampaignListView : UserControl
    {
        private readonly PlannedCampaignListViewModel _viewModel = new();

        public PlannedCampaignListView()
        {
            InitializeComponent();
            CampaignGrid.ItemsSource = _viewModel.PlannedCampaigns;
        }

        private void ViewDetail_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is int campaignId)
            {
                var detailView = new ApproveCampaignDetailView(campaignId);
                Content = detailView;
            }
        }
    }
}
