using PalindromeChecker.Core;
using System.Windows;

namespace PalindromeChecker.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IPalindromeService _palindromeService;
    public MainWindow(IPalindromeService palindromeService)
    {
        InitializeComponent();
        _palindromeService = palindromeService;
    }

    private void Verify_Btn_Click(object sender, RoutedEventArgs e)
    {

        //if (string.IsNullOrWhiteSpace(queryText.Text))
        //    result_label.Content = "Veuillez saisir un mot ou une phrase!";
        //else
        result_label.Content = _palindromeService.IsPalindrome(queryText.Text) ? "Vrai !" : "Faux !";
    }
}