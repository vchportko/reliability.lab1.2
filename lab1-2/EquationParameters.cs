using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_2
{
    public class EquationParameters
    {
        public double LambdaAZ1 { get; set; } = 0.0005d;
        public double LambdaPZ1 { get; set; } = 0.0005d;
        public double LambdaAZ2 { get; set; } = 0.0004d;
        public double LambdaAZ3 { get; set; } = 0.0003d;
        public double LambdaPZ3 { get; set; } = 0.0003d;
        public double LambdaAZ4 { get; set; } = 0.0025d;
        public double LambdaAZ5 { get; set; } = 0.0005d;

        public double MuAZ1 { get; set; } = 0.0025d;
        public double MuPZ1 { get; set; } = 0.0003d;
        public double MuAZ2 { get; set; } = 0.0005d;
        public double MuAZ3 { get; set; } = 0.0004d;
        public double MuPZ3 { get; set; } = 0.0005d;
        public double MuAZ4 { get; set; } = 0.0004d;
        public double MuAZ5 { get; set; } = 0.0005d;

        public double Step { get; set; } = 1;
        public double MaxTime { get; set; } = 1000;
        public double Result { get; set; }
    }
}
