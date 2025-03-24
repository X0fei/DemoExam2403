using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoExam2403.Context;
using DemoExam2403.Models;
using System.Collections.Generic;
using System;
using DemoExam2403.Utils;
using Microsoft.EntityFrameworkCore;

namespace DemoExam2403;

public partial class AddEditProductWindow : Window
{
    int productID = 0;
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
        productID = id;
        Title = "Мастер Пол — Редактирование товара";
        TypeComboBox.ItemsSource = Utils.Context.productTypes;
        using (var context = new User21Context())
        {
            var product = context.Products.Find(this.productID);

            Article.Text = product.Article;
            Name.Text = product.Name;
            TypeComboBox.SelectedIndex = (int)product.Type - 1;
            MinimalCost.Value = product.MinimalCost;
        }
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
            if (productID == 0)
            {
                AddProduct();
            }
            else
            {
                EditProduct();
            }
            new ProductList().Show();
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

    private void EditProduct()
    {
        var product = Utils.Context.DbContext.Products.Find(productID);

        product.Article = Article.Text;
        product.Name = Name.Text;
        product.Type = TypeComboBox.SelectedIndex + 1;
        product.MinimalCost = (decimal)MinimalCost.Value;

        Utils.Context.DbContext.Update(product);
        Utils.Context.DbContext.SaveChanges();
    }
    private void GoBackButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new ProductList().Show();
        Close();
    }
}