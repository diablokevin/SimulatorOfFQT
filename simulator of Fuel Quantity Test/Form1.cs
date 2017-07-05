using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace simulator_of_Fuel_Quantity_Test
{
    public partial class Form1 : Form
    {
        public Fuel.led LedCurrent = new Fuel.led();
        private int power = 0;  //开关机状态 0关机 1开机
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }
        public Form1()
        {        
            InitializeComponent();
            Fuel.Tank.initTank();
            power = 1;   //设置为开机
            LedCurrent=new Fuel.MainMenu();
            LedFresh(LedCurrent);
            lb_Measurement.Parent = pictureBox2;
          
            
        }
        /* 换成静态类的方法试试
        private void initTank()
        {
            Random ra = new Random();

            //各传感器及补偿器电容的初始化
            Fuel.Tank.Tu1.Capacitance = 78.5 - 2 + 4 * ra.NextDouble();
            Fuel.Tank.Tu2.Capacitance = 65 - 2 + 4 * ra.NextDouble();
            Fuel.Tank.Tu3.Capacitance = 55 - 2 + 4 * ra.NextDouble();
            Fuel.Tank.Tu4.Capacitance = 45 - 2 + 4 * ra.NextDouble();
            Fuel.Tank.Tu5.Capacitance = 35 - 2 + 4 * ra.NextDouble();
            Fuel.Tank.Tu6.Capacitance = 25 - 2 + 4 * ra.NextDouble();
            Fuel.Tank.Comp.Capacitance = 39 - 2 + 4 * ra.NextDouble();

            //补偿器绝缘性的初始化
            Fuel.Tank.Comp.CG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Comp.CH = 800.0 + 2000 * ra.NextDouble();
            Fuel.Tank.Comp.CS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Comp.LC = 800.0 + 2000 * ra.NextDouble();
            
            //各传感器绝缘性的初始化
            Fuel.Tank.Tu1.HG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu1.HS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu1.LG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu1.LH = 800.0 + 2000 * ra.NextDouble();
            Fuel.Tank.Tu1.LS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu1.SG = 20.0 + 100 * ra.NextDouble();

            Fuel.Tank.Tu2.HG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu2.HS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu2.LG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu2.LH = 800.0 + 2000 * ra.NextDouble();
            Fuel.Tank.Tu2.LS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu2.SG = 20.0 + 100 * ra.NextDouble();

            Fuel.Tank.Tu3.HG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu3.HS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu3.LG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu3.LH = 800.0 + 2000 * ra.NextDouble();
            Fuel.Tank.Tu3.LS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu3.SG = 20.0 + 100 * ra.NextDouble();

            Fuel.Tank.Tu4.HG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu4.HS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu4.LG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu4.LH = 800.0 + 2000 * ra.NextDouble();
            Fuel.Tank.Tu4.LS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu4.SG = 20.0 + 100 * ra.NextDouble();

            Fuel.Tank.Tu5.HG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu5.HS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu5.LG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu5.LH = 800.0 + 2000 * ra.NextDouble();
            Fuel.Tank.Tu5.LS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu5.SG = 20.0 + 100 * ra.NextDouble();

            Fuel.Tank.Tu6.HG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu6.HS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu6.LG = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu6.LH = 800.0 + 2000 * ra.NextDouble();
            Fuel.Tank.Tu6.LS = 80.0 + 200 * ra.NextDouble();
            Fuel.Tank.Tu6.SG = 20.0 + 100 * ra.NextDouble(); 
        }
        */

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("亮度可以不用调...");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (power == 0)
            {
                power = 1;   //设置为开机
                LedCurrent = new Fuel.MainMenu();
                pictureBox3.Visible = true;
                lb_Date.Visible = true;
                LedFresh(LedCurrent);
                
            }
            else
            {
                LedFresh(new Fuel.led());
                pictureBox3.Visible = false;
                lb_Date.Visible = false;
                power = 0;
            }
          
        }

        private void LedFresh(Fuel.led led)
        {

            Delay(350);
           // System.Threading.Thread.Sleep(350);
            lb_F1.ForeColor = Color.Black;
            lb_F1.BackColor = Color.Transparent;
           
            lb_F2.ForeColor = Color.Black;
            lb_F2.BackColor = Color.Transparent;

            lb_F3.ForeColor = Color.Black;
            lb_F3.BackColor = Color.Transparent;

            lb_F4.ForeColor = Color.Black;
            lb_F4.BackColor = Color.Transparent;

            lb_F5.ForeColor = Color.Black;
            lb_F5.BackColor = Color.Transparent;

            lb_F6.ForeColor = Color.Black;
            lb_F6.BackColor = Color.Transparent;
                   
            switch (led.ItemSelect)
            {
                case 0:
                    break;
                case 1:
                   LedCurrent.F1();
                   lb_F1.ForeColor = Color.Transparent;
                    lb_F1.BackColor = Color.Black;
                    
                    break;
                case 2:
                   LedCurrent.F2();
                   lb_F2.ForeColor = Color.Transparent;
                    lb_F2.BackColor = Color.Black;
                    break;
                case 3:
                   LedCurrent.F3();
                   lb_F3.ForeColor = Color.Transparent;
                    lb_F3.BackColor = Color.Black;
                    break;
                case 4:
                   LedCurrent.F4();
                   lb_F4.ForeColor = Color.Transparent;
                    lb_F4.BackColor = Color.Black;
                    break;
                case 5:
                   LedCurrent.F5();
                   lb_F5.ForeColor = Color.Transparent;
                    lb_F5.BackColor = Color.Black;
                    break;
                case 6:
                    LedCurrent.F6();
                    lb_F6.ForeColor = Color.Transparent;
                    lb_F6.BackColor = Color.Black;
                    break;
                default:
                    break;
            }
            lb_arrow.Visible = led.Shownext;
            lb_F1.Text = led.F1_text;
            lb_F2.Text = led.F2_text;
            lb_F3.Text = led.F3_text;
            lb_F4.Text = led.F4_text;
            lb_F5.Text = led.F5_text;
            lb_F6.Text = led.F6_text;
            lb_Fuction.Text = led.Function;
            lb_Instruction.Text = led.Instruction;          
            lb_Mode.Text = led.Mode;
            lb_range.Text = led.Range;
            lb_Unit.Text = led.Unit;
            //lb_Indicator.Text = Fuel.Indicator.Valve.ToString();
            if (Fuel.CB.Closed)
            {

                int targetValve = Fuel.Indicator.Valve;
                ParameterizedThreadStart pts = new ParameterizedThreadStart(formrack.valveToGauge);
                Thread td = new Thread(pts);
                td.Start(targetValve);
             //   formrack.valveToGauge(Fuel.Indicator.Valve);
            }
            if (led.Measurement == "TEST OK")
            {
                int i = 0;
                while (i < 10000)
                {
                    lb_Measurement.Text = i.ToString();
                    Random ra = new Random();
                    i = i + ra.Next(3000, 5000);
                    Delay(200); 
                }
                lb_Measurement.Text = led.Measurement;
            }
            else
            {
                lb_Measurement.Text = led.Measurement;
            }
        }
        private void LedFresh(Fuel.led led,bool isPostback)
        {


           // Delay(350); 为2017岗位技能大赛设置，取消延迟
            lb_F1.ForeColor = Color.Black;
            lb_F1.BackColor = Color.Transparent;

            lb_F2.ForeColor = Color.Black;
            lb_F2.BackColor = Color.Transparent;

            lb_F3.ForeColor = Color.Black;
            lb_F3.BackColor = Color.Transparent;

            lb_F4.ForeColor = Color.Black;
            lb_F4.BackColor = Color.Transparent;

            lb_F5.ForeColor = Color.Black;
            lb_F5.BackColor = Color.Transparent;

            lb_F6.ForeColor = Color.Black;
            lb_F6.BackColor = Color.Transparent;

            switch (led.ItemSelect)
            {
                case 0:
                    break;
                case 1:
                    // LedCurrent.F1();
                    lb_F1.ForeColor = Color.Transparent;
                    lb_F1.BackColor = Color.Black;

                    break;
                case 2:
                    //  LedCurrent.F2();
                    lb_F2.ForeColor = Color.Transparent;
                    lb_F2.BackColor = Color.Black;
                    break;
                case 3:
                    //  LedCurrent.F3();
                    lb_F3.ForeColor = Color.Transparent;
                    lb_F3.BackColor = Color.Black;
                    break;
                case 4:
                    // LedCurrent.F4();
                    lb_F4.ForeColor = Color.Transparent;
                    lb_F4.BackColor = Color.Black;
                    break;
                case 5:
                    //  LedCurrent.F5();
                    lb_F5.ForeColor = Color.Transparent;
                    lb_F5.BackColor = Color.Black;
                    break;
                case 6:
                    //  LedCurrent.F6();
                    lb_F6.ForeColor = Color.Transparent;
                    lb_F6.BackColor = Color.Black;
                    break;
                default:
                    break;
            }
            lb_arrow.Visible = led.Shownext;
            lb_F1.Text = led.F1_text;
            lb_F2.Text = led.F2_text;
            lb_F3.Text = led.F3_text;
            lb_F4.Text = led.F4_text;
            lb_F5.Text = led.F5_text;
            lb_F6.Text = led.F6_text;
            lb_Fuction.Text = led.Function;
            lb_Instruction.Text = led.Instruction;
            lb_Measurement.Text = led.Measurement;
            lb_Mode.Text = led.Mode;
            lb_range.Text = led.Range;
            lb_Unit.Text = led.Unit;
            //lb_Indicator.Text = Fuel.Indicator.Valve.ToString();
        
          
        }
        private Fuel.led init()
        {
            Fuel.led led = new Fuel.led();
            led.Date = DateTime.Now.ToString("MM/dd/yyyy");
            led.F1_text = "AUTO";
            led.F2_text = "MON";
            led.F3_text = "INS";
            led.F4_text = "CAP";
            led.F5_text = "SIM";
            led.F6_text = "CAL";
            led.Function = "SELECT FUNCTION TO CONTINUE";
            led.Instruction = "Calibration due " + DateTime.Now.AddDays(30).ToString("MM/dd/yyyy");
            led.Measurement = "MAIN MENU";
            led.Mode = "";
            led.Range = "";
            led.Shownext = true;
            led.Unit = ""; 
          
            return led;
        }

        private Fuel.led menuauto(Fuel.led led)
        {
            
            return led;
        }

        private void btn_F1_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.F1();

            if (led == null)
            {
                MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent);

            }
        }

        private void btn_F2_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.F2();

            if (led == null)
            {
                MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent);

            }
        }

        private void btn_F3_Click(object sender, EventArgs e)
        {
            Fuel.led led=LedCurrent.F3();

            if (led == null)
            {
                MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent);
                
            }
        }

        private void btn_F4_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.F4();

            if (led == null)
            {
                MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent);

            }
        }

        private void btn_F5_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.F5();

            if (led == null)
            {
                MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent);

            }
        }

        private void btn_F6_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.F6();

            if (led == null)
            {
                MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent);

            }
        }

        private void btn_MODE_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.BtnMode();

            if (led == null)
            {
               // MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent,true);

            }
        }

        private void btn_RANGE_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.BtnRange();

            if (led == null)
            {
               // MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent,true);

            }
        }

        private void btn_NEXT_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.BtnNext();

            if (led == null)
            {
              //  MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent);

            }
        }

        private void btn_BACK_Click(object sender, EventArgs e)
        {
            Fuel.led led = LedCurrent.BtnBack();

            if (led == null)
            {
             //   MessageBox.Show("和比赛无关，这个功能就不做啦~");
            }
            else
            {
                LedCurrent = led;
                LedFresh(LedCurrent);

            }
        }

      
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox8.Visible = radioButton1.Checked;
            pictureBox9.Visible = radioButton2.Checked;
            panel1.Visible = radioButton2.Checked;
            routingRefresh();
            LedFresh(LedCurrent);

            if (Fuel.Exam.IsExaming&Fuel.CB.Closed)
            {
                Fuel.Exam.ConnWhenCBClosed = true;
                Fuel.Exam.CountConnWhenCBClosed += 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox8.Visible = radioButton1.Checked;
            pictureBox9.Visible = radioButton2.Checked;
            panel1.Visible = radioButton2.Checked;
            routingRefresh();
            LedFresh(LedCurrent);
            if (Fuel.Exam.IsExaming & Fuel.CB.Closed)
            {
                Fuel.Exam.ConnWhenCBClosed = true;
                Fuel.Exam.CountConnWhenCBClosed += 1;

            }
        }


        private void routingRefresh()
        {
            Fuel.Routing.Bus = radioButton2.Checked ? 1 : 0; 
            if(ra_comp.Checked)
            {
                Fuel.Routing.Knob = 0;
            }
            if (ra_TU1.Checked)
            {
                Fuel.Routing.Knob = 1;
            }
            if (ra_TU2.Checked)
            {
                Fuel.Routing.Knob = 2;
            }
            if (ra_TU3.Checked)
            {
                Fuel.Routing.Knob = 3;
            }
            if (ra_TU4.Checked)
            {
                Fuel.Routing.Knob = 4;
            }
            if (ra_TU5.Checked)
            {
                Fuel.Routing.Knob = 5;
            }
            if (ra_TU6.Checked)
            {
                Fuel.Routing.Knob = 6;
            }
        }

        private void ra_comp_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                routingRefresh();
                LedFresh(LedCurrent);
            }
        }

        private void ra_TU1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                routingRefresh();
                LedFresh(LedCurrent);
            }
        }

        private void ra_TU2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                routingRefresh();
                LedFresh(LedCurrent);
            }
        }

        private void ra_TU3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                routingRefresh();
                LedFresh(LedCurrent);
            }
        }

        private void ra_TU4_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                routingRefresh();
                LedFresh(LedCurrent);
            }
        }

        private void ra_TU5_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                routingRefresh();
                LedFresh(LedCurrent);
            }
        }

        private void ra_TU6_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                routingRefresh();
                LedFresh(LedCurrent);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fuel.Tank.initTank();
         
            LedFresh(LedCurrent);
        }

        private int faultComponent = -1;

     

        private void btn_NUM1_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if(LedCurrent.Instruction== "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "1";
                LedFresh(LedCurrent,true);
            }
        }

        private void btn_NUM2_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "2";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_NUM3_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "3";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_NUM4_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "4";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_NUM5_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "5";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_NUM6_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "6";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_NUM7_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "7";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_NUM8_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "8";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_NUM9_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "9";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_NUM0_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += "0";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_Dot_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction == "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "";
                }
                LedCurrent.Instruction += ".";
                LedFresh(LedCurrent, true);
            }
        }

        private void btn_ENT_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction != "Enter value between 10 & 10,000 pF")
                {
                    System.Threading.Thread.Sleep(1000);
                    LedCurrent.Measurement = LedCurrent.Instruction;
                    if (LedCurrent.ItemSelect == 1)
                    {
                        Fuel.Tank.SimTank = Convert.ToDouble(LedCurrent.Measurement);
                    }
                    else if (LedCurrent.ItemSelect == 2)
                    {
                        Fuel.Tank.SimCap = Convert.ToDouble(LedCurrent.Measurement);
                    }
                    LedCurrent.Instruction = "Enter value between 10 & 10,000 pF";
                    LedFresh(LedCurrent, true);
                }
               
            }
        }

        private void btn_CLR_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction != "Enter value between 10 & 10,000 pF")
                {
                    LedCurrent.Instruction = "Enter value between 10 & 10,000 pF";
                    LedFresh(LedCurrent, true);
                }

            }
        }

        private void DEL_Click(object sender, EventArgs e)
        {
            if (LedCurrent.Function == "MEASURE SIMULATION")
            {
                if (LedCurrent.Instruction != "Enter value between 10 & 10,000 pF")
                {
                    if (LedCurrent.Instruction.Length != 1)
                    {
                        LedCurrent.Instruction = LedCurrent.Instruction.Substring(0, LedCurrent.Instruction.Length - 1);
                        
                    }
                    else
                    {
                        LedCurrent.Instruction = "Enter value between 10 & 10,000 pF";
                    }
                    LedFresh(LedCurrent, true);
                }

            }
        }


        private rack formrack = new rack();
        private void Form1_Load(object sender, EventArgs e)
        {

            formrack.Show();
        }

    
        
     



   
   
    }
}
