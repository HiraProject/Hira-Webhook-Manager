using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Hira_Webhook_Destroyer
{
    public partial class MainWindow : Window
    {
        private CancellationTokenSource? _spamCancellationTokenSource = null;
        private readonly Random _random = new Random();
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string webhookUrl = WebhookUrlTextBox.Text;
            string message = MessageTextBox.Text;

            if (string.IsNullOrWhiteSpace(webhookUrl))
            {
                MessageBox.Show("Please enter a valid webhook URL.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var payload = new { content = message };
                    var response = await client.PostAsJsonAsync(webhookUrl, payload);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Message sent successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to send message. Status code: {response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteWebhookButton_Click(object sender, RoutedEventArgs e)
        {
            string webhookUrl = WebhookUrlTextBox.Text;

            if (string.IsNullOrWhiteSpace(webhookUrl))
            {
                MessageBox.Show("Please enter a valid webhook URL.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.DeleteAsync(webhookUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Webhook deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to delete webhook. Status code: {response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void SpamButton_Click(object sender, RoutedEventArgs e)
        {
            if (_spamCancellationTokenSource != null)
            {
                _spamCancellationTokenSource.Cancel();
                SpamButton.Content = "Start Spam";
                _spamCancellationTokenSource = null;
                return;
            }

            if (!int.TryParse(SpamCountTextBox.Text, out int spamCount) || spamCount < 1)
            {
                MessageBox.Show("Please enter a valid number of messages (≥1).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(SpamDelayTextBox.Text, out int delay) || delay < 0)
            {
                MessageBox.Show("Please enter a valid delay (≥0).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string webhookUrl = WebhookUrlTextBox.Text;
            if (string.IsNullOrWhiteSpace(webhookUrl))
            {
                MessageBox.Show("Please enter a valid webhook URL.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _spamCancellationTokenSource = new CancellationTokenSource();
                SpamButton.Content = "Stop Spam";
                SendMessageButton.IsEnabled = false;
                DeleteWebhookButton.IsEnabled = false;

                await SpamWebhookAsync(webhookUrl, spamCount, delay, _spamCancellationTokenSource.Token);

                MessageBox.Show($"Successfully sent {spamCount} messages!", "Spam Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Spam stopped by user.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Spam error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SendMessageButton.IsEnabled = true;
                DeleteWebhookButton.IsEnabled = true;
                SpamButton.Content = "Start Spam";
                _spamCancellationTokenSource?.Dispose();
                _spamCancellationTokenSource = null;
            }
        }

        private async Task SpamWebhookAsync(string webhookUrl, int count, int delay, CancellationToken cancellationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < count; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string message = RandomMessageCheckBox.IsChecked == true
                        ? GenerateRandomMessage()
                        : MessageTextBox.Text;

                    var payload = new { content = message };
                    var response = await client.PostAsJsonAsync(webhookUrl, payload, cancellationToken);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException($"Failed to send message #{i + 1}. Status: {response.StatusCode}");
                    }

                    if (delay > 0)
                    {
                        await Task.Delay(delay, cancellationToken);
                    }
                }
            }
        }

        private string GenerateRandomMessage(int length = 20)
        {
            var chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = Characters[_random.Next(Characters.Length)];
            }
            return new string(chars) + " 🚀";
        }
    }
}