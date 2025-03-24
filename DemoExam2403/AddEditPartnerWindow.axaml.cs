using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoExam2403.Context;
using DemoExam2403.Models;
using System.Collections.Generic;
using System;

namespace DemoExam2403;

public partial class AddEditPartnerWindow : Window
{
    public AddEditPartnerWindow()
    {
        InitializeComponent();
        Title = "Мастер Пол — Добавление партнёра";
        TypeComboBox.ItemsSource = Utils.Context.partnerTypes;
        AddEditPartnerButton.Content = "Добавить партнёра";
    }

    public AddEditPartnerWindow(int id)
    {
        InitializeComponent();
        Title = "Мастер Пол — Редактирование партнёра";
        TypeComboBox.ItemsSource = Utils.Context.partnerTypes;
        AddEditPartnerButton.Content = "Редактировать партнёра";
    }

    private void AddEditPartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Name.Text) &&
            TypeComboBox.SelectedIndex != -1 &&
            Rating.Value != null)
        {
            AddPartner();

            PartnerList partnerList = new();
            partnerList.Show();
            Close();
        }
    }

    private void AddPartner()
    {
        Partner partner = new()
        {
            Name = Name.Text,
            Type = TypeComboBox.SelectedIndex + 1,
            Rating = (int)Rating.Value,
            Adress = Adress.Text,
            Director = Director.Text,
            Phone = Phone.Text,
            Email = Email.Text
        };

        using (var context = new User21Context())
        {
            context.Add(partner);
            context.SaveChanges();
        }

        Utils.Context.partners = new List<Partner>(Utils.Context.DbContext.Partners);
    }

    private void GoBackButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PartnerList partnerList = new();
        partnerList.Show();
        Close();
    }
}