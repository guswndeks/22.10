using System;
using System.Data;
using System.Windows;

namespace DET
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btngriddata.Click += Btngriddata_Click;
            Close.Click += Close_Click;
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Btngriddata_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                string strD = @"SELECT RCD.MESR_TM FL_TM
			                          ,FL.MESR_VAL FL_MESR, FL.MODI_VAL FL_MODI
			                          ,PRS.MESR_VAL PRS_MESR, PRS.MODI_VAL PRS_MODI
			                          ,FLSM.MESR_VAL FLSM_MESR, FLSM.MODI_VAL FLSM_MODI
			                          ,FLSMC.MESR_VAL FLSMC_MESR, FLSMC.MODI_VAL FLSMC_MODI
	                            FROM( SELECT TO_DATE('20220101000000', 'YYYYMMDDHH24MISS') - 1/24/60 + LEVEL/24/60 MESR_TM
		                              FROM DUAL
		                              CONNECT BY TO_DATE('20220101000000', 'YYYYMMDDHH24MISS') - 1/24/60 + LEVEL/24/60 <= TO_DATE('20220101235959', 'YYYYMMDDHH24MISS')
                                     ) RCD
                                LEFT OUTER JOIN (SELECT *
										         FROM HMI_MNT_DATA
									             WHERE ITEM_CAT = 'FL') FL
                                                 ON (RCD.MESR_TM = FL.MESR_TM)
                                LEFT OUTER JOIN (SELECT *
	 									         FROM HMI_MNT_DATA
									             WHERE ITEM_CAT = 'PRS') PRS
                                                 ON (RCD.MESR_TM = PRS.MESR_TM)
                                LEFT OUTER JOIN (SELECT *
									             FROM HMI_MNT_DATA
								                 WHERE ITEM_CAT = 'FLSM') FLSM
 		                                         ON (RCD.MESR_TM = FLSM.MESR_TM)
                                LEFT OUTER JOIN (SELECT *
									             FROM HMI_MNT_DATA
								                 WHERE ITEM_CAT = 'FLSMC') FLSMC
 		                                         ON (RCD.MESR_TM = FLSMC.MESR_TM)
                                ORDER BY RCD.MESR_TM ASC;";




                //string strD = @"SELECT FL.MESR_TM FL_TM, FL.MESR_VAL FL_MESR, FL.MODI_VAL FL_MODI
                //                   ,PRS.MESR_TM PRS_TM, PRS.MESR_VAL PRS_MESR, PRS.MODI_VAL PRS_MODI
                //                      ,FLSM.MESR_TM FLSM_TM, FLSM.MESR_VAL FLSM_MESR, FLSM.MODI_VAL FLSM_MODI
                //                      ,FLSMC.MESR_TM FLSMC_TM, FLSMC.MESR_VAL FLSMC_MESR, FLSMC.MODI_VAL FLSMC_MODI
                //                FROM HMI_MNT_DATA FL
                //                 ,HMI_MNT_DATA PRS
                //                    ,HMI_MNT_DATA FLSM
                //                    ,HMI_MNT_DATA FLSMC
                //                WHERE FL.ITEM_CAT = 'FL'
                //               AND PRS.ITEM_CAT = 'PRS'
                //                  AND FLSM.ITEM_CAT = 'FLSM'
                //                  AND FLSMC.ITEM_CAT = 'FLSMC'
                //               AND FL.MESR_TM = PRS.MESR_TM
                //               AND PRS.MESR_TM = FLSM.MESR_TM
                //               AND FLSM.MESR_TM = FLSMC.MESR_TM;";


                //WHERE BLK_CD = '000015'
                //  AND ITEM_CAT = 'FL'
                //  AND TAG_ID = '1L-42730-501-FRI-O011'
                //  AND MESR_TM BETWEEN TO_DATE('20220103000000', 'YYYYMMDDHH24MISS') 
                //                  AND TO_DATE('20220103235959', 'YYYYMMDDHH24MISS');";

                DataTable dtresult = TestClass.SelectData(strD);
                



                datagrid.ItemsSource = dtresult;
                
                CC.DataSource = dtresult;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void btnchartdata_Click_1(object sender, RoutedEventArgs e)
        {
            DET.DevTest Devtest = new DET.DevTest();
            Devtest.ShowDialog();
           
        }

        private void XYDiagram2D_Scroll(object sender, DevExpress.Xpf.Charts.XYDiagram2DScrollEventArgs e)
        {
           
        }
    }
}
