using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoExam2403.Context;
using DemoExam2403.Models;
using System.Collections.Generic;
using System;

namespace DemoExam2403;

public partial class AddEditProductWindow : Window
{
    public AddEditProductWindow()
    {
        InitializeComponent();
        Title = "Мастер Пол — Добавление товара";
        Article.Text = ArticleGeneration();
        TypeComboBox.ItemsSource = Utils.Context.productTypes;
        AddEditProductButton.Content = "Добавить товар";
    }

    public AddEditProductWindow(int id)
    {
        InitializeComponent();
        Title = "Мастер Пол — Редактирование товара";
        TypeComboBox.ItemsSource = Utils.Context.productTypes;
        AddEditProductButton.Content = "Редактировать товар";
    }

    private string ArticleGeneration()
    {
        Random random = new Random();
        bool wrongArticle = false;
        int article;

        do
        {
            article = random.Next();
            foreach (Product product in Utils.Context.products)
            {
                int productArticle = 0;
                int.TryParse(product.Article, out productArticle);
                if (article == productArticle)
                {
                    wrongArticle = true;
                    break;
                }
            }
        }
        while (wrongArticle);

        return Convert.ToString(article);
    }

    private void AddEditProductButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Name.Text) &&
            TypeComboBox.SelectedIndex != -1 &&
            MinimalCost.Value != null)
        {
            AddProduct();

            ProductList productList = new();
            productList.Show();
            Close();
        }
    }

    private void AddProduct()
    {
        Product product = new Product()
        {
            Article = Article.Text,
            Name = Name.Text,
            Type = TypeComboBox.SelectedIndex + 1,
            MinimalCost = (decimal)MinimalCost.Value
        };

        using (var context = new User21Context())
        {
            context.Add(product);
            context.SaveChanges();
        }

        Utils.Context.products = new List<Product>(Utils.Context.DbContext.Products);
    }

    private void GoBackButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ProductList productList = new();
        productList.Show();
        Close();
    }
}