using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinHexEdit
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Project Project { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.openButton_Click(null, null);
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Open .BHE file";
            dialog.DefaultExt = "*.bhe";
            dialog.Filter = "BHE file (*.bhe)|*.bhe";

            if (dialog.ShowDialog(this) != true)
            {
                return;
            }

            this.DataContext = null;
            this.Project = null;

            try
            {
                this.Project = Project.FromFile(dialog.FileName);

                if (!System.IO.File.Exists(this.Project.BinFilePath))
                {
                    dialog = new OpenFileDialog();
                    dialog.Title = "Open binary file";
                    dialog.DefaultExt = "*.exe";
                    dialog.Filter = "EXE file (*.exe)|*.exe|BIN file (*.bin)|*.bin|All files (*.*)|*.*";

                    if (dialog.ShowDialog(this) != true)
                    {
                        return;
                    }

                    this.Project.BinFilePath = dialog.FileName;
                    this.Project.SaveSummary();
                }

                this.Project.LoadValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                this.DataContext = null;
                this.DataContext = this;
            }
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Project == null)
            {
                return;
            }

            try
            {
                var dialog = new OpenFileDialog();
                dialog.Title = "Open binary file";
                dialog.DefaultExt = "*.exe";
                dialog.Filter = "EXE file (*.exe)|*.exe|BIN file (*.bin)|*.bin|All files (*.*)|*.*";

                if (dialog.ShowDialog(this) != true)
                {
                    return;
                }

                this.Project.BinFilePath = dialog.FileName;
                this.Project.SaveSummary();
                this.Project.LoadValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                this.DataContext = null;
                this.DataContext = this;
            }
        }

        private void writeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Project == null)
            {
                return;
            }

            try
            {
                this.Project.WriteValues();

                MessageBox.Show(this, "Done", this.Title);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Project == null)
            {
                return;
            }

            string bheFileName = this.Project.FileName;
            string binFilePath = this.Project.BinFilePath;

            this.DataContext = null;
            this.Project = null;

            try
            {
                this.Project = Project.FromFile(bheFileName);
                this.Project.BinFilePath = binFilePath;
                this.Project.LoadValues();

                MessageBox.Show(this, "Done", this.Title);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                this.DataContext = null;
                this.DataContext = this;
            }
        }
    }
}
