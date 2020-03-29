using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmadaCollector
{
    class Bot
    {
        public static void Log(string message)
        {
            try
            {
                Form1.form1.Invoke(Form1.form1.writer, new string[]
                {
                    message
                });
            }
            catch (Exception)
            {
            }
        }

        public static void ExecuteJavaScript()
        {
            try
            {
                Form1.form1.Invoke(Form1.form1.scriptrunner, new object[]
                {

                });
            }
            catch (Exception)
            {
            }
        }
    }

    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
