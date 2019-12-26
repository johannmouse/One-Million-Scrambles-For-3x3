using FridrichAlgorithm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using txnqd;

namespace _100000Scrambles
{
    class Program
    {
        static readonly QuangVinh Vinh = new QuangVinh();
        static readonly Solver VinhButCooler = new Solver();
        public enum Colors { red, orange, white, yellow, green, blue }
        static Colors[] myCube = new Colors[54];
        static readonly List<string> lstMerged = new List<string>();
        public static void Main()
        {
            string ScrambleFile = "C:/Users/tqvinh/Desktop/1MillionScrambles.txt";
            string FridrichFile = "C:/Users/tqvinh/Desktop/1MillionFridrich.txt";
            string KociembaFile = "C:/Users/tqvinh/Desktop/1MillionKociemba.txt";
            StringBuilder states = new StringBuilder();
            StringBuilder solutions = new StringBuilder();
            StringBuilder fasterSolutions = new StringBuilder();
            using (StreamWriter sw1 = File.CreateText(ScrambleFile))
            {
                using (StreamWriter sw2 = File.CreateText(FridrichFile))
                {
                    using (StreamWriter sw3 = File.CreateText(KociembaFile))
                    {
                        for (int i = 1; i <= 100000; i++)
                        {
                            string scramble = RandomScrambleGenerator();

                            states.Append(scramble + "\n");
                            solutions.Append(Vinh.Solve(GetStatusFromScramble(scramble.Replace(" ", ""))) + "\n");
                            fasterSolutions.Append(VinhButCooler.OneLineSolve(GetStatusFromScramble(scramble.Replace(" ", ""))) + "\n");
                        }
                        sw1.Write(states);
                        sw2.Write(solutions);
                        sw3.Write(fasterSolutions);
                    }
                }
            }
            Console.WriteLine("Success");
            Console.ReadKey();
        }
        public static void DoR(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[8];
            Colors temp2 = myCube[5];
            Colors temp3 = myCube[2];
            myCube[8] = myCube[17];
            myCube[17] = myCube[53];
            myCube[53] = myCube[27];
            myCube[27] = temp1;
            myCube[5] = myCube[14];
            myCube[14] = myCube[50];
            myCube[50] = myCube[30];
            myCube[30] = temp2;
            myCube[2] = myCube[11];
            myCube[11] = myCube[47];
            myCube[47] = myCube[33];
            myCube[33] = temp3;
            //face
            temp1 = myCube[18];
            temp2 = myCube[19];
            myCube[18] = myCube[24];
            myCube[24] = myCube[26];
            myCube[26] = myCube[20];
            myCube[20] = temp1;
            myCube[19] = myCube[21];
            myCube[21] = myCube[25];
            myCube[25] = myCube[23];
            myCube[23] = temp2;
        }
        public static void DoU(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[9];
            Colors temp2 = myCube[10];
            Colors temp3 = myCube[11];
            myCube[9] = myCube[18];
            myCube[18] = myCube[27];
            myCube[27] = myCube[36];
            myCube[36] = temp1;
            myCube[10] = myCube[19];
            myCube[19] = myCube[28];
            myCube[28] = myCube[37];
            myCube[37] = temp2;
            myCube[11] = myCube[20];
            myCube[20] = myCube[29];
            myCube[29] = myCube[38];
            myCube[38] = temp3;
            //face
            temp1 = myCube[0];
            temp2 = myCube[1];
            myCube[0] = myCube[6];
            myCube[6] = myCube[8];
            myCube[8] = myCube[2];
            myCube[2] = temp1;
            myCube[1] = myCube[3];
            myCube[3] = myCube[7];
            myCube[7] = myCube[5];
            myCube[5] = temp2;

        }
        public static void DoF(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[6];
            Colors temp2 = myCube[7];
            Colors temp3 = myCube[8];
            myCube[6] = myCube[44];
            myCube[44] = myCube[47];
            myCube[47] = myCube[18];
            myCube[18] = temp1;
            myCube[7] = myCube[41];
            myCube[41] = myCube[46];
            myCube[46] = myCube[21];
            myCube[21] = temp2;
            myCube[8] = myCube[38];
            myCube[38] = myCube[45];
            myCube[45] = myCube[24];
            myCube[24] = temp3;
            //face
            temp1 = myCube[9];
            temp2 = myCube[10];
            myCube[9] = myCube[15];
            myCube[15] = myCube[17];
            myCube[17] = myCube[11];
            myCube[11] = temp1;
            myCube[10] = myCube[12];
            myCube[12] = myCube[16];
            myCube[16] = myCube[14];
            myCube[14] = temp2;
        }
        public static void DoL(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[6];
            Colors temp2 = myCube[3];
            Colors temp3 = myCube[0];
            myCube[6] = myCube[29];
            myCube[29] = myCube[51];
            myCube[51] = myCube[15];
            myCube[15] = temp1;
            myCube[3] = myCube[32];
            myCube[32] = myCube[48];
            myCube[48] = myCube[12];
            myCube[12] = temp2;
            myCube[0] = myCube[35];
            myCube[35] = myCube[45];
            myCube[45] = myCube[9];
            myCube[9] = temp3;
            //face
            temp1 = myCube[36];
            temp2 = myCube[37];
            myCube[36] = myCube[42];
            myCube[42] = myCube[44];
            myCube[44] = myCube[38];
            myCube[38] = temp1;
            myCube[37] = myCube[39];
            myCube[39] = myCube[43];
            myCube[43] = myCube[41];
            myCube[41] = temp2;
        }
        public static void DoB(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[0];
            Colors temp2 = myCube[1];
            Colors temp3 = myCube[2];
            myCube[0] = myCube[20];
            myCube[20] = myCube[53];
            myCube[53] = myCube[42];
            myCube[42] = temp1;
            myCube[1] = myCube[23];
            myCube[23] = myCube[52];
            myCube[52] = myCube[39];
            myCube[39] = temp2;
            myCube[2] = myCube[26];
            myCube[26] = myCube[51];
            myCube[51] = myCube[36];
            myCube[36] = temp3;
            //face
            temp1 = myCube[27];
            temp2 = myCube[28];
            myCube[27] = myCube[33];
            myCube[33] = myCube[35];
            myCube[35] = myCube[29];
            myCube[29] = temp1;
            myCube[28] = myCube[30];
            myCube[30] = myCube[34];
            myCube[34] = myCube[32];
            myCube[32] = temp2;
        }
        public static void DoD(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[15];
            Colors temp2 = myCube[16];
            Colors temp3 = myCube[17];
            myCube[15] = myCube[42];
            myCube[42] = myCube[33];
            myCube[33] = myCube[24];
            myCube[24] = temp1;
            myCube[16] = myCube[43];
            myCube[43] = myCube[34];
            myCube[34] = myCube[25];
            myCube[25] = temp2;
            myCube[17] = myCube[44];
            myCube[44] = myCube[35];
            myCube[35] = myCube[26];
            myCube[26] = temp3;
            //face
            temp1 = myCube[45];
            temp2 = myCube[46];
            myCube[45] = myCube[51];
            myCube[51] = myCube[53];
            myCube[53] = myCube[47];
            myCube[47] = temp1;
            myCube[46] = myCube[48];
            myCube[48] = myCube[52];
            myCube[52] = myCube[50];
            myCube[50] = temp2;
        }
        public static void DoRPrime(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[8];
            Colors temp2 = myCube[5];
            Colors temp3 = myCube[2];
            myCube[8] = myCube[27];
            myCube[27] = myCube[53];
            myCube[53] = myCube[17];
            myCube[17] = temp1;
            myCube[5] = myCube[30];
            myCube[30] = myCube[50];
            myCube[50] = myCube[14];
            myCube[14] = temp2;
            myCube[2] = myCube[33];
            myCube[33] = myCube[47];
            myCube[47] = myCube[11];
            myCube[11] = temp3;
            //face
            temp1 = myCube[18];
            temp2 = myCube[19];
            myCube[18] = myCube[20];
            myCube[20] = myCube[26];
            myCube[26] = myCube[24];
            myCube[24] = temp1;
            myCube[19] = myCube[23];
            myCube[23] = myCube[25];
            myCube[25] = myCube[21];
            myCube[21] = temp2;
        }
        public static void DoUPrime(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[9];
            Colors temp2 = myCube[10];
            Colors temp3 = myCube[11];
            myCube[9] = myCube[36];
            myCube[36] = myCube[27];
            myCube[27] = myCube[18];
            myCube[18] = temp1;
            myCube[10] = myCube[37];
            myCube[37] = myCube[28];
            myCube[28] = myCube[19];
            myCube[19] = temp2;
            myCube[11] = myCube[38];
            myCube[38] = myCube[29];
            myCube[29] = myCube[20];
            myCube[20] = temp3;
            //face
            temp1 = myCube[0];
            temp2 = myCube[1];
            myCube[0] = myCube[2];
            myCube[2] = myCube[8];
            myCube[8] = myCube[6];
            myCube[6] = temp1;
            myCube[1] = myCube[5];
            myCube[5] = myCube[7];
            myCube[7] = myCube[3];
            myCube[3] = temp2;
        }
        public static void DoFPrime(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[6];
            Colors temp2 = myCube[7];
            Colors temp3 = myCube[8];
            myCube[6] = myCube[18];
            myCube[18] = myCube[47];
            myCube[47] = myCube[44];
            myCube[44] = temp1;
            myCube[7] = myCube[21];
            myCube[21] = myCube[46];
            myCube[46] = myCube[41];
            myCube[41] = temp2;
            myCube[8] = myCube[24];
            myCube[24] = myCube[45];
            myCube[45] = myCube[38];
            myCube[38] = temp3;
            //face
            temp1 = myCube[9];
            temp2 = myCube[10];
            myCube[9] = myCube[11];
            myCube[11] = myCube[17];
            myCube[17] = myCube[15];
            myCube[15] = temp1;
            myCube[10] = myCube[14];
            myCube[14] = myCube[16];
            myCube[16] = myCube[12];
            myCube[12] = temp2;
        }
        public static void DoLPrime(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[6];
            Colors temp2 = myCube[3];
            Colors temp3 = myCube[0];
            myCube[6] = myCube[15];
            myCube[15] = myCube[51];
            myCube[51] = myCube[29];
            myCube[29] = temp1;
            myCube[3] = myCube[12];
            myCube[12] = myCube[48];
            myCube[48] = myCube[32];
            myCube[32] = temp2;
            myCube[0] = myCube[9];
            myCube[9] = myCube[45];
            myCube[45] = myCube[35];
            myCube[35] = temp3;
            //face
            temp1 = myCube[36];
            temp2 = myCube[37];
            myCube[36] = myCube[38];
            myCube[38] = myCube[44];
            myCube[44] = myCube[42];
            myCube[42] = temp1;
            myCube[37] = myCube[41];
            myCube[41] = myCube[43];
            myCube[43] = myCube[39];
            myCube[39] = temp2;
        }
        public static void DoBPrime(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[0];
            Colors temp2 = myCube[1];
            Colors temp3 = myCube[2];
            myCube[0] = myCube[42];
            myCube[42] = myCube[53];
            myCube[53] = myCube[20];
            myCube[20] = temp1;
            myCube[1] = myCube[39];
            myCube[39] = myCube[52];
            myCube[52] = myCube[23];
            myCube[23] = temp2;
            myCube[2] = myCube[36];
            myCube[36] = myCube[51];
            myCube[51] = myCube[26];
            myCube[26] = temp3;
            //face
            temp1 = myCube[27];
            temp2 = myCube[28];
            myCube[27] = myCube[29];
            myCube[29] = myCube[35];
            myCube[35] = myCube[33];
            myCube[33] = temp1;
            myCube[28] = myCube[32];
            myCube[32] = myCube[34];
            myCube[34] = myCube[30];
            myCube[30] = temp2;
        }
        public static void DoDPrime(ref Colors[] myCube)
        {
            //side
            Colors temp1 = myCube[15];
            Colors temp2 = myCube[16];
            Colors temp3 = myCube[17];
            myCube[15] = myCube[24];
            myCube[24] = myCube[33];
            myCube[33] = myCube[42];
            myCube[42] = temp1;
            myCube[16] = myCube[25];
            myCube[25] = myCube[34];
            myCube[34] = myCube[43];
            myCube[43] = temp2;
            myCube[17] = myCube[26];
            myCube[26] = myCube[35];
            myCube[35] = myCube[44];
            myCube[44] = temp3;
            //face
            temp1 = myCube[45];
            temp2 = myCube[46];
            myCube[45] = myCube[47];
            myCube[47] = myCube[53];
            myCube[53] = myCube[51];
            myCube[51] = temp1;
            myCube[46] = myCube[50];
            myCube[50] = myCube[52];
            myCube[52] = myCube[48];
            myCube[48] = temp2;
        }
        public static void DoF2(ref Colors[] myCube)
        {
            DoF(ref myCube);
            DoF(ref myCube);
        }
        public static void DoR2(ref Colors[] myCube)
        {
            DoR(ref myCube);
            DoR(ref myCube);
        }
        public static void DoU2(ref Colors[] myCube)
        {
            DoU(ref myCube);
            DoU(ref myCube);
        }
        public static void DoL2(ref Colors[] myCube)
        {
            DoL(ref myCube);
            DoL(ref myCube);
        }
        public static void DoD2(ref Colors[] myCube)
        {
            DoD(ref myCube);
            DoD(ref myCube);
        }
        public static void DoB2(ref Colors[] myCube)
        {
            DoB(ref myCube);
            DoB(ref myCube);
        }
        public static void DoY(ref Colors[] myCube)
        {
            DoU(ref myCube);
            DoDPrime(ref myCube);
            Colors temp1 = myCube[12];
            Colors temp2 = myCube[13];
            Colors temp3 = myCube[14];
            myCube[12] = myCube[21];
            myCube[21] = myCube[30];
            myCube[30] = myCube[39];
            myCube[39] = temp1;
            myCube[13] = myCube[22];
            myCube[22] = myCube[31];
            myCube[31] = myCube[40];
            myCube[40] = temp2;
            myCube[14] = myCube[23];
            myCube[23] = myCube[32];
            myCube[32] = myCube[41];
            myCube[41] = temp3;
        }
        public static void DoYPrime(ref Colors[] myCube)
        {
            DoUPrime(ref myCube);
            DoD(ref myCube);
            Colors temp1 = myCube[12];
            Colors temp2 = myCube[13];
            Colors temp3 = myCube[14];
            myCube[12] = myCube[39];
            myCube[39] = myCube[30];
            myCube[30] = myCube[21];
            myCube[21] = temp1;
            myCube[13] = myCube[40];
            myCube[40] = myCube[31];
            myCube[31] = myCube[22];
            myCube[22] = temp2;
            myCube[14] = myCube[41];
            myCube[41] = myCube[32];
            myCube[32] = myCube[23];
            myCube[23] = temp3;
        }
        public static void DoY2(ref Colors[] myCube)
        {
            DoY(ref myCube);
            DoY(ref myCube);
        }
        public static void Dor(ref Colors[] myCube)
        {
            DoR(ref myCube);
            Colors temp1 = myCube[1];
            Colors temp2 = myCube[4];
            Colors temp3 = myCube[7];
            myCube[1] = myCube[10];
            myCube[10] = myCube[46];
            myCube[46] = myCube[34];
            myCube[34] = temp1;
            myCube[4] = myCube[13];
            myCube[13] = myCube[49];
            myCube[49] = myCube[31];
            myCube[31] = temp2;
            myCube[7] = myCube[16];
            myCube[16] = myCube[52];
            myCube[52] = myCube[28];
            myCube[28] = temp3;
        }
        public static void Dor2(ref Colors[] myCube)
        {
            Dor(ref myCube);
            Dor(ref myCube);
        }
        public static void DorPrime(ref Colors[] myCube)
        {
            DoRPrime(ref myCube);
            Colors temp1 = myCube[1];
            Colors temp2 = myCube[4];
            Colors temp3 = myCube[7];
            myCube[1] = myCube[34];
            myCube[34] = myCube[46];
            myCube[46] = myCube[10];
            myCube[10] = temp1;
            myCube[4] = myCube[31];
            myCube[31] = myCube[49];
            myCube[49] = myCube[13];
            myCube[13] = temp2;
            myCube[7] = myCube[28];
            myCube[28] = myCube[52];
            myCube[52] = myCube[16];
            myCube[16] = temp3;
        }
        public static void Dof(ref Colors[] myCube)
        {
            DoF(ref myCube);
            Colors temp1 = myCube[3];
            Colors temp2 = myCube[4];
            Colors temp3 = myCube[5];
            myCube[3] = myCube[43];
            myCube[43] = myCube[50];
            myCube[50] = myCube[19];
            myCube[19] = temp1;
            myCube[4] = myCube[40];
            myCube[40] = myCube[49];
            myCube[49] = myCube[22];
            myCube[22] = temp2;
            myCube[5] = myCube[37];
            myCube[37] = myCube[48];
            myCube[48] = myCube[25];
            myCube[25] = temp3;
        }
        public static void DofPrime(ref Colors[] myCube)
        {
            DoFPrime(ref myCube);
            Colors temp1 = myCube[3];
            Colors temp2 = myCube[4];
            Colors temp3 = myCube[5];
            myCube[3] = myCube[19];
            myCube[19] = myCube[50];
            myCube[50] = myCube[43];
            myCube[43] = temp1;
            myCube[4] = myCube[22];
            myCube[22] = myCube[49];
            myCube[49] = myCube[40];
            myCube[40] = temp2;
            myCube[5] = myCube[25];
            myCube[25] = myCube[48];
            myCube[48] = myCube[37];
            myCube[37] = temp3;
        }
        public static void Dof2(ref Colors[] myCube)
        {
            Dof(ref myCube);
            Dof(ref myCube);
        }
        public static void DoM2(ref Colors[] myCube)
        {
            Swap(ref myCube[1], ref myCube[46]);
            Swap(ref myCube[4], ref myCube[49]);
            Swap(ref myCube[7], ref myCube[52]);
            Swap(ref myCube[10], ref myCube[34]);
            Swap(ref myCube[13], ref myCube[31]);
            Swap(ref myCube[16], ref myCube[28]);

        }
        public static void DoX(ref Colors[] myCube)
        {
            DoR(ref myCube);
            DoLPrime(ref myCube);
            Colors temp1 = myCube[1];
            Colors temp2 = myCube[4];
            Colors temp3 = myCube[7];
            myCube[1] = myCube[10];
            myCube[10] = myCube[46];
            myCube[46] = myCube[34];
            myCube[34] = temp1;
            myCube[4] = myCube[13];
            myCube[13] = myCube[49];
            myCube[49] = myCube[31];
            myCube[31] = temp2;
            myCube[7] = myCube[16];
            myCube[16] = myCube[52];
            myCube[52] = myCube[28];
            myCube[28] = temp3;
        }
        public static void DoXPrime(ref Colors[] myCube)
        {
            DoRPrime(ref myCube);
            DoL(ref myCube);
            Colors temp1 = myCube[1];
            Colors temp2 = myCube[4];
            Colors temp3 = myCube[7];
            myCube[1] = myCube[34];
            myCube[34] = myCube[46];
            myCube[46] = myCube[10];
            myCube[10] = temp1;
            myCube[4] = myCube[31];
            myCube[31] = myCube[49];
            myCube[49] = myCube[13];
            myCube[13] = temp2;
            myCube[7] = myCube[28];
            myCube[28] = myCube[52];
            myCube[52] = myCube[16];
            myCube[16] = temp3;
        }
        public static void DoX2(ref Colors[] myCube)
        {
            DoX(ref myCube);
            DoX(ref myCube);
        }
        public static void DoZ(ref Colors[] myCube)
        {
            DoF(ref myCube);
            DoBPrime(ref myCube);
            Colors temp1 = myCube[3];
            Colors temp2 = myCube[4];
            Colors temp3 = myCube[5];
            myCube[3] = myCube[43];
            myCube[43] = myCube[50];
            myCube[50] = myCube[19];
            myCube[19] = temp1;
            myCube[4] = myCube[40];
            myCube[40] = myCube[49];
            myCube[49] = myCube[22];
            myCube[22] = temp2;
            myCube[5] = myCube[37];
            myCube[37] = myCube[48];
            myCube[48] = myCube[25];
            myCube[25] = temp3;
        }
        public static void DoZPrime(ref Colors[] myCube)
        {
            DoFPrime(ref myCube);
            DoB(ref myCube);
            Colors temp1 = myCube[3];
            Colors temp2 = myCube[4];
            Colors temp3 = myCube[5];
            myCube[3] = myCube[19];
            myCube[19] = myCube[50];
            myCube[50] = myCube[43];
            myCube[43] = temp1;
            myCube[4] = myCube[22];
            myCube[22] = myCube[49];
            myCube[49] = myCube[40];
            myCube[40] = temp2;
            myCube[5] = myCube[25];
            myCube[25] = myCube[48];
            myCube[48] = myCube[37];
            myCube[37] = temp3;
        }
        public static void DoZ2(ref Colors[] myCube)
        {
            DoZ(ref myCube);
            DoZ(ref myCube);
        }
        public static void Swap(ref Colors a, ref Colors b)
        {
            Colors temp = a;
            a = b;
            b = temp;
        }
        public static void Execute(string moves, ref Colors[] myCube)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'R':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("R'");
                                DoRPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("R2");
                                DoR2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("R");
                                DoR(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("R");
                            DoR(ref myCube);
                        }
                        break;
                    case 'L':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("L'");
                                DoLPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("L2");
                                DoL2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("L");
                                DoL(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("L");
                            DoL(ref myCube);
                        }
                        break;
                    case 'U':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("U'");
                                DoUPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("U2");
                                DoU2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("U");
                                DoU(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("U");
                            DoU(ref myCube);
                        }
                        break;
                    case 'F':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("F'");
                                DoFPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("F2");
                                DoF2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("F");
                                DoF(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("F");
                            DoF(ref myCube);
                        }
                        break;
                    case 'B':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("B'");
                                DoBPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("B2");
                                DoB2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("B");
                                DoB(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("B");
                            DoB(ref myCube);
                        }
                        break;
                    case 'D':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("D'");
                                DoDPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("D2");
                                DoD2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("D");
                                DoD(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("D");
                            DoD(ref myCube);
                        }
                        break;
                    case 'y':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("y'");
                                DoYPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("y2");
                                DoY2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("y");
                                DoY(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("y");
                            DoY(ref myCube);
                        }
                        break;
                    case 'r':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("r'");
                                DorPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("r2");
                                Dor2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("r");
                                Dor(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("r");
                            Dor(ref myCube);
                        }
                        break;
                    case 'f':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("f'");
                                DofPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("f2");
                                Dof2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("f");
                                Dof(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("f");
                            Dof(ref myCube);
                        }
                        break;
                    case 'M':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                //DofMrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("M2");
                                DoM2(ref myCube);
                                i++;
                            }
                            else
                            {
                                //DoM(ref myCube);
                            }
                        }
                        else
                        {
                            //DoM(ref myCube);
                        }
                        break;
                    case 'x':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("x'");
                                DoXPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("x2");
                                DoX2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("x");
                                DoX(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("x");
                            DoX(ref myCube);
                        }
                        break;
                    case 'z':
                        if (i != moves.Length - 1)
                        {
                            if (moves[i + 1] == '\'')
                            {
                                lstMerged.Add("z'");
                                DoZPrime(ref myCube);
                                i++;
                            }
                            else if (moves[i + 1] == '2')
                            {
                                lstMerged.Add("z2");
                                DoZ2(ref myCube);
                                i++;
                            }
                            else
                            {
                                lstMerged.Add("z");
                                DoZ(ref myCube);
                            }
                        }
                        else
                        {
                            lstMerged.Add("z");
                            DoZ(ref myCube);
                        }
                        break;
                }
            }
        }
        public static void InitializeCube()
        {
            for (int i = 0; i < 54; i++)
            {
                if (i <= 8) myCube[i] = Colors.white;
                else if (i <= 17) myCube[i] = Colors.green;
                else if (i <= 26) myCube[i] = Colors.red;
                else if (i <= 35) myCube[i] = Colors.blue;
                else if (i <= 44) myCube[i] = Colors.orange;
                else myCube[i] = Colors.yellow;
            }
        }
        public static string OptimizedSteps()
        {
            for (int i = 0; i < lstMerged.Count - 1; i++)
            {
                if (lstMerged[i] == "R")
                {
                    if (lstMerged[i + 1] == "R")
                    {
                        lstMerged[i] = "R2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "R'")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "R2")
                    {
                        lstMerged[i] = "R'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "L" || lstMerged[i + 1] == "L'" || lstMerged[i + 1] == "L2"))
                    {
                        if (lstMerged[i + 2]=="R")
                        {
                            lstMerged[i] = "R2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "R'")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "R2")
                        {
                            lstMerged[i] = "R'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "R'")
                {
                    if (lstMerged[i + 1] == "R'")
                    {
                        lstMerged[i] = "R2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "R")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "R2")
                    {
                        lstMerged[i] = "R";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "L" || lstMerged[i + 1] == "L'" || lstMerged[i + 1] == "L2"))
                    {
                        if (lstMerged[i + 2] == "R'")
                        {
                            lstMerged[i] = "R2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "R")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "R2")
                        {
                            lstMerged[i] = "R";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "R2")
                {
                    if (lstMerged[i + 1] == "R'")
                    {
                        lstMerged[i] = "R";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "R2")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "R")
                    {
                        lstMerged[i] = "R'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "L" || lstMerged[i + 1] == "L'" || lstMerged[i + 1] == "L2"))
                    {
                        if (lstMerged[i + 2] == "R'")
                        {
                            lstMerged[i] = "R";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "R2")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "R")
                        {
                            lstMerged[i] = "R'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "U")
                {
                    if (lstMerged[i + 1] == "U")
                    {
                        lstMerged[i] = "U2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "U'")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "U2")
                    {
                        lstMerged[i] = "U'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "D" || lstMerged[i + 1] == "D'" || lstMerged[i + 1] == "D2" || lstMerged[i + 1] == "y" || lstMerged[i + 1] == "y'" || lstMerged[i + 1] == "y2"))
                    {
                        if (lstMerged[i + 2] == "U")
                        {
                            lstMerged[i] = "U2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "U'")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "U2")
                        {
                            lstMerged[i] = "U'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "U'")
                {
                    if (lstMerged[i + 1] == "U'")
                    {
                        lstMerged[i] = "U2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "U")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "U2")
                    {
                        lstMerged[i] = "U";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "D" || lstMerged[i + 1] == "D'" || lstMerged[i + 1] == "D2" || lstMerged[i + 1] == "y" || lstMerged[i + 1] == "y'" || lstMerged[i + 1] == "y2"))
                    {
                        if (lstMerged[i + 2] == "U'")
                        {
                            lstMerged[i] = "U2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "U")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "U2")
                        {
                            lstMerged[i] = "U";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "U2")
                {
                    if (lstMerged[i + 1] == "U'")
                    {
                        lstMerged[i] = "U";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "U2")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "U")
                    {
                        lstMerged[i] = "U'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "D" || lstMerged[i + 1] == "D'" || lstMerged[i + 1] == "D2" || lstMerged[i + 1] == "y" || lstMerged[i + 1] == "y'" || lstMerged[i + 1] == "y2"))
                    {
                        if (lstMerged[i + 2] == "U'")
                        {
                            lstMerged[i] = "U";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "U2")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "U")
                        {
                            lstMerged[i] = "U'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "F")
                {
                    if (lstMerged[i + 1] == "F")
                    {
                        lstMerged[i] = "F2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "F'")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "F2")
                    {
                        lstMerged[i] = "F'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "B" || lstMerged[i + 1] == "B'" || lstMerged[i + 1] == "B2"))
                    {
                        if (lstMerged[i + 2] == "F")
                        {
                            lstMerged[i] = "F2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "F'")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "F2")
                        {
                            lstMerged[i] = "F'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "F'")
                {
                    if (lstMerged[i + 1] == "F'")
                    {
                        lstMerged[i] = "F2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "F")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "F2")
                    {
                        lstMerged[i] = "F";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "B" || lstMerged[i + 1] == "B'" || lstMerged[i + 1] == "B2"))
                    {
                        if (lstMerged[i + 2] == "F'")
                        {
                            lstMerged[i] = "F2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "F")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "F2")
                        {
                            lstMerged[i] = "F";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "F2")
                {
                    if (lstMerged[i + 1] == "F'")
                    {
                        lstMerged[i] = "F";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "F2")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "F")
                    {
                        lstMerged[i] = "F'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "B" || lstMerged[i + 1] == "B'" || lstMerged[i + 1] == "B2"))
                    {
                        if (lstMerged[i + 2] == "F'")
                        {
                            lstMerged[i] = "F";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "F2")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "F")
                        {
                            lstMerged[i] = "F'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "L")
                {
                    if (lstMerged[i + 1] == "L")
                    {
                        lstMerged[i] = "L2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "L'")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "L2")
                    {
                        lstMerged[i] = "L'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "R" || lstMerged[i + 1] == "R'" || lstMerged[i + 1] == "R2"))
                    {
                        if (lstMerged[i + 2] == "L")
                        {
                            lstMerged[i] = "L2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "L'")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "L2")
                        {
                            lstMerged[i] = "L'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "L'")
                {
                    if (lstMerged[i + 1] == "L'")
                    {
                        lstMerged[i] = "L2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "L")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "L2")
                    {
                        lstMerged[i] = "L";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "R" || lstMerged[i + 1] == "R'" || lstMerged[i + 1] == "R2"))
                    {
                        if (lstMerged[i + 2] == "L'")
                        {
                            lstMerged[i] = "L2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "L")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "L2")
                        {
                            lstMerged[i] = "L";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "L2")
                {
                    if (lstMerged[i + 1] == "L'")
                    {
                        lstMerged[i] = "L";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "L2")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "L")
                    {
                        lstMerged[i] = "L'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "R" || lstMerged[i + 1] == "R'" || lstMerged[i + 1] == "R2"))
                    {
                        if (lstMerged[i + 2] == "L'")
                        {
                            lstMerged[i] = "L";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "L2")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "L")
                        {
                            lstMerged[i] = "L'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "B")
                {
                    if (lstMerged[i + 1] == "B")
                    {
                        lstMerged[i] = "B2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "B'")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "B2")
                    {
                        lstMerged[i] = "B'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "F" || lstMerged[i + 1] == "F'" || lstMerged[i + 1] == "F2"))
                    {
                        if (lstMerged[i + 2] == "B")
                        {
                            lstMerged[i] = "B2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "B'")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "B2")
                        {
                            lstMerged[i] = "B'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "B'")
                {
                    if (lstMerged[i + 1] == "B'")
                    {
                        lstMerged[i] = "B2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "B")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "B2")
                    {
                        lstMerged[i] = "B";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "F" || lstMerged[i + 1] == "F'" || lstMerged[i + 1] == "F2"))
                    {
                        if (lstMerged[i + 2] == "B'")
                        {
                            lstMerged[i] = "B2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "B")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "B2")
                        {
                            lstMerged[i] = "B";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "B2")
                {
                    if (lstMerged[i + 1] == "B'")
                    {
                        lstMerged[i] = "B";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "B2")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "B")
                    {
                        lstMerged[i] = "B'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "F" || lstMerged[i + 1] == "F'" || lstMerged[i + 1] == "F2"))
                    {
                        if (lstMerged[i + 2] == "B'")
                        {
                            lstMerged[i] = "B";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "B2")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "B")
                        {
                            lstMerged[i] = "B'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "D")
                {
                    if (lstMerged[i + 1] == "D")
                    {
                        lstMerged[i] = "D2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "D'")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "D2")
                    {
                        lstMerged[i] = "D'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "U" || lstMerged[i + 1] == "U'" || lstMerged[i + 1] == "U2" || lstMerged[i + 1] == "y" || lstMerged[i + 1] == "y'" || lstMerged[i + 1] == "y2"))
                    {
                        if (lstMerged[i + 2] == "D")
                        {
                            lstMerged[i] = "D2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "D'")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "D2")
                        {
                            lstMerged[i] = "D'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "D'")
                {
                    if (lstMerged[i + 1] == "D'")
                    {
                        lstMerged[i] = "D2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "D")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "D2")
                    {
                        lstMerged[i] = "D";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "U" || lstMerged[i + 1] == "U'" || lstMerged[i + 1] == "U2" || lstMerged[i + 1] == "y" || lstMerged[i + 1] == "y'" || lstMerged[i + 1] == "y2"))
                    {
                        if (lstMerged[i + 2] == "D'")
                        {
                            lstMerged[i] = "D2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "D")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "D2")
                        {
                            lstMerged[i] = "D";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "D2")
                {
                    if (lstMerged[i + 1] == "D'")
                    {
                        lstMerged[i] = "D";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "D2")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "D")
                    {
                        lstMerged[i] = "D'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "U" || lstMerged[i + 1] == "U'" || lstMerged[i + 1] == "U2" || lstMerged[i + 1] == "y" || lstMerged[i + 1] == "y'" || lstMerged[i + 1] == "y2"))
                    {
                        if (lstMerged[i + 2] == "D'")
                        {
                            lstMerged[i] = "D";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "D2")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "D")
                        {
                            lstMerged[i] = "D'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "y")
                {
                    if (lstMerged[i + 1] == "y")
                    {
                        lstMerged[i] = "y2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "y'")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "y2")
                    {
                        lstMerged[i] = "y'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "U" || lstMerged[i + 1] == "U'" || lstMerged[i + 1] == "U2" || lstMerged[i + 1] == "D" || lstMerged[i + 1] == "D'" || lstMerged[i + 1] == "D2"))
                    {
                        if (lstMerged[i + 2] == "y")
                        {
                            lstMerged[i] = "y2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "y'")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "y2")
                        {
                            lstMerged[i] = "y'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "y'")
                {
                    if (lstMerged[i + 1] == "y'")
                    {
                        lstMerged[i] = "y2";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "y")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "y2")
                    {
                        lstMerged[i] = "y";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "U" || lstMerged[i + 1] == "U'" || lstMerged[i + 1] == "U2" || lstMerged[i + 1] == "D" || lstMerged[i + 1] == "D'" || lstMerged[i + 1] == "D2"))
                    {
                        if (lstMerged[i + 2] == "y'")
                        {
                            lstMerged[i] = "y2";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "y")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "y2")
                        {
                            lstMerged[i] = "y";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (lstMerged[i] == "y2")
                {
                    if (lstMerged[i + 1] == "y'")
                    {
                        lstMerged[i] = "y";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "y2")
                    {
                        lstMerged.RemoveAt(i + 1);
                        lstMerged.RemoveAt(i);
                        i = 0;
                    }
                    else if (lstMerged[i + 1] == "y")
                    {
                        lstMerged[i] = "y'";
                        lstMerged.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= lstMerged.Count - 3 && (lstMerged[i + 1] == "U" || lstMerged[i + 1] == "U'" || lstMerged[i + 1] == "U2" || lstMerged[i + 1] == "D" || lstMerged[i + 1] == "D'" || lstMerged[i + 1] == "D2"))
                    {
                        if (lstMerged[i + 2] == "y'")
                        {
                            lstMerged[i] = "y";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "y2")
                        {
                            lstMerged.RemoveAt(i + 2);
                            lstMerged.RemoveAt(i);
                            i = 0;
                        }
                        else if (lstMerged[i + 2] == "y")
                        {
                            lstMerged[i] = "y'";
                            lstMerged.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
            }
            string result = "";
            for (int i = 0; i < lstMerged.Count; i++)
            {
                result += lstMerged[i] + " ";
            }
            return result;
        }
        public static string OptimizedStepsRandom(ref List<string> myScramble)
        {
            for (int i = 0; i < myScramble.Count - 1; i++)
            {
                if (myScramble[i] == "R")
                {
                    if (myScramble[i + 1] == "R")
                    {
                        myScramble[i] = "R2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "R'")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "R2")
                    {
                        myScramble[i] = "R'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "L" || myScramble[i + 1] == "L'" || myScramble[i + 1] == "L2"))
                    {
                        if (myScramble[i + 2] == "R")
                        {
                            myScramble[i] = "R2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "R'")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "R2")
                        {
                            myScramble[i] = "R'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "R'")
                {
                    if (myScramble[i + 1] == "R'")
                    {
                        myScramble[i] = "R2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "R")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "R2")
                    {
                        myScramble[i] = "R";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "L" || myScramble[i + 1] == "L'" || myScramble[i + 1] == "L2"))
                    {
                        if (myScramble[i + 2] == "R'")
                        {
                            myScramble[i] = "R2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "R")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "R2")
                        {
                            myScramble[i] = "R";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "R2")
                {
                    if (myScramble[i + 1] == "R'")
                    {
                        myScramble[i] = "R";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "R2")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "R")
                    {
                        myScramble[i] = "R'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "L" || myScramble[i + 1] == "L'" || myScramble[i + 1] == "L2"))
                    {
                        if (myScramble[i + 2] == "R'")
                        {
                            myScramble[i] = "R";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "R2")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "R")
                        {
                            myScramble[i] = "R'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "U")
                {
                    if (myScramble[i + 1] == "U")
                    {
                        myScramble[i] = "U2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "U'")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "U2")
                    {
                        myScramble[i] = "U'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "D" || myScramble[i + 1] == "D'" || myScramble[i + 1] == "D2" || myScramble[i + 1] == "y" || myScramble[i + 1] == "y'" || myScramble[i + 1] == "y2"))
                    {
                        if (myScramble[i + 2] == "U")
                        {
                            myScramble[i] = "U2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "U'")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "U2")
                        {
                            myScramble[i] = "U'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "U'")
                {
                    if (myScramble[i + 1] == "U'")
                    {
                        myScramble[i] = "U2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "U")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "U2")
                    {
                        myScramble[i] = "U";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "D" || myScramble[i + 1] == "D'" || myScramble[i + 1] == "D2" || myScramble[i + 1] == "y" || myScramble[i + 1] == "y'" || myScramble[i + 1] == "y2"))
                    {
                        if (myScramble[i + 2] == "U'")
                        {
                            myScramble[i] = "U2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "U")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "U2")
                        {
                            myScramble[i] = "U";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "U2")
                {
                    if (myScramble[i + 1] == "U'")
                    {
                        myScramble[i] = "U";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "U2")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "U")
                    {
                        myScramble[i] = "U'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "D" || myScramble[i + 1] == "D'" || myScramble[i + 1] == "D2" || myScramble[i + 1] == "y" || myScramble[i + 1] == "y'" || myScramble[i + 1] == "y2"))
                    {
                        if (myScramble[i + 2] == "U'")
                        {
                            myScramble[i] = "U";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "U2")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "U")
                        {
                            myScramble[i] = "U'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "F")
                {
                    if (myScramble[i + 1] == "F")
                    {
                        myScramble[i] = "F2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "F'")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "F2")
                    {
                        myScramble[i] = "F'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "B" || myScramble[i + 1] == "B'" || myScramble[i + 1] == "B2"))
                    {
                        if (myScramble[i + 2] == "F")
                        {
                            myScramble[i] = "F2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "F'")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "F2")
                        {
                            myScramble[i] = "F'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "F'")
                {
                    if (myScramble[i + 1] == "F'")
                    {
                        myScramble[i] = "F2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "F")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "F2")
                    {
                        myScramble[i] = "F";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "B" || myScramble[i + 1] == "B'" || myScramble[i + 1] == "B2"))
                    {
                        if (myScramble[i + 2] == "F'")
                        {
                            myScramble[i] = "F2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "F")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "F2")
                        {
                            myScramble[i] = "F";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "F2")
                {
                    if (myScramble[i + 1] == "F'")
                    {
                        myScramble[i] = "F";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "F2")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "F")
                    {
                        myScramble[i] = "F'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "B" || myScramble[i + 1] == "B'" || myScramble[i + 1] == "B2"))
                    {
                        if (myScramble[i + 2] == "F'")
                        {
                            myScramble[i] = "F";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "F2")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "F")
                        {
                            myScramble[i] = "F'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "L")
                {
                    if (myScramble[i + 1] == "L")
                    {
                        myScramble[i] = "L2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "L'")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "L2")
                    {
                        myScramble[i] = "L'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "R" || myScramble[i + 1] == "R'" || myScramble[i + 1] == "R2"))
                    {
                        if (myScramble[i + 2] == "L")
                        {
                            myScramble[i] = "L2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "L'")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "L2")
                        {
                            myScramble[i] = "L'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "L'")
                {
                    if (myScramble[i + 1] == "L'")
                    {
                        myScramble[i] = "L2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "L")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "L2")
                    {
                        myScramble[i] = "L";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "R" || myScramble[i + 1] == "R'" || myScramble[i + 1] == "R2"))
                    {
                        if (myScramble[i + 2] == "L'")
                        {
                            myScramble[i] = "L2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "L")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "L2")
                        {
                            myScramble[i] = "L";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "L2")
                {
                    if (myScramble[i + 1] == "L'")
                    {
                        myScramble[i] = "L";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "L2")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "L")
                    {
                        myScramble[i] = "L'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "R" || myScramble[i + 1] == "R'" || myScramble[i + 1] == "R2"))
                    {
                        if (myScramble[i + 2] == "L'")
                        {
                            myScramble[i] = "L";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "L2")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "L")
                        {
                            myScramble[i] = "L'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "B")
                {
                    if (myScramble[i + 1] == "B")
                    {
                        myScramble[i] = "B2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "B'")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "B2")
                    {
                        myScramble[i] = "B'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "F" || myScramble[i + 1] == "F'" || myScramble[i + 1] == "F2"))
                    {
                        if (myScramble[i + 2] == "B")
                        {
                            myScramble[i] = "B2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "B'")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "B2")
                        {
                            myScramble[i] = "B'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "B'")
                {
                    if (myScramble[i + 1] == "B'")
                    {
                        myScramble[i] = "B2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "B")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "B2")
                    {
                        myScramble[i] = "B";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "F" || myScramble[i + 1] == "F'" || myScramble[i + 1] == "F2"))
                    {
                        if (myScramble[i + 2] == "B'")
                        {
                            myScramble[i] = "B2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "B")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "B2")
                        {
                            myScramble[i] = "B";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "B2")
                {
                    if (myScramble[i + 1] == "B'")
                    {
                        myScramble[i] = "B";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "B2")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "B")
                    {
                        myScramble[i] = "B'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "F" || myScramble[i + 1] == "F'" || myScramble[i + 1] == "F2"))
                    {
                        if (myScramble[i + 2] == "B'")
                        {
                            myScramble[i] = "B";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "B2")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "B")
                        {
                            myScramble[i] = "B'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "D")
                {
                    if (myScramble[i + 1] == "D")
                    {
                        myScramble[i] = "D2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "D'")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "D2")
                    {
                        myScramble[i] = "D'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "U" || myScramble[i + 1] == "U'" || myScramble[i + 1] == "U2" || myScramble[i + 1] == "y" || myScramble[i + 1] == "y'" || myScramble[i + 1] == "y2"))
                    {
                        if (myScramble[i + 2] == "D")
                        {
                            myScramble[i] = "D2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "D'")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "D2")
                        {
                            myScramble[i] = "D'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "D'")
                {
                    if (myScramble[i + 1] == "D'")
                    {
                        myScramble[i] = "D2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "D")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "D2")
                    {
                        myScramble[i] = "D";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "U" || myScramble[i + 1] == "U'" || myScramble[i + 1] == "U2" || myScramble[i + 1] == "y" || myScramble[i + 1] == "y'" || myScramble[i + 1] == "y2"))
                    {
                        if (myScramble[i + 2] == "D'")
                        {
                            myScramble[i] = "D2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "D")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "D2")
                        {
                            myScramble[i] = "D";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "D2")
                {
                    if (myScramble[i + 1] == "D'")
                    {
                        myScramble[i] = "D";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "D2")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "D")
                    {
                        myScramble[i] = "D'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "U" || myScramble[i + 1] == "U'" || myScramble[i + 1] == "U2" || myScramble[i + 1] == "y" || myScramble[i + 1] == "y'" || myScramble[i + 1] == "y2"))
                    {
                        if (myScramble[i + 2] == "D'")
                        {
                            myScramble[i] = "D";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "D2")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "D")
                        {
                            myScramble[i] = "D'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "y")
                {
                    if (myScramble[i + 1] == "y")
                    {
                        myScramble[i] = "y2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "y'")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "y2")
                    {
                        myScramble[i] = "y'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "U" || myScramble[i + 1] == "U'" || myScramble[i + 1] == "U2" || myScramble[i + 1] == "D" || myScramble[i + 1] == "D'" || myScramble[i + 1] == "D2"))
                    {
                        if (myScramble[i + 2] == "y")
                        {
                            myScramble[i] = "y2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "y'")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "y2")
                        {
                            myScramble[i] = "y'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "y'")
                {
                    if (myScramble[i + 1] == "y'")
                    {
                        myScramble[i] = "y2";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "y")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "y2")
                    {
                        myScramble[i] = "y";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "U" || myScramble[i + 1] == "U'" || myScramble[i + 1] == "U2" || myScramble[i + 1] == "D" || myScramble[i + 1] == "D'" || myScramble[i + 1] == "D2"))
                    {
                        if (myScramble[i + 2] == "y'")
                        {
                            myScramble[i] = "y2";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "y")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "y2")
                        {
                            myScramble[i] = "y";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
                else if (myScramble[i] == "y2")
                {
                    if (myScramble[i + 1] == "y'")
                    {
                        myScramble[i] = "y";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "y2")
                    {
                        myScramble.RemoveAt(i + 1);
                        myScramble.RemoveAt(i);
                        i = 0;
                    }
                    else if (myScramble[i + 1] == "y")
                    {
                        myScramble[i] = "y'";
                        myScramble.RemoveAt(i + 1);
                        i = 0;
                    }

                    if (i <= myScramble.Count - 3 && (myScramble[i + 1] == "U" || myScramble[i + 1] == "U'" || myScramble[i + 1] == "U2" || myScramble[i + 1] == "D" || myScramble[i + 1] == "D'" || myScramble[i + 1] == "D2"))
                    {
                        if (myScramble[i + 2] == "y'")
                        {
                            myScramble[i] = "y";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "y2")
                        {
                            myScramble.RemoveAt(i + 2);
                            myScramble.RemoveAt(i);
                            i = 0;
                        }
                        else if (myScramble[i + 2] == "y")
                        {
                            myScramble[i] = "y'";
                            myScramble.RemoveAt(i + 2);
                            i = 0;
                        }
                    }
                }
            }
            string result = "";
            for (int i = 0; i < myScramble.Count; i++)
            {
                result += myScramble[i] + " ";
            }
            return result;
        }
        public static string RandomScrambleGenerator()
        {
            List<string> myScramble = new List<string>();
            Random random = new Random();
            string [] moves = new string[] { "R" ,"R'","R2", "U","U'","U2", "F","F'","F2", "D","D'","D2", "L","L'","L2","B","B'","B2"};
            string result;
            while (true)
            {
                myScramble.Add(moves[random.Next(0,moves.Length-1)]);
                result = OptimizedStepsRandom(ref myScramble);
                if (myScramble.Count >= 25) break;
            }
            return result;
        }
        public static string GetStatusFromScramble(string scramble)
        {
            lstMerged.Clear();
            InitializeCube();
            Execute(scramble, ref myCube);
            string s = "";
            for(int i = 0; i < 54; i++)
            {
                if (myCube[i] == Colors.white) s += "0";
                else if (myCube[i] == Colors.green) s += "1";
                else if (myCube[i] == Colors.red) s += "2";
                else if (myCube[i] == Colors.blue) s += "3";
                else if (myCube[i] == Colors.orange) s += "4";
                else if (myCube[i] == Colors.yellow) s += "5";
            }
            return s;
        }
    }
}