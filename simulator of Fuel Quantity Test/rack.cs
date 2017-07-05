using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CCWin;

namespace simulator_of_Fuel_Quantity_Test
{
    public partial class rack : CCSkinMain
    {
       

        public rack()
        {
           
            InitializeComponent();
            this.DoubleBuffered = true;  

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
        }
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }
    

        System.Diagnostics.Stopwatch sw;

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (btn_start.Text == "开始")
            {
                sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                timer1.Enabled = true;
                btn_start.Text = "停止";
                Random ra = new Random();
                Fuel.Exam.IsExaming = true;
                SetFault(ra.Next(7), 0);
                //SetFault(ra.Next(7), ra.Next(7)); 为2017岗位技能大赛设置，仅两个故障
                SetFault(ra.Next(7), ra.Next(7));
            }
            else if (btn_start.Text == "停止")
            {
                sw.Stop();
                timer1.Enabled = false;
                TimeSpan ts = sw.Elapsed;
                lb_timer.Text = String.Format("{0}:{1}", ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
                lb_timerm.Text = (ts.Milliseconds / 10).ToString("00");
                Fuel.Exam.CostTime = ts;
                btn_start.Text = "重置";
                Fuel.Exam.IsExaming = false;
                ShowResult();
            }
            else if (btn_start.Text == "重置")
            {
                lb_timer.Text = "00:00";
                lb_timerm.Text = "00";
                btn_start.Text = "开始";
                ResetRack();
            }
        }

        private void ResetRack()
        {
            Fuel.Tank.initTank();
            Fuel.Exam.init();
            btn_comReplace.Enabled = true ;
            btn_tu1Replace.Enabled = true;
            btn_tu2Replace.Enabled = true;
            btn_tu3Replace.Enabled = true;
            btn_tu4Replace.Enabled = true;
            btn_tu5Replace.Enabled = true;
            btn_tu6Replace.Enabled = true;
        }

        private void ShowResult()
        {
            string p = "";
       string fault = "";
            for (int i = 0; i < Fuel.Exam.FaultProbes.Count; i++)
            {
                fault += Fuel.Exam.FaultProbes[i];
            }
            p += fault + "\n";
            string replace = "";
            for (int i = 0; i < Fuel.Exam.ReplacedProbes.Count; i++)
            {
                replace += string.Format("已更换部件{0}\n", Fuel.Exam.ReplacedProbes[i].Name);
            }
            p += replace + "\n";

            if (Fuel.Exam.FaultCMP || Fuel.Exam.FaultTU1 || Fuel.Exam.FaultTU2 || Fuel.Exam.FaultTU3 || Fuel.Exam.FaultTU4 || Fuel.Exam.FaultTU5 || Fuel.Exam.FaultTU6)
            {
               
                p += "未正确更换所有故障部件,罚时3分钟\n";
                Fuel.Exam.PenaltyTime += new TimeSpan(0, 3, 0);
            }
            else
            {
                p += "已正确更换所有故障部件\n";
            }

            if (Fuel.Exam.ConnWhenCBClosed)
            {
                p +=string.Format( "在跳开关闭合时进行了接线操作,共{0}次，罚时{0}分钟\n",Fuel.Exam.CountConnWhenCBClosed/2);
                Fuel.Exam.PenaltyTime += new TimeSpan(0, Fuel.Exam.CountConnWhenCBClosed/2, 0);
            }

            if (Fuel.Exam.UnACFTWhenOpenCB)
            {
                p += string.Format("未在拔跳开关之前将流量表归零，共{0}次，罚时{0}分钟\n", Fuel.Exam.CountUnACFTWhenOpenCB);
                Fuel.Exam.PenaltyTime += new TimeSpan(0, Fuel.Exam.CountUnACFTWhenOpenCB, 0);           
            }

            double quantity = (Fuel.Tank.SimTank - 303.5 + Fuel.Tank.TankAll.Capacitance) / 113.2 * 42 / (Fuel.Tank.SimCap - 39 + Fuel.Tank.Comp.Capacitance) * 10000;
               
            p += string.Format("油量表实际值:{0}\n", Convert.ToInt32(quantity));

            p += string.Format("共耗时{0}:{1}, 罚时{3}:{4}\n", Fuel.Exam.CostTime.Minutes.ToString("00"), Fuel.Exam.CostTime.Seconds.ToString("00"), Fuel.Exam.CostTime.Milliseconds.ToString("00"), Fuel.Exam.PenaltyTime.Minutes.ToString("00"), Fuel.Exam.PenaltyTime.Seconds.ToString("00"));
           //  TimeSpan allTime=Fuel.Exam.CostTime+Fuel.Exam.PenaltyTime;
          //   p += string.Format("总成绩为{0}:{1}\n", allTime.Minutes.ToString("00"), allTime.Seconds.ToString("00"));
             p += "注意：请不要关闭此对话框，等待考官根据答题卡计算总成绩......";
            //MessageBox.Show(p);
            result resultform = new result();
            resultform.Controls["label1"].Text=p;
            resultform.Show();
            
        }

