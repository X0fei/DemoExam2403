using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoExam2403.Models;
using System.Collections.Generic;

namespace DemoExam2403;

public partial class PartnerList : Window
{
    private List<Partner> displayList = Utils.Context.partners;
    public PartnerList()
    {
        InitializeComponent();
        PartnerListBox.ItemsSource = displayList;
    }
    private void AddProductButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddEditPartnerWindow addEditPartnerWindow = new();
        addEditPartnerWindow.Show();
        Close();
    }
    private void GoBackButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new();
        mainWindow.Show();
        Close();
    }
}