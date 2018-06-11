using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Research.Oslo;

namespace lab1_2
{
    class RungeKuttaMethod
    {
        private EquationParameters parameters;

        public RungeKuttaMethod(EquationParameters param)
        {
            parameters = param;
        }

        public SolPoint[] Count1()
        {
            var sol = Ode.RK547M(0, new Vector(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
                (t, x) => new Vector(
                    -(parameters.LambdaAZ1 + parameters.LambdaPZ1 + parameters.LambdaAZ3 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[0],
                    -(parameters.LambdaAZ1 + parameters.LambdaPZ1 + parameters.LambdaAZ3 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[1] + parameters.LambdaAZ2 * x[0],
                    -(parameters.LambdaAZ1 + parameters.LambdaPZ1 + parameters.LambdaAZ2 + parameters.LambdaAZ3 + parameters.LambdaPZ3 + parameters.LambdaAZ5) * x[2] + parameters.LambdaAZ4 * x[0],
                    -(parameters.LambdaAZ1 + parameters.LambdaPZ1 + parameters.LambdaAZ2 + parameters.LambdaAZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[3] + parameters.LambdaPZ3 * x[0],
                    -(parameters.LambdaAZ1 + parameters.LambdaPZ1 + parameters.LambdaAZ2 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[4] + parameters.LambdaAZ3 * x[3],
                    -(parameters.LambdaPZ1 + parameters.LambdaAZ2 + parameters.LambdaAZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[5] + parameters.LambdaAZ1 * x[3],
                    -(parameters.LambdaPZ1 + parameters.LambdaAZ2 + parameters.LambdaAZ3 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[6] + parameters.LambdaAZ1 * x[0],
                    -(parameters.LambdaAZ2 + parameters.LambdaAZ3 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[7] + parameters.LambdaPZ1 * x[6],
                    -(parameters.LambdaPZ1 + parameters.LambdaAZ2 + parameters.LambdaAZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[8] + parameters.LambdaPZ3 * x[6],
                    -(parameters.LambdaAZ1 + parameters.LambdaAZ2 + parameters.LambdaAZ3 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[9] + parameters.LambdaPZ1 * x[0],
                    -(parameters.LambdaAZ2 + parameters.LambdaAZ3 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[10] + parameters.LambdaAZ1 * x[9],
                    -(parameters.LambdaAZ1 + parameters.LambdaAZ2 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[11] + parameters.LambdaAZ3 * x[9],
                    -(parameters.LambdaAZ1 + parameters.LambdaPZ1 + parameters.LambdaAZ2 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[12] + parameters.LambdaAZ3 * x[0],
                    -(parameters.LambdaAZ1 + parameters.LambdaAZ2 + parameters.LambdaPZ3 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[13] + parameters.LambdaPZ1 * x[12],
                    -(parameters.LambdaAZ1 + parameters.LambdaPZ1 + parameters.LambdaAZ2 + parameters.LambdaAZ4 + parameters.LambdaAZ5) * x[14] + parameters.LambdaPZ3 * x[12]

                ));

            return sol.SolveFromToStep(0, parameters.MaxTime, parameters.Step).ToArray();
        }


        public SolPoint[] Count2()
        {
            var sol = Ode.RK547M(0, new Vector(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1),
                (t, x) => new Vector(
                    -(parameters.LambdaAZ1+parameters.LambdaPZ1+parameters.LambdaAZ3+parameters.LambdaAZ2+parameters.LambdaAZ4+parameters.LambdaAZ5)*x[0]+parameters.MuAZ1*x[1]+parameters.MuPZ1*x[2]+parameters.MuAZ2*x[3]+parameters.MuAZ3*x[4]+parameters.MuPZ3*x[5]+parameters.MuAZ4*x[6]+parameters.MuAZ5*x[6],
                    -(parameters.LambdaPZ1+parameters.LambdaAZ2+parameters.MuAZ1)*x[1]+parameters.MuPZ1*x[8]+parameters.MuAZ1*x[9]+parameters.LambdaAZ5*x[6],
                    -(parameters.LambdaAZ1+parameters.LambdaAZ2+parameters.MuPZ1)*x[2]+parameters.MuAZ1*x[7]+parameters.MuAZ2*x[9]+parameters.LambdaPZ1*x[0],
                    -parameters.MuAZ2*x[3]+parameters.LambdaAZ2*x[0],
                    -(parameters.LambdaPZ3+parameters.LambdaAZ3+parameters.MuAZ3)*x[4]+parameters.MuPZ3*x[11]+parameters.MuAZ4*x[17]+parameters.LambdaAZ3*x[0],
                    -(parameters.LambdaAZ3+parameters.LambdaAZ4+parameters.MuPZ3)*x[5]+parameters.MuAZ3*x[11]+parameters.MuAZ4*x[18]+parameters.LambdaPZ3*x[0],
                    -parameters.MuAZ4*x[6]+parameters.LambdaAZ4*x[0],
                    -parameters.MuAZ5*x[7]+parameters.LambdaAZ5*x[0],
                    -(parameters.LambdaAZ3+parameters.LambdaPZ3+parameters.MuPZ1+parameters.MuAZ1)*x[7]+parameters.MuAZ3*x[12]+parameters.MuPZ3*x[13]+parameters.LambdaPZ1*x[1]+parameters.LambdaAZ1*x[2],
                    -parameters.MuAZ2*x[9]+parameters.LambdaAZ2*x[1],
                    -parameters.MuAZ2*x[10]+parameters.LambdaAZ2*x[2],
                    -(parameters.LambdaAZ1+parameters.LambdaPZ1+parameters.MuPZ3+parameters.MuAZ3)*x[11]+parameters.MuAZ1*x[14]+parameters.MuPZ1*x[15]+parameters.LambdaPZ3*x[4]+parameters.LambdaAZ3*x[5],
                    -(parameters.LambdaPZ3+parameters.MuAZ3)*x[12]+parameters.MuPZ3*x[16]+parameters.LambdaAZ3*x[8],
                    -(parameters.LambdaAZ3+parameters.MuPZ3)*x[13]+parameters.MuAZ3*x[16]+parameters.LambdaPZ3*x[8],
                    -(parameters.LambdaPZ1+parameters.MuAZ1)*x[14]+parameters.MuPZ1*x[16]+parameters.LambdaAZ1*x[14],
                    -(parameters.LambdaAZ1+parameters.MuPZ1)*x[15]+parameters.MuAZ1*x[16]+parameters.LambdaPZ1*x[11],
                    -(parameters.MuAZ3+parameters.MuPZ3+parameters.MuPZ1+parameters.MuAZ1)*x[16]+parameters.LambdaAZ3*x[13]+parameters.LambdaPZ3*x[12]+parameters.LambdaPZ1*x[14]+parameters.LambdaAZ1*x[15],
                    -parameters.MuAZ4*x[17]+parameters.LambdaAZ4*x[4],
                    -parameters.MuAZ4*x[18]+parameters.LambdaAZ4*x[5]
                        
                ));

            return sol.SolveFromToStep(0, parameters.MaxTime, parameters.Step).ToArray();
        }
    }
}
