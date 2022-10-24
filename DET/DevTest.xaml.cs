using System.Windows;
using System.Data;
using System;
namespace DET
{
    /// <summary>
    /// DevTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DevTest : Window
    {
        
            





        public DevTest()
        {
            InitializeComponent();
            chkbox.Checked += Chkbox_Checked;
            chkbox.Unchecked += Chkbox_Checked;
            // 버튼들 모여있음 //
            //TextEdit//
            TN.Click += TN_Click;
            TE.Click += TE_Click;
            TK.Click += TK_Click;
            //CheckEdit//
            CE.Click += CE_Click;
            //ToggleSwitch//
            TSBT.Click += TSBT_Click;
            //SpinEdit//
            SEB.Click += SEB_Click;
            //ComboboxEdit//
            CBEB.Click += CBEB_Click;
            //DateEdit//
            DN.Click += DN_Click;
            DC.Click += DC_Click;
            DP.Click += DP_Click;

            
        }

        //----------------------------------------------------------버튼 라인 시작---------------------------------------------------------------//

        //----------------------------------------------------------TextEdit---------------------------------------------------------------//
        private void DP_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DEP.Text);
        }

        private void DC_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DEC.Text);
        }

        private void DN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DEN.Text);
        }

        //----------------------------------------------------------CheckEdit---------------------------------------------------------------//

        private void CBEB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(CBE.Text);
        }

        //----------------------------------------------------------ToggleSwitch---------------------------------------------------------------//

        private void SEB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SE.Text);
        }

        //----------------------------------------------------------SpinEdit---------------------------------------------------------------//

        private void TSBT_Click(object sender, RoutedEventArgs e)
        {
           
        }

        //----------------------------------------------------------ComboboxEdit---------------------------------------------------------------//

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(chkbox.Content as string);
        }

        //----------------------------------------------------------DateEdit---------------------------------------------------------------//

        private void TK_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TEK.Text);
        }

        private void TE_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TEE.Text);
        }

        private void TN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TEN.Text);
        }

        /// <summary>
        /// //----------------------------------------------------------버튼 라인 끝---------------------------------------------------------------//
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chkbox_Checked(object sender, RoutedEventArgs e)
        {
            if(chkbox.IsChecked == true)
                chkbox.Content = "체크";
            else
                chkbox.Content = "비체크";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void MainOpen_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
        public static string strconn = "Provider = tbprov.Tbprov.6; Location=127.0.0.1,8640; Data Source = tiberia; User ID = Yoon; Password=9598";
        

        private void  CBE_Loaded(object sender, RoutedEventArgs e)
        {
         
            
            try
            {
                
                string sql = "SELECT NAME, ID FROM IDENTITY;";
                

                
                DataTable dtresult = TestClass.SelectData(sql);

                

                CBE.ItemsSource = dtresult;
                


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ToggleSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           if(DEN.EditValue == null)
            {
                DEN.EditValue = DateTime.Now; 
            }
            if (DEC.EditValue == null)
            {
                DEC.EditValue = DateTime.Now;
            }
            if (DEP.EditValue == null)
            {
                DEP.EditValue = DateTime.Now;
            }
        }
    }
}
