using D2R.Services;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.Admin
{
    public partial class CampaignDetailView : UserControl
    {
        private readonly CampaignService _campaignService = new();
        private readonly CampaignItemService _campaignItemService = new();

        public CampaignDetailView(int campaignId)
        {
            InitializeComponent();
            LoadCampaignDetailView(campaignId);
        }
        private void LoadCampaignDetailView(int campaignId)
        {
            var campaign = _campaignService.GetById(campaignId);
            NoteText.Text = campaign.Title;
            AreaText.Text = campaign.Area?.Name ?? "Không rõ";
            DisasterTypeText.Text = campaign.DisasterLevel?.DisasterType?.Name ?? "Không rõ";
            DisasterLevelText.Text = campaign.DisasterLevel?.Level ?? "Không rõ";
            CreatedDateText.Text = campaign.CreatedDate?.ToString("dd/MM/yyyy") ?? "Không rõ";

            if (campaign.Status == "Completed")
            {
                CompletedTimePanel.Visibility = Visibility.Visible;
                CompletedTimeText.Text = campaign.CompletedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";
                ApprovedOrRejectedDateText.Text = campaign.ApprovedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";
            }
            else if (campaign.Status == "Approved")
            {
                ApprovedOrRejectedDateText.Text = campaign.ApprovedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";
            }
            else if (campaign.Status == "Rejected")
            {
                ApprovedOrRejectedDateText.Text = campaign.RejectedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";
            }

            var items = _campaignItemService.GetByCampaignId(campaignId)
                .Select(ci => new
                {
                    ItemName = ci.Item?.Name ?? "Không rõ",
                    QuantityRequested = ci.QuantityRequested ?? 0,
                    CategoryName = ci.Item?.Category?.CategoryName ?? "Không rõ"
                });

            // foreach (var item in items)
            //     ItemListView.Items.Add(item);
            ItemListView.ItemsSource = items;
        }
    }
}
