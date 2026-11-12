using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostService.Dtos;

namespace PostService.App
{
    public partial class PostingList : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7158/") // Вкажіть свій порт сервера з launchSettings.json
        };

        public PostingList()
        {
            InitializeComponent();
        }

        private async void PostingList_Load(object sender, EventArgs e)
        {
            await LoadPostingsAsync();
        }

        private async Task LoadPostingsAsync()
        {
            try
            {
                var postings = await _httpClient.GetFromJsonAsync<List<PostingGetDto>>("postings");
                gridPostings.DataSource = postings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося з'єднатися із сервером: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadPostingsAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridPostings.CurrentRow?.DataBoundItem is PostingGetDto selectedPosting)
            {
                var confirmResult = MessageBox.Show(
                    "Ви дійсно бажаєте видалити вибраний запис?", 
                    "Підтвердження видалення", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        var response = await _httpClient.DeleteAsync($"postings/{selectedPosting.Id}");
                        
                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Сервер не підтвердив видалення запису.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        await LoadPostingsAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при виконанні запиту видалення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть рядок для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}