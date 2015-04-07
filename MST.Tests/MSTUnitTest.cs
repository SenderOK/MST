using System;
using System.IO;
using System.Reflection;

using NUnit;
using NUnit.Framework;

using MST;

namespace MST.Tests
{    
    [TestFixture]
    public class TestClass
    {
        static int RunMST(StreamReader input)
        {
            string[] s = input.ReadLine().Split(' ');
            int n = Int32.Parse(s[0]);
            int m = Int32.Parse(s[1]);

            double[][] g = new double[n][];
            for (int i = 0; i < n; ++i)
            {
                g[i] = new double[n];
                for (int j = 0; j < n; ++j)
                {
                    g[i][j] = MST.Inf;
                }
            }

            for (int i = 0; i < m; ++i)
            {
                s = input.ReadLine().Split(' ');
                int x = Int32.Parse(s[0]) - 1,
                    y = Int32.Parse(s[1]) - 1,
                    w = Int32.Parse(s[2]);
                g[x][y] = w;
                g[y][x] = w;
            }

            MSTResults res = MST.FindMST(g);            
            return Convert.ToInt32(res.Weight);
        }

        static int GetAnswer(StreamReader input)
        {
            string[] s = input.ReadLine().Split(' ');
            return Int32.Parse(s[0]);
        }

        static StreamReader GetReader(string InputFilename)
        {
            var assembly = Assembly.GetExecutingAssembly();            
            string ResourceName = "MST.Tests.Resources." + InputFilename;
            Stream s = assembly.GetManifestResourceStream(ResourceName);
            return new StreamReader(s);
        }

        [TestCase]
        public void Test01()
        {
            int AnsMST = RunMST(GetReader("Input01.txt"));
            
            int AnsCorr = GetAnswer(GetReader("Answer01.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }

        [TestCase]
        public void Test02()
        {
            int AnsMST = RunMST(GetReader("Input02.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer02.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }

        [TestCase]
        public void Test03()
        {
            int AnsMST = RunMST(GetReader("Input03.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer03.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }

        [TestCase]
        public void Test04()
        {
            int AnsMST = RunMST(GetReader("Input04.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer04.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }

        [TestCase]
        public void Test05()
        {
            int AnsMST = RunMST(GetReader("Input05.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer05.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }


        [TestCase]
        public void Test06()
        {
            int AnsMST = RunMST(GetReader("Input06.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer06.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }

        [TestCase]
        public void Test07()
        {
            int AnsMST = RunMST(GetReader("Input07.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer07.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }

        [TestCase]
        public void Test08()
        {
            int AnsMST = RunMST(GetReader("Input08.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer08.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }

        [TestCase]
        public void Test09()
        {
            int AnsMST = RunMST(GetReader("Input09.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer09.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }

        [TestCase]
        public void Test10()
        {
            int AnsMST = RunMST(GetReader("Input10.txt"));
            int AnsCorr = GetAnswer(GetReader("Answer10.txt"));
            Assert.AreEqual(AnsCorr, AnsMST);
        }


    }    

}
