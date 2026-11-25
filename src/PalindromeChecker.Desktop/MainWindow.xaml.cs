using PalindromeChecker.Core;
using System.Windows;
using System.Windows.Media;

namespace PalindromeChecker.Desktop;

public partial class MainWindow : Window
{
    private readonly IPalindromeService _palindromeService;

    public MainWindow(IPalindromeService palindromeService)
    {
        InitializeComponent();
        _palindromeService = palindromeService;
        queryText.Focus();
    }

    private void Verify_Btn_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(queryText.Text))
        {
            ShowResult("Veuillez saisir un mot ou une phrase.", "#6B7280", "#F3F4F6");
            return;
        }

        bool isPalindrome = _palindromeService.IsPalindrome(queryText.Text);

        if (isPalindrome)
            ShowResult("✔ Oui, c'est un palindrome !", "#047857", "#D1FAE5");
        else
            ShowResult("✘ Non, ce n'est pas un palindrome.", "#B91C1C", "#FEE2E2");
    }

    private void ShowResult(string message, string textColor, string backgroundColor)
    {
        result_label.Content = message;
        result_label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColor));
        result_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
    }
}
