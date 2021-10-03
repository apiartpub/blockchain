using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CBlockChain chain = new CBlockChain();

            SData data = new SData();
            data.sName = "data1";
            chain.addBlock(data);

            data = new SData();
            data.sName = "data2";
            chain.addBlock(data);

            data = new SData();
            data.sName = "data3";
            chain.addBlock(data);

            // 모든 자료를 보여준다.
            chain.showAllData();

            System.Console.ReadLine();
        }
    }
}
