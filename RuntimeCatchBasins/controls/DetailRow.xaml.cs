using MaximoServiceLibrary.model;
using System;
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

namespace RuntimeCatchBasins.controls
{
    /// <summary>
    /// Interaction logic for DetailRow.xaml
    /// </summary>
    public partial class DetailRow : UserControl
    {
        MaximoAssetSpec assetSpec;
        MaximoAttribute att;
        MaximoDomain maximoDomain;
        public DetailRow(MaximoAssetSpec _assetSpec)
        {
            InitializeComponent();
            assetSpec = _assetSpec;

            att = MainWindow.synchronizationService.attributeRepository.findOne(assetSpec.assetattrid);
           

            stackPanel.Orientation = Orientation.Horizontal;
            Label label = new Label();
            label.Width = 144;
            label.Margin = new Thickness(3);
            label.Content = att.description;

            stackPanel.Children.Add(label);

            if (att.domainid != null)
            {
                ComboBox comboBox = new ComboBox();
                comboBox.SelectionChanged += ComboBox_SelectionChanged;
                comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                comboBox.Width = 144;
                comboBox.Margin = new Thickness(3);
                maximoDomain = MainWindow.synchronizationService.domainRepository.findOne(att.domainid);
                int index = -1;
                switch (maximoDomain.domaintype.ToUpper())
                {
                    case "ALN":
                        foreach (var aln in maximoDomain.alndomain)
                        {

                            ComboBoxItem comboBoxItem = new ComboBoxItem();
                            comboBoxItem.Uid = aln.value;
                            comboBoxItem.Content = aln.description;
                            comboBox.Items.Add(comboBoxItem);
                            if (aln.value == assetSpec.alnvalue)
                            {


                                index = comboBox.Items.Count - 1;
                            }



                        }
                        break;
                    case "NUMERIC":
                        foreach (var numeric in maximoDomain.numericdomain)
                        {

                            ComboBoxItem comboBoxItem = new ComboBoxItem();
                            comboBoxItem.Uid = numeric.value.ToString();
                            comboBoxItem.Content = numeric.description;
                            if (numeric.value == assetSpec.numvalue)
                            {
                                comboBoxItem.IsSelected = true;
                            }
                            comboBox.Items.Add(comboBoxItem);

                        }
                        break;
                    case "SYNONYM":
                        foreach (var synonym in maximoDomain.synonymdomain)
                        {

                            ComboBoxItem comboBoxItem = new ComboBoxItem();
                            comboBoxItem.Uid = synonym.value;
                            comboBoxItem.Content = synonym.description;
                            if (synonym.value == assetSpec.alnvalue)
                            {
                                comboBoxItem.IsSelected = true;
                            }
                            comboBox.Items.Add(comboBoxItem);

                        }
                        break;

                    case "NUMRANGE":

                        break;

                }

                comboBox.SelectedIndex = index;
                stackPanel.Children.Add(comboBox);
            }
            else
            {
                TextBox textBox = new TextBox();
                textBox.TextChanged += TextBox_TextChanged;
                textBox.Width = 144;
                textBox.Margin = new Thickness(3);
                textBox.Text = assetSpec.alnvalue;
                stackPanel.Children.Add(textBox);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


            throw new NotImplementedException();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
