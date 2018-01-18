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
using Microsoft.Win32;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Playback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Mp3FileReader reader;
        private WaveOut output;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == true)
            {
                txtRuta.Text = openFileDialog.FileName;

            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (txtRuta.Text != null && txtRuta.Text != "")
            {
                output = new WaveOut();
                output.PlaybackStopped += OnPlaybackStop;
                reader = new Mp3FileReader(txtRuta.Text);

                output.Init(reader);
                output.Play();


            }
            else
            {
                //Avisarle al suuario que elija un archivo
            }
        }

        private void OnPlaybackStop(object sender, StoppedEventArgs e )
        {
            reader.Dispose();
            output.Dispose();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if(output != null)
            {
                output.Stop();
            }
        }



    }
}
