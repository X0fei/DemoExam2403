using Avalonia.Controls;

namespace DemoExam2403;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ProductsButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ProductList productList = new();
        productList.Show();
        Close();
    }

    private void PartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PartnerList partnerList = new();
        partnerList.Show();
        Close();
    }
}