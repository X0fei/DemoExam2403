using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoExam2403.Context;
using DemoExam2403.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace DemoExam2403;

public partial class AddEditPartnerWindow : Window
{
    int partnerID = 0;
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
        partnerID = id;
        Title = "Мастер Пол — Редактирование партнёра";
        TypeComboBox.ItemsSource = Utils.Context.partnerTypes;
        using (var context = new User21Context())
        {
            var partner = context.Partners.Find(this.partnerID);

            Name.Text = partner.Name;
            TypeComboBox.SelectedIndex = (int)partner.Type - 1;
            Rating.Value = partner.Rating;
            Adress.Text = partner.Adress;
            Director.Text = partner.Director;
            Phone.Text = partner.Phone;
            Email.Text = partner.Email;
            TIN.Text = partner.Tin;
        }
        AddEditPartnerButton.Content = "Редактировать партнёра";
    }

    private void AddEditPartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Name.Text) &&
            TypeComboBox.SelectedIndex != -1 &&
            Rating.Value != null)
        {
            if (partnerID == 0)
            {
                AddPartner();
            }
            else
            {
                EditPartner();
            }

            new PartnerList().Show();
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
            Email = Email.Text,
            Tin = TIN.Text
        };

        using (var context = new User21Context())
        {
            context.Add(partner);
            context.SaveChanges();
        }

        Utils.Context.partners = new List<Partner>(Utils.Context.DbContext.Partners);
    }
    private void EditPartner()
    {
        var partner = Utils.Context.DbContext.Partners.Find(partnerID);

        partner.Name = Name.Text;
        partner.Type = TypeComboBox.SelectedIndex + 1;
        partner.Rating = (int)Rating.Value;
        partner.Adress = Adress.Text;
        partner.Director = Director.Text;
        partner.Phone = Phone.Text;
        partner.Email = Email.Text;
        partner.Tin = TIN.Text;

        Utils.Context.DbContext.Update(partner);
        Utils.Context.DbContext.SaveChanges();
    }

    private void GoBackButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new PartnerList().Show();
        Close();
    }
}