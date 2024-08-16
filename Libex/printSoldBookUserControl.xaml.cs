﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Libex
{
    /// <summary>
    /// Interaction logic for printSoldBookUserControl.xaml
    /// </summary>
    public partial class printSoldBookUserControl : UserControl
    {
        public printSoldBookUserControl(string bookname,string author,string genre,float price)
        {
            //initializing
            InitializeComponent();
            //setting vars
            gettingLibraryinfo();
            bookNameBox.Text = bookname;
            authorBox.Text = author;
            BookGenrebox.Text = genre;
            PriceBox.Text = price.ToString();
        }

        //printing the grid 
        public void print()
        {
            PrintDialog dial = new PrintDialog();

            if (dial.ShowDialog() == true)
            {
                dial.PrintVisual(windowToPrint, "Client Info Print");
            }
        }

        //getting library informations
        public void gettingLibraryinfo()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            libraryName.Text = doc.SelectSingleNode("//LibraryName").InnerText;
            libraryPhone.Text = doc.SelectSingleNode("//Phone").InnerText;
            libraryEmail.Text = doc.SelectSingleNode("//Email").InnerText;
            libraryAddress.Text = doc.SelectSingleNode("//Address").InnerText;
            if (doc.SelectSingleNode("//Logo").InnerText == "1")
            {
                libraryLogo.ImageSource = new BitmapImage(new Uri(GlobalVariables.logoPath + @"\logo.png"));
            }
        }
    }
}
