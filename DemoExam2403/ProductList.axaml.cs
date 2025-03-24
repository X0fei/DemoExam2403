using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoExam2403.Models;
using System.Collections.Generic;

namespace DemoExam2403;

public partial class ProductList : Window
{
    private List<Product> displayList = Utils.Context.products;
    public ProductList()
    {
        InitializeComponent();
        ProductListBox.ItemsSource = displayList;
    }

    private void AddProductButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddEditProductWindow addEditProductWindow = new AddEditProductWindow();
        addEditProductWindow.Show();
        Close();
    }
    private void GoBackButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new();
        mainWindow.Show();
        Close();
    }
}