        private void SetFault(int faultComponent,int faultMode)
        {
           Random ra = new Random();
          //  Fuel.Indicator.Begin = 950 + (int)(100 * ra.NextDouble());
         //   Fuel.Indicator.Valve = Fuel.Indicator.Begin;
            //lb_Indicator.Text = Fuel.Indicator.Valve.ToString();
        //    int sel = ra.Next(7); //随机一个故障部件
        //  //  faultComponent = sel;
         //   int a = ra.Next(7);//随机一个故障模式，0为电容，1为绝缘性
          //  lb_Result.Text += sel.ToString() + a.ToString();
            Fuel.Probe faultProbe = new Fuel.Probe();     
            if (faultComponent == 0)
            {
             /*不给补偿器设置电阻故障的模式了
                switch (faultMode)
                {
                    case 0:
                        Fuel.Tank.Comp.Capacitance = 0 + 30 * ra.NextDouble();
                        break;
                    case 1:
                        Fuel.Tank.Comp.CG = 0 + 5 * ra.NextDouble();
                        break;
                    case 2:
                        Fuel.Tank.Comp.CH = 0 + 100 * ra.NextDouble();
                        break;
                    case 3:
                        Fuel.Tank.Comp.CS = 0 + 5 * ra.NextDouble();
                        break;
                    default:
                        Fuel.Tank.Comp.LC = 0 + 100 * ra.NextDouble();
                        break;
                }
              */
                faultMode = 0;
                Fuel.Tank.Comp.Capacitance = 0 + 30 * ra.NextDouble();
                Fuel.Exam.FaultProbes.Add(string.Format("故障部件:{0}，故障参数{1}\n","COMP",faultMode));
                Fuel.Exam.FaultCMP = true;
            }
            else
            {
                switch (faultComponent)
                {

                    case 1:
                        faultProbe = Fuel.Tank.Tu1;
                        Fuel.Exam.FaultTU1 = true;
                        break;
                    case 2:
                        faultProbe = Fuel.Tank.Tu2;
                        Fuel.Exam.FaultTU2 = true;
                        break;
                    case 3:
                        faultProbe = Fuel.Tank.Tu3;
                        Fuel.Exam.FaultTU3 = true;
                        break;
                    case 4:
                        faultProbe = Fuel.Tank.Tu4;
                        Fuel.Exam.FaultTU4 = true;
                        break;
                    case 5:
                        faultProbe = Fuel.Tank.Tu5;
                        Fuel.Exam.FaultTU5 = true;
                        break;
                    case 6:
                        faultProbe = Fuel.Tank.Tu6;
                        Fuel.Exam.FaultTU6 = true;
                        break;
                    default:
                        faultProbe = Fuel.Tank.Tu1;
                        Fuel.Exam.FaultTU1 = true;
                        break;

                }
                Fuel.Exam.FaultProbes.Add(string.Format("故障部件:{0}，故障参数{1}\n", faultProbe.Name, faultMode));
                switch (faultMode)
                {
                    case 0:
                        faultProbe.Capacitance = 0 + 20 * ra.NextDouble();
                        break;
                    case 1:
                        faultProbe.LH = 0 + 100 * ra.NextDouble();
                        break;
                    case 2:
                        faultProbe.LS = 0 + 5 * ra.NextDouble();
                        break;
                    case 3:
                        faultProbe.LG = 0 + 5 * ra.NextDouble();
                        break;
                    case 4:
                        faultProbe.HG = 0 + 5 * ra.NextDouble();
                        break;
                    case 5:
                        faultProbe.HS = 0 + 5 * ra.NextDouble();
                        break;
                    case 6:
                        faultProbe.SG = 0 + 1 * ra.NextDouble();
                        break;
                    default:
                       // faultProbe = Fuel.Tank.Tu1;
                        break;
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = sw.Elapsed;

            lb_timer.Text = String.Format("{0}:{1}", ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
            lb_timerm.Text = (ts.Milliseconds / 10).ToString("00");
           
            if (ts.Minutes >= 15)   //针对2017技能大赛，项目设置为15分钟
            {
                btn_start_Click(new object(),new EventArgs());

            }
        }

        private int currentIndicate = 0;

        private void pic_CBclose_Click(object sender, EventArgs e)
        {
            pic_CBclose.Visible = false;
            pic_CBtrip.Visible = true;
            Fuel.CB.Closed = false;
            currentIndicate= (int)( aGauge1.Value *100+ aGauge2.Value*1000);
            if (Fuel.Exam.IsExaming & Fuel.Indicator.Valve > 1000)
            {
                Fuel.Exam.UnACFTWhenOpenCB = true;
                Fuel.Exam.CountUnACFTWhenOpenCB += 1;
               
            }
        }

        private void pic_CBtrip_Click(object sender, EventArgs e)
        {
            pic_CBclose.Visible = true;
            pic_CBtrip.Visible = false;
            Fuel.CB.Closed = true;
            Control.CheckForIllegalCrossThreadCalls = false;
            int targetValve = Fuel.Indicator.Valve;
            ParameterizedThreadStart pts = new ParameterizedThreadStart(valveToGauge);
            Thread td = new Thread(pts);
            td.Start(targetValve);
           // valveToGauge(targetValve); 改用多线程方式解决走表时界面不响应

          

        }

 


        public void valveToGauge(object _targetValve)
        {
            int targetValve = (int)_targetValve;
            if (currentIndicate <= targetValve)
            {
                for (int i = currentIndicate; i <= targetValve; i=i+2)
                {
                    aGauge2.Value = (float)Convert.ToDouble(i) / 1000;
                    aGauge1.Value = (float)Convert.ToDouble(i) % 1000 / 100;
                   

                }
            }
            else
            {
                for (int i = currentIndicate; i >= targetValve; i = i -2)
                {
                    aGauge2.Value = (float)Convert.ToDouble(i) / 1000;
                    aGauge1.Value = (float)Convert.ToDouble(i) % 1000 / 100;
                    
                }
            }
            currentIndicate = targetValve;
           
        }
        private void btn_comReplace_Click(object sender, EventArgs e)
        {
            Fuel.Tank.initComp();
            if (Fuel.Exam.IsExaming)
            {
                Fuel.Exam.FaultCMP = !Fuel.Exam.FaultCMP;
                btn_comReplace.Enabled = false;
                Fuel.Exam.ReplacedProbes.Add(Fuel.Tank.Comp);
            }
        }

        private void btn_tu1Replace_Click(object sender, EventArgs e)
        {
            Fuel.Tank.initTu(78.5, Fuel.Tank.Tu1);
            if (Fuel.Exam.IsExaming)
            {               
                Fuel.Exam.FaultTU1 = !Fuel.Exam.FaultTU1;
                btn_tu1Replace.Enabled = false;
                Fuel.Exam.ReplacedProbes.Add(Fuel.Tank.Tu1);
            }
        }
  
        private void btn_tu2Replace_Click(object sender, EventArgs e)
        {
            Fuel.Tank.initTu(65, Fuel.Tank.Tu2);
            if (Fuel.Exam.IsExaming)
            {
                Fuel.Exam.FaultTU2 = !Fuel.Exam.FaultTU2;
                btn_tu2Replace.Enabled = false;
                Fuel.Exam.ReplacedProbes.Add(Fuel.Tank.Tu2);
            }
        }

        private void btn_tu3Replace_Click(object sender, EventArgs e)
        {
            if (Fuel.Exam.IsExaming)
            {
                Fuel.Tank.initTu(55, Fuel.Tank.Tu3);
                Fuel.Exam.FaultTU3 = !Fuel.Exam.FaultTU3;
                btn_tu3Replace.Enabled = false;
                Fuel.Exam.ReplacedProbes.Add(Fuel.Tank.Tu3);
            }
        }

        private void btn_tu4Replace_Click(object sender, EventArgs e)
        {
            Fuel.Tank.initTu(45, Fuel.Tank.Tu4); 
            if (Fuel.Exam.IsExaming)
            {
                Fuel.Exam.FaultTU4 = !Fuel.Exam.FaultTU4;
                btn_tu4Replace.Enabled = false;
                Fuel.Exam.ReplacedProbes.Add(Fuel.Tank.Tu4);
            }
        }

        private void btn_tu5Replace_Click(object sender, EventArgs e)
        {
            Fuel.Tank.initTu(35, Fuel.Tank.Tu5);
            if (Fuel.Exam.IsExaming)
            {
                Fuel.Exam.FaultTU5 = !Fuel.Exam.FaultTU5;
                btn_tu5Replace.Enabled = false;
                Fuel.Exam.ReplacedProbes.Add(Fuel.Tank.Tu5);
            }
        }

        private void btn_tu6Replace_Click(object sender, EventArgs e)
        {
            Fuel.Tank.initTu(25, Fuel.Tank.Tu6);
            if (Fuel.Exam.IsExaming)
            {
                Fuel.Exam.FaultTU6 = !Fuel.Exam.FaultTU6;
                btn_tu6Replace.Enabled = false;
                Fuel.Exam.ReplacedProbes.Add(Fuel.Tank.Tu6);
            }
        }

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            if (panel2.Size.Height < 10)
            {
                return;

            }
            
            //设置大表底板大小
            aGauge2.Size = panel2.Size;

            //设置大表中心点
            Point centerPoint = new Point();
            centerPoint.X = panel2.Size.Width/2;
            centerPoint.Y = panel2.Size.Height * 130 / 348;
            aGauge2.Center = centerPoint;

            //设置大表表盘大小
            aGauge2.BaseArcRadius = 120 * panel2.Size.Height /348;
            aGauge2.NeedleRadius = 100 * panel2.Size.Height / 348;
            aGauge2.ScaleLinesInterInnerRadius = 108 *panel2.Size.Height / 348;
            aGauge2.ScaleLinesInterOuterRadius = 120 *panel2.Size.Height / 348;
            aGauge2.ScaleLinesMajorInnerRadius = 102* panel2.Size.Height / 348;
            aGauge2.ScaleLinesMajorOuterRadius = 120 * panel2.Size.Height / 348;
            aGauge2.ScaleLinesMinorInnerRadius = 110 * panel2.Size.Height / 348;
            aGauge2.ScaleLinesMinorOuterRadius = 120 * panel2.Size.Height / 348;
            aGauge2.ScaleNumbersRadius = 95 * panel2.Size.Height / 348;

            Font newfont = new Font("微软雅黑", 9 * panel2.Size.Height / 348);
            aGauge2.Font=newfont;

            //设置标签大小和位置
            Point labelCenter = new Point();
            labelCenter.X = panel2.Size.Width / 2 - label7.Size.Width/2;
            labelCenter.Y = panel2.Size.Height * 172 / 348;
            label7.Location = labelCenter;

            Font labelfont = new Font("微软雅黑", 12 * panel2.Size.Height / 348,FontStyle.Bold);
            label7.Font = newfont;


            //设置小表底板大小
            Size newSize = new System.Drawing.Size();
            newSize.Width = 114 * panel2.Size.Width / 348;
            newSize.Height = 114 * panel2.Size.Height / 348;
            aGauge1.Size =newSize;

            //设置小表位置
            Point locationPoint = new Point();
            locationPoint.X = panel2.Size.Width / 2 - aGauge1.Size.Width / 2;
            locationPoint.Y = 196 * panel2.Size.Height / 348;
            aGauge1.Location = locationPoint;

            //设置小表中心点
             centerPoint = new Point();
            centerPoint.X = aGauge1.Size. Width / 2;
            centerPoint.Y = aGauge1.Size.Height/2 ;
            aGauge1.Center = centerPoint;
     

            //设置小表表盘大小
            aGauge1.BaseArcRadius = 40 * panel2.Size.Height / 348;
            aGauge1.NeedleRadius = 38 * panel2.Size.Height / 348;
            aGauge1.ScaleLinesInterInnerRadius = 35 * panel2.Size.Height / 348;
            aGauge1.ScaleLinesInterOuterRadius = 40 * panel2.Size.Height / 348;
            aGauge1.ScaleLinesMajorInnerRadius = 35 * panel2.Size.Height / 348;
            aGauge1.ScaleLinesMajorOuterRadius = 40 * panel2.Size.Height / 348;
            aGauge1.ScaleLinesMinorInnerRadius = 35 * panel2.Size.Height / 348;
            aGauge1.ScaleLinesMinorOuterRadius = 40 * panel2.Size.Height / 348;
            aGauge1.ScaleNumbersRadius = 46 * panel2.Size.Height / 348;
                        
           // aGauge2.Font = newfont;
        
        }

 


        private void rack_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
        }

        private void rack_SizeChanged(object sender, EventArgs e)
        {
            Size s = new Size();
            s.Height= this.Size.Height-100;
            s.Width=this.Size.Width-8;

            tableLayoutPanel1.Size = s;

        }

    
   
  

    

 
      
     
    }
}
