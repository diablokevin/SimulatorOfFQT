using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace simulator_of_Fuel_Quantity_Test
{
    public  class Fuel
    {
       
        public class compensator:Probe
        {
            public compensator(string p)
            {
                this.Name=p;
            }

      
            private double lC = 0.0;

            public double LC
            {
                get { return lC; }
                set { lC = value; }
            }
            private double cH = 0.0;

            public double CH
            {
                get { return cH; }
                set { cH = value; }
            }
            private double cS = 0.0;

            public double CS
            {
                get { return cS; }
                set { cS = value; }
            }
            private double cG = 0.0;

            public double CG
            {
                get { return cG; }
                set { cG = value; }
            }

            
        }
        public class Probe
        {
            public Probe()
            {
                this.name = "default";
            }
            public Probe(string p)
            {
                this.name=p;
            }

             private string name="";

                public string Name
                {
                  get { return name; }
                  set { name = value; }
                }


            private double capacitance = 0.0;

            public double Capacitance
            {
                get { return capacitance; }
                set { capacitance = value; }
            }

            private double lH = 0.0;

            public double LH
            {
                get { return lH; }
                set { lH = value; }
            }
            private double lS = 0.0;

            public double LS
            {
                get { return lS; }
                set { lS = value; }
            }
            private double lG = 0.0;

            public double LG
            {
                get { return lG; }
                set { lG = value; }
            }
            private double hG = 0.0;

            public double HG
            {
                get { return hG; }
                set { hG = value; }
            }
            private double hS = 0.0;

            public double HS
            {
                get { return hS; }
                set { hS = value; }
            }
            private double sG = 0.0;

            public double SG
            {
                get { return sG; }
                set { sG = value; }
            }
      
        }
        
        public static class Tank
        {
            private static Probe tankAll = new Probe("TANK");

            public static Probe TankAll
            {
                get 
                {
                    tankAll.Capacitance = tu1.Capacitance + tu2.Capacitance + tu3.Capacitance + tu4.Capacitance + tu5.Capacitance + tu6.Capacitance;
                    tankAll.HG = 1 / (1 / tu1.HG + 1 / tu2.HG + 1 / tu3.HG + 1 / tu4.HG + 1 / tu5.HG + 1 / tu6.HG+1/comp.HG);
                    tankAll.LH = 1 / (1 / tu1.LH + 1 / tu2.LH + 1 / tu3.LH + 1 / tu4.LH + 1 / tu5.LH + 1 / tu6.LH + 1 / comp.HG);
                    tankAll.LS = 1 / (1 / tu1.LS + 1 / tu2.LS + 1 / tu3.LS + 1 / tu4.LS + 1 / tu5.LS + 1 / tu6.LS + 1 / comp.LS);
                    tankAll.LG = 1 / (1 / tu1.LG + 1 / tu2.LG + 1 / tu3.LG + 1 / tu4.LG + 1 / tu5.LG + 1 / tu6.LG + 1 / comp.LG);
                    tankAll.HS = 1 / (1 / tu1.HS + 1 / tu2.HS + 1 / tu3.HS + 1 / tu4.HS + 1 / tu5.HS + 1 / tu6.HS + 1 / comp.HS);
                    tankAll.SG = 1 / (1 / tu1.SG + 1 / tu2.SG + 1 / tu3.SG + 1 / tu4.SG + 1 / tu5.SG + 1 / tu6.SG + 1 / comp.SG);
                    return tankAll; 
                }
               
            }



            private static Probe tu1 = new Probe("TU1");

            public static Probe Tu1
            {
                get { return tu1; }
                set { tu1 = value; }
            }


            private static Probe tu2 = new Probe("TU2");

            public static Probe Tu2
            {
                get { return tu2; }
                set { tu2 = value; }
            }
            private static Probe tu3 = new Probe("TU3");

            public static Probe Tu3
            {
                get { return tu3; }
                set { tu3 = value; }
            }
            private static Probe tu4 = new Probe("TU4");

            public static Probe Tu4
            {
                get { return tu4; }
                set { tu4 = value; }
            }
            private static Probe tu5 = new Probe("TU5");

            public static Probe Tu5
            {
                get { return tu5; }
                set { tu5 = value; }
            }
            private static Probe tu6 = new Probe("TU6");

            public static Probe Tu6
            {
                get { return tu6; }
                set { tu6 = value; }
            }
            private static compensator comp = new compensator("COMP");

            public static compensator Comp
            {
                get { return comp; }
                set { comp = value; }
            }

            public static void initComp()
            {
                Random ra = new Random();

                //补偿器电容的初始化
                Fuel.Tank.Comp.Capacitance = 39 - 2 + 4 * ra.NextDouble();
                
                /*补偿器绝缘性的初始化1.0
                Fuel.Tank.Comp.HG = 80.0 + 200 * ra.NextDouble();
                Fuel.Tank.Comp.HS = 80.0 + 200 * ra.NextDouble();
                Fuel.Tank.Comp.LG = 80.0 + 200 * ra.NextDouble();
                Fuel.Tank.Comp.LH = 800.0 + 2000 * ra.NextDouble();
                Fuel.Tank.Comp.LS = 80.0 + 200 * ra.NextDouble();
                Fuel.Tank.Comp.SG = 20.0 + 100 * ra.NextDouble();
                Fuel.Tank.Comp.CG = 80.0 + 200 * ra.NextDouble();
                Fuel.Tank.Comp.CH = 200.0 + 200 * ra.NextDouble();
                Fuel.Tank.Comp.CS = 80.0 + 200 * ra.NextDouble();
                Fuel.Tank.Comp.LC = 200.0 + 200 * ra.NextDouble();
                */
                //补偿器绝缘性的初始化2.0
                Fuel.Tank.Comp.HG = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.HS = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.LG = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.LH = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.LS = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.SG = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.CG = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.CH = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.CS = 10000 + 1000 * ra.NextDouble();
                Fuel.Tank.Comp.LC = 10000 + 1000 * ra.NextDouble();
            }

            public static void initTu(double cap,Probe tu)
            {

                Random ra = new Random();
                //传感器电容的初始化
                tu.Capacitance = cap - 0.5 + 1 * ra.NextDouble();  

              
                /*各传感器绝缘性的初始化1.0
                tu.HG = 80.0 + 200 * ra.NextDouble();
                tu.HS = 80.0 + 200 * ra.NextDouble();
                tu.LG = 80.0 + 200 * ra.NextDouble();
                tu.LH = 800.0 + 500 * ra.NextDouble();
                tu.LS = 80.0 + 200 * ra.NextDouble();
                tu.SG = 20.0 + 100 * ra.NextDouble();
                */

                //各传感器绝缘性的初始化2.0
                tu.HG = 10000 + 1000 * ra.NextDouble();
                tu.HS = 10000 + 1000 * ra.NextDouble();
                tu.LG = 10000 + 1000 * ra.NextDouble();
                tu.LH = 10000 + 1000 * ra.NextDouble();
                tu.LS = 10000 + 1000 * ra.NextDouble();
                tu.SG = 10000 + 1000 * ra.NextDouble();
            
            }

            public static void initTank()
            {
              
                initComp();
                initTu(78.5, tu1);
                Thread.Sleep(50);
                initTu(65.0, tu2);
                Thread.Sleep(50);
                initTu(55.0, tu3);
                Thread.Sleep(50);
                initTu(45.0, tu4);
                Thread.Sleep(50);
                initTu(35.0, tu5);
                Thread.Sleep(50);
                initTu(25.0, tu6);
                simTank = 0.0;
                simCap = 0.0;
         
            }

            private static double simTank = 0.0;

            public static double SimTank
            {
                get { return Tank.simTank; }
                set { Tank.simTank = value; }
            }

            private static double simCap = 0.0;

            public static double SimCap
            {
                get { return Tank.simCap; }
                set { Tank.simCap = value; }
            }

   
        }
        public static class Routing
        {
            private static int bus = 0;  //连线状态，0表示用611-00050接线，1表示用611-00051接线

            public static int Bus
            {
                get { return Routing.bus; }
                set { Routing.bus = value; }
            }

            private static int knob = 0; //选成611-00051接线时，适配器上的旋钮状态，0表示COMP,1:TU1 ..... 6:TU6

            public static int Knob
            {
                get { return Routing.knob; }
                set { Routing.knob = value; }
            }

        }
        public static class Indicator
        {
            /* 改版后不需要直接赋值了，全靠建模计算
            private static int begin = -250 + (int)(500 * ((new Random()).NextDouble()));

            public static int Begin
            {
                get { return begin; }
                set { begin = value; }
            }
            private static int end = 9500 + (int)(1000 * ((new Random()).NextDouble()));

            public static int End
            {
                get { return end; }
                set { end = value; }
            }
             */ 
            private static int valve =0;

            public static int Valve
            {
                get { return Indicator.valve; }
                set { Indicator.valve = value; }
            }

            /*
            public static int Valve
            {
                get 
                {
                    if (CB.Closed)
                    {
                        if (Tank.IsOnlySim)
                        {
                            double quantity = 0.0;
                            quantity = (Tank.SimTank - 303.5) / 113.2 * 42 / (Tank.SimCap - 39) * 10000;
                            return Convert.ToInt16(quantity);
                        }
                        else
                        {
                            double quantity = 0.0;
                            quantity = (Tank.SimTank - 303.5+Tank.TankAll.Capacitance) / 113.2 * 42 / (Tank.SimCap - 39+Tank.Comp.Capacitance) * 10000;
                            return Convert.ToInt16(quantity);
                        }
                        
                       
                    }
                    else
                    {
                        return 0;
                    }
                    
                    
                    
                   
                }
               
            }
             */ 

        }
        public static class Exam
        {
            public static void init()
            {
                faultProbes = new List<string>();
                replacedProbes = new List<Probe>();
                costTime = new TimeSpan(0, 0, 0, 0, 0);
                penaltyTime = new TimeSpan(0, 0, 0, 0, 0);
                faultCMP = false;
                faultTU1 = false;
                faultTU2 = false;
                faultTU3 = false;
                faultTU4 = false;
                faultTU5 = false;
                faultTU6 = false;
                isExaming = false;
                connWhenCBClosed = false;
                countConnWhenCBClosed = 0;
                unACFTWhenOpenCB = false;
                countUnACFTWhenOpenCB = 0;

            }

            private static bool isExaming = false;

            public static bool IsExaming
            {
                get { return Exam.isExaming; }
                set { Exam.isExaming = value; }
            }

            private static List<string> faultProbes = new List<string>();

            public static List<string> FaultProbes
            {
                get { return Exam.faultProbes; }
                set { Exam.faultProbes = value; }
            }

            private static bool faultCMP = false;

            public static bool FaultCMP
            {
                get { return Exam.faultCMP; }
                set { Exam.faultCMP = value; }
            }

            private static bool faultTU1 = false;

            public static bool FaultTU1
            {
                get { return Exam.faultTU1; }
                set { Exam.faultTU1 = value; }
            }
            private static bool faultTU2 = false;

            public static bool FaultTU2
            {
                get { return Exam.faultTU2; }
                set { Exam.faultTU2 = value; }
            }
            private static bool faultTU3 = false;

            public static bool FaultTU3
            {
                get { return Exam.faultTU3; }
                set { Exam.faultTU3 = value; }
            }
            private static bool faultTU4 = false;

            public static bool FaultTU4
            {
                get { return Exam.faultTU4; }
                set { Exam.faultTU4 = value; }
            }
            private static bool faultTU5 = false;

            public static bool FaultTU5
            {
                get { return Exam.faultTU5; }
                set { Exam.faultTU5 = value; }
            }
            private static bool faultTU6 = false;

            public static bool FaultTU6
            {
                get { return Exam.faultTU6; }
                set { Exam.faultTU6 = value; }
            }
            private static List<Fuel.Probe> replacedProbes = new List<Probe>();

            public static List<Fuel.Probe> ReplacedProbes
            {
                get { return Exam.replacedProbes; }
                set { Exam.replacedProbes = value; }
            }

            private static TimeSpan costTime = new TimeSpan(0, 0, 0, 0, 0);

            public static TimeSpan CostTime
            {
                get { return Exam.costTime; }
                set { Exam.costTime = value; }
            }

            private static TimeSpan penaltyTime = new TimeSpan(0, 0, 0, 0, 0);

            public static TimeSpan PenaltyTime
            {
                get { return Exam.penaltyTime; }
                set { Exam.penaltyTime = value; }
            }

            public static TimeSpan TotalTime
            {
                get { return costTime + penaltyTime; }
            }

            private static bool connWhenCBClosed = false;

            public static bool ConnWhenCBClosed
            {
                get { return Exam.connWhenCBClosed; }
                set { Exam.connWhenCBClosed = value; }
            }

            private static int countConnWhenCBClosed = 0;

            public static int CountConnWhenCBClosed
            {
                get { return Exam.countConnWhenCBClosed; }
                set { Exam.countConnWhenCBClosed = value; }
            }

            private static bool unACFTWhenOpenCB = false;

            public static bool UnACFTWhenOpenCB
            {
                get { return Exam.unACFTWhenOpenCB; }
                set { Exam.unACFTWhenOpenCB = value; }
            }

            private static int countUnACFTWhenOpenCB = 0;

            public static int CountUnACFTWhenOpenCB
            {
                get { return Exam.countUnACFTWhenOpenCB; }
                set { Exam.countUnACFTWhenOpenCB = value; }
            }
       
        }
        public class led
        {
            private string function;
            public string Function
            {
                get { return function; }
                set { function = value; }
            }
            private string date;

            public string Date
            {
                get { return date; }
                set { date = value; }
            }
            private string mode;

            public string Mode
            {
                get { return mode; }
                set { mode = value; }
            }
            private string unit;

            public string Unit
            {
                get { return unit; }
                set { unit = value; }
            }
            private string range;

            public string Range
            {
                get { return range; }
                set { range = value; }
            }
            private string instruction;

            public string Instruction
            {
                get { return instruction; }
                set { instruction = value; }
            }
            private string measurement;

            public string Measurement
            {
                get { return measurement; }
                set { measurement = value; }
            }
            private string f1_text;

            public string F1_text
            {
                get { return f1_text; }
                set { f1_text = value; }
            }
            private string f2_text;

            public string F2_text
            {
                get { return f2_text; }
                set { f2_text = value; }
            }
            private string f3_text;

            public string F3_text
            {
                get { return f3_text; }
                set { f3_text = value; }
            }
            private string f4_text;

            public string F4_text
            {
                get { return f4_text; }
                set { f4_text = value; }
            }
            private string f5_text;

            public string F5_text
            {
                get { return f5_text; }
                set { f5_text = value; }
            }
            private string f6_text;

            public string F6_text
            {
                get { return f6_text; }
                set { f6_text = value; }
            }

            private bool shownext = false;

            public bool Shownext
            {
                get { return shownext; }
                set { shownext = value; }
            }

            private int itemSelect = 0;

            public int ItemSelect
            {
                get { return itemSelect; }
                set { itemSelect = value; }
            }

            private int rangeID = 0;

            public int RangeID
            {
                get { return rangeID; }
                set { rangeID = value; }
            }

      

            public virtual Fuel.led F1()
            {
                return null;
            }
            public virtual Fuel.led F2()
            {
                return null;
            }
            public virtual Fuel.led F3()
            {
                return null;
            }
            public virtual Fuel.led F4()
            {
                return null;
            }
            public virtual Fuel.led F5()
            {
                return null;
            }
            public virtual Fuel.led F6()
            {
                return null;
            }
            public virtual Fuel.led BtnNext()
            {
                return null;
            }
            public virtual Fuel.led BtnBack()
            {
                return null;
            }
            public virtual Fuel.led BtnMode()
            {
                return null;
            }
            public virtual Fuel.led BtnRange()
            {
                return null;
            }
        }
        public static class CB
        {
            private static bool closed = false;

            public static bool Closed
            {
                get { return CB.closed; }
                set { CB.closed = value; }
            }

         
        }
        public class MainMenu : led
        {
        
            public  MainMenu()
            {

                
                this.F1_text = "AUTO";
                this.F2_text = "MON";
                this.F3_text = "INS";
                this.F4_text = "CAP";
                this.F5_text = "SIM";
                this.F6_text = "CAL";
                this.Function = "SELECT FUNCTION TO CONTINUE";
                this.Instruction = "Calibration due " + DateTime.Now.AddDays(30).ToString("MM/dd/yyyy");
                this.Measurement = "MAIN MENU";
                this.Mode = "";
                this.Range = "";
                this.Shownext = true;
                this.Unit = "";
                
            }
            public override led F1()
            {
                               
                return null;
            }
            public override led F2()
            {

                return null;
            }

            public override led F3()
            {

                return new MeasureInsulation();
            }

            public override led F4()
            {
                return new MeasureCapacitance();
            }
            public override led F5()
            {
                return new MeasureSimulation();
            }

            public override led F6()
            {
                return new Calibration();
            }
            public override led BtnBack()
            {
                return this;
            }
            public override led BtnMode()
            {
                return this;
            }
            public override led BtnNext()
            {
                return this;
            }
            public override led BtnRange()
            {
                return this;
            }
            
        }

        public class MeasureInsulation : led
        {
       
            public MeasureInsulation()
            {
                
                this.F1_text = "L/H";
                this.F2_text = "L/S";
                this.F3_text = "L/G";
                this.F4_text = "H/G";
                this.F5_text = "H/S";
                this.F6_text = "S/G";
                this.Function = "MEASURE INSULATION";
                this.Instruction = "";              
                this.Mode = "3T";
                this.Range = "400";
                this.Shownext = true;
                this.Unit = "MΩ";
                this.F1();
            }
            private int page = 0;
            
            public int Page
            {
                get { return page; }
                set { page = value; }
            }

         
            public override led F1()
            {

                this.ItemSelect = 1;
                double valve=Convert.ToDouble( GetMeasurement(ItemSelect));
                if (valve > 1000)
                {
                    this.Measurement = "TEST OK";
                }
                else
                {
                    this.Measurement = valve.ToString("f2");
                }
                       
                   
                   
            

                 /*太繁琐，重复代码太多
                if (Page == 0)
                {
                  
                    if (Routing.Bus == 0)
                    {
                        this.ItemSelect = 1;
                        this.Measurement = Tank.TankAll.LH.ToString("f2");
                    }
                    else
                    {
                        switch (Routing.Knob)
                        {
                            case 0:
                                this.Measurement = "0.0";
                                break;
                            case 1:
                                this.Measurement = Tank.Tu1.LH.ToString("f2");
                                break;
                            case 2:
                                this.Measurement = Tank.Tu2.LH.ToString("f2");
                                break;
                            case 3:
                                this.Measurement = Tank.Tu3.LH.ToString("f2");
                                break;
                            case 4:
                                this.Measurement = Tank.Tu4.LH.ToString("f2");
                                break;
                            case 5:
                                this.Measurement = Tank.Tu5.LH.ToString("f2");
                                break;
                            case 6:
                                this.Measurement = Tank.Tu6.LH.ToString("f2");
                                break;
                            default:
                                break;

                        }
                    }
                }
                else
                {
                    if (Routing.Bus == 0)
                    {
                        this.ItemSelect = 1;
                        this.Measurement = Tank.Comp.LC.ToString("f2");
                    }
                    else
                    {

                        this.Measurement = "0.0";

                    }
                }
                  */ 
               
                return this;
            }

            private string GetMeasurement(int ItemSelect)
            {
                string valve = "";
                if (Routing.Bus == 0)
                {
                    switch (page)
                    {
                        case 0:
                            switch (ItemSelect)
                            {
                                case 1:
                                    valve = Tank.TankAll.LH.ToString("f2");
                                    break;
                                case 2:
                                    valve = Tank.TankAll.LS.ToString("f2");
                                    break;
                                case 3:
                                    valve = Tank.TankAll.LG.ToString("f2");
                                    break;
                                case 4:
                                    valve = Tank.TankAll.HG.ToString("f2");
                                    break;
                                case 5:
                                    valve = Tank.TankAll.HS.ToString("f2");
                                    break;
                                case 6:
                                    valve = Tank.TankAll.SG.ToString("f2");
                                    break;
                            }
                            break;
                        case 1:
                            switch (ItemSelect)
                            {
                                case 1:
                                    valve = Tank.Comp.LC.ToString("f2");
                                    break;
                                case 2:
                                    valve = Tank.Comp.CH.ToString("f2");
                                    break;
                                case 3:
                                    valve = Tank.Comp.CS.ToString("f2");
                                    break;
                                case 4:
                                    valve = Tank.Comp.CG.ToString("f2");
                                    break;
                                
                            }                                                       
                            break;
                    }
                }
                else
                {
                    Probe sel = new Probe();
                    switch (page)
                    {
                        case 0:
                            switch (Routing.Knob)
                            {
                                case 0:
                                    sel = (Probe)Tank.Comp;
                                    break;
                                case 1:
                                    sel = Tank.Tu1;
                                    break;
                                case 2:
                                    sel = Tank.Tu2;
                                    break;
                                case 3:
                                    sel = Tank.Tu3;
                                    break;
                                case 4:
                                    sel = Tank.Tu4;
                                    break;
                                case 5:
                                    sel = Tank.Tu5;
                                    break;
                                case 6:
                                    sel = Tank.Tu6;
                                    break;
                                default:
                                    sel = null;
                                    break;
                            }
                            switch (ItemSelect)
                            {
                                case 1:
                                    valve = sel.LH.ToString("f2");
                                    break;
                                case 2:
                                    valve = sel.LS.ToString("f2");
                                    break;
                                case 3:
                                    valve = sel.LG.ToString("f2");
                                    break;
                                case 4:
                                    valve = sel.HG.ToString("f2");
                                    break;
                                case 5:
                                    valve = sel.HS.ToString("f2");
                                    break;
                                case 6:
                                    valve = sel.SG.ToString("f2");
                                    break;
                            }
                            break;
                        case 1:
                            valve = "0.0";
                            break;
                    }

                }
                return valve;
            }
            public override led F2()
            {
                this.ItemSelect = 2;
                double valve = Convert.ToDouble(GetMeasurement(ItemSelect));
                if (valve > 1000)
                {
                    this.Measurement = "TEST OK";
                }
                else
                {
                    this.Measurement = valve.ToString("f2");
                }
                       
                return this;
            }

            public override led F3()
            {
                this.ItemSelect = 3;
                double valve = Convert.ToDouble(GetMeasurement(ItemSelect));
                if (valve > 1000)
                {
                    this.Measurement = "TEST OK";
                }
                else
                {
                    this.Measurement = valve.ToString("f2");
                }
                       
                return this;
            }

            public override led F4()
            {
                this.ItemSelect = 4;
                double valve = Convert.ToDouble(GetMeasurement(ItemSelect));
                if (valve > 1000)
                {
                    this.Measurement = "TEST OK";
                }
                else
                {
                    this.Measurement = valve.ToString("f2");
                }
                       
                return this;
            }
            public override led F5()
            {
       
                if (Page == 0)
                {
                    this.ItemSelect = 5;
                    double valve = Convert.ToDouble(GetMeasurement(ItemSelect));
                    if (valve > 1000)
                    {
                        this.Measurement = "TEST OK";
                    }
                    else
                    {
                        this.Measurement = valve.ToString("f2");
                    }
                       
                }
             
                return this;
            }

            public override led F6()
            {
                if (Page == 0)
                {
                    this.ItemSelect = 6;
                    double valve = Convert.ToDouble(GetMeasurement(ItemSelect));
                    if (valve > 1000)
                    {
                        this.Measurement = "TEST OK";
                    }
                    else
                    {
                        this.Measurement = valve.ToString("f2");
                    }
                       
                    return this;
                }
                else
                {
                    return new SelfTestScreen(this);
                }
              
            }
            public override led BtnMode()
            {
                if (this.Mode == "3T")
                {
                    this.Mode = "2T";
                }
                else
                {
                    this.Mode = "3T";
                }
                return this;
            }
            public override led BtnNext()
            {
                if (this.Page == 1)
                {
                    this.F1_text = "L/H";
                    this.F2_text = "L/S";
                    this.F3_text = "L/G";
                    this.F4_text = "H/G";
                    this.F5_text = "H/S";
                    this.F6_text = "S/G";
                    this.Page = 0;
                }
                else
                {
                    this.F1_text = "L/C";
                    this.F2_text = "C/H";
                    this.F3_text = "C/S";
                    this.F4_text = "C/G";
                    this.F5_text = "";
                    this.F6_text = "STEST";
                    this.Page = 1;
                }
                return this;
            }
            public override led BtnBack()
            {

                return new Fuel.MainMenu();
            }
            public override led BtnRange()
            {

                if (this.RangeID != 4)
                {
                    this.RangeID += 1;
                }
                else
                {
                    this.RangeID = 0;
                }
                switch (this.RangeID)
                {
                    case 0:
                        this.Range = "40";
                        this.Unit = "MΩ";
                        break;
                    case 1:
                       this.Range = "400";
                        this.Unit = "MΩ";
                        break;
                    case 2:
                           this.Range = "4000";
                        this.Unit = "MΩ";
                        break;
                    case 3:
                        this.Range = "20000";
                        this.Unit = "MΩ";
                        break;
                    case 4:
                        this.Range = "AUTO";
                        this.Unit = "";
                        break;
                  default:
                        this.Range = "AUTO";
                        this.Unit = "";
                        break;

                }
                return this;
 
            }

        }
        public class MeasureCapacitance : led
        {
           // private Fuel.Tank tankCurrent = new Tank();
            public MeasureCapacitance()
            {
               // tankCurrent = tank;
                this.F1_text = "TANK";
                this.F2_text = "COMP";
                this.F3_text = "DTF";
                this.F4_text = "";
                this.F5_text = "ZERO";
                this.F6_text = "ST";
                this.Function = "MEASURE CAPACITANCE";
                this.Instruction = "";              
                this.Mode = "";
                this.Range = "4,000";
                this.Shownext = true;
                this.Unit = "pF";
                this.F1();
                this.Shownext = false;
            }
            public override led F1()
            {

                this.ItemSelect = 1;
                if (Routing.Bus == 0)
                {
                    this.Measurement = Tank.TankAll.Capacitance.ToString("f2");
                }
                else
                {
                    switch (Routing.Knob)
                    {
                        case 0:
                            this.Measurement = Tank.Comp.Capacitance.ToString("f2");
                            break;
                            case 1:
                            this.Measurement = Tank.Tu1.Capacitance.ToString("f2");
                            break;
                            case 2:
                            this.Measurement = Tank.Tu2.Capacitance.ToString("f2");
                            break;
                            case 3:
                            this.Measurement = Tank.Tu3.Capacitance.ToString("f2");
                            break;
                            case 4:
                            this.Measurement = Tank.Tu4.Capacitance.ToString("f2");
                            break;
                            case 5:
                            this.Measurement = Tank.Tu5.Capacitance.ToString("f2");
                            break;
                            case 6:
                            this.Measurement = Tank.Tu6.Capacitance.ToString("f2");
                            break;
                            default:
                            break;

                    }
                }
                return this;
            }
            public override led F2()
            {
                this.ItemSelect = 2;

                this.Measurement = Tank.Comp.Capacitance.ToString("f2");
          
                return this;
            }
            public override led F4()
            {
                return this;

            }
          
            public override led F6()
            {
                return new SelfTestScreen(this);
            }
            public override led BtnRange()
            {

                if (this.RangeID != 3)
                {
                    this.RangeID += 1;
                }
                else
                {
                    this.RangeID = 0;
                }
                switch (this.RangeID)
                {
                    case 0:
                        this.Range = "400";
                        break;
                    case 1:
                        this.Range = "4,000";
                        break;
                    case 2:
                        this.Range = "40,000";
                        break;
                    case 3:
                        this.Range = "AUTO";
                        this.Unit = "";
                        break;
                    default:
                        this.Range = "AUTO";
                        this.Unit = "";
                        break;

                }
                return this;

            }
            public override led BtnNext()
            {
                return this;
            }

            public override led BtnBack()
            {

                return new Fuel.MainMenu();
            }
        }

        public class SelfTestScreen : led
        {
            private Fuel.led upLed;
            public SelfTestScreen(Fuel.led rootLed)
            {
                upLed = rootLed;

                this.Function = "INSULATION SELF TEST";
                this.Instruction = "Press BACK to exit";
                this.Mode = "";
                this.Range = "";
                this.Measurement = "..PASS..";
                this.Shownext = false;
                this.Unit = "";    
            }
            public override led BtnBack()
            {
                return upLed;
            }
            public override led BtnMode()
            {
                return this;
            }
            public override led BtnNext()
            {
                return this;
            }
            public override led BtnRange()
            {
                return this;
            }
            public override led F1()
            {
                return this;
            }
            public override led F2()
            {
                return this;
            }
            public override led F3()
            {
                return this;
            }
            public override led F4()
            {
                return this;

            }
            public override led F5()
            {
                return this;
            }
            public override led F6()
            {
                return this;
            }
        }
        public class MeasureSimulation : led
        {
            public MeasureSimulation()
            {
                this.F1_text = "TANK";
                this.F2_text = "COMP";
                this.F3_text = "";
                this.F4_text = "";
                this.F5_text = "";
                this.F6_text = "CAL";
                this.Function = "MEASURE SIMULATION";
                this.Instruction = "Enter value between 10 & 10,000 pF";              
                this.Mode = "IN";
                this.Range = "10000";
                this.Shownext = true;
                this.Unit = "pF";
                this.F1();
                this.Shownext = false;
            }
            public override led BtnBack()
            {
                return new Fuel.MainMenu();
            }
            public override led BtnMode()
            {
                if (this.Mode == "IN")
                {
                    this.Mode = "OUT";
                }
                else
                {
                    this.Mode = "IN";
                }
                return this;
            }
            public override led BtnNext()
            {
                return this;
            }
            public override led BtnRange()
            {
                if (this.Range == "4000")
                {
                    this.Range = "10000";
                }
                else
                {
                    this.Range = "4000";
                }
                return this;
               
            }
            public override led F1()
            {
                this.ItemSelect = 1;              
                this.Instruction = "Enter value between 10 & 10,000 pF";
                this.Measurement = "";
                return this;
            }
            public override led F2()
            {
                this.ItemSelect = 2;
              this.Instruction = "Enter value between 10 & 10,000 pF";
                this.Measurement = "";
                return this;
            }
            public override led F3()
            {
                return this;
            }
            public override led F4()
            {
                return this;

            }
            public override led F5()
            {
                return new Fuel.Calibration();
            }
            public override led F6()
            {
                return new Fuel.Calibration();
            }
        }
        public class Calibration : led
        {
            public Calibration()
            {
                this.F1_text = "SIM";
                this.F2_text = "ACFT";
                this.F3_text = "A&S";
                this.F4_text = "";
                this.F5_text = "TANK";
                this.F6_text = "COMP";
                this.Function = "CALIBRATION";
                this.Instruction = "";
                this.Measurement = "4.123";
                this.Mode = "";
                this.Range = "40";
                this.Shownext = false;
                this.Unit = "VDC";
                this.F1();
            }
            public override led BtnBack()
            {
                return new Fuel.MainMenu();
            }

            public override led BtnMode()
            {
                if (this.Unit == "VDC")
                {
                    this.Unit = "μA";
                    this.Range = "1200";
                    this.Measurement = "1.183";
                }
                else
                {
                    this.Unit = "VDC";
                    this.Range = "40";
                    this.Measurement = "4.123";
                }
                return this;
            }
            public override led BtnNext()
            {
                return this;
            }
            public override led BtnRange()
            {
                return this;
            }
            public override led F1()
            {
                this.ItemSelect = 1;

                double quantity = 0.0;
                quantity = (Tank.SimTank - 303.5) / 113.2 * 42 / (Tank.SimCap - 39) * 10000;
                if (quantity < 0)
                {
                    Indicator.Valve = 0;
                }
                else
                {
                    Indicator.Valve = Convert.ToInt32 (quantity);
                }
                return this;
            }
            public override led F2()
            {
                this.ItemSelect = 2;
                Indicator.Valve = 0;
                return this;
            }
            public override led F3()
            {
                this.ItemSelect = 3;
                double quantity = 0.0;
                quantity = (Tank.SimTank - 303.5 + Tank.TankAll.Capacitance) / 113.2 * 42 / (Tank.SimCap - 39 + Tank.Comp.Capacitance) * 10000;
                if (quantity < 0)
                {
                    Indicator.Valve =0;
                }
                else
                {
                    Indicator.Valve = Convert.ToInt32(quantity);
                }
                return this;
            }
            public override led F4()
            {
                return this;

            }
            public override led F5()
            {
                
               return new Fuel.MeasureSimulation().F1();
            }
            public override led F6()
            {
               
                return  new Fuel.MeasureSimulation().F2();
            }
        }
    }
}
