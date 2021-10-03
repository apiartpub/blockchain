using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace ConsoleApp1
{
    class CBlockChain
    {
        /**
         * 블록체인의 몸체. 리스트형식으로 관리한다.
         */
        public List<CBlock> m_blocks;


        /**
         * 생성자
         */
        public CBlockChain()
        {
            this.m_blocks = new List<CBlock>();
        }

        /**
         * 해시함수. 
         * 다양한 방법이 사용될 수 있다. 여기서는 간단하게 그 블록이 가지고 있는 모든 자료를 다 한줄의 문자열로 이어 붙여서 해시한다.
         */
        protected string hash(CBlock block)
        {
            string tempString = block.m_data.sName + block.m_previousHash;
            byte[] tempSource = ASCIIEncoding.ASCII.GetBytes(tempString);
            byte[] tempHash = new MD5CryptoServiceProvider().ComputeHash(tempSource);

            StringBuilder sOutput = new StringBuilder(tempString.Length);
            for (int i=0; i<tempHash.Length; i++)
            {
                sOutput.Append(tempHash[i].ToString("X2"));
            }

            return sOutput.ToString();           
        }

        /**
         * 데이터 블록을 하나 추가한다.
         */
        public bool addBlock(SData data)
        {
            // 블록에 데이터를 담는다.
            CBlock block = new CBlock();
            block.m_data.sName = data.sName;

            // 마지막 블록 = 새로 담을 블록의 이전 블록. 마지막 블록이 있으면 그 마지막 블록을 해시한다.
            CBlock lastBlock = null;
            
            try
            {
                lastBlock = m_blocks.Last<CBlock>();
            }
            catch(Exception ex)
            {
                //System.Console.WriteLine("오류발생: " + ex.ToString());
            }
            
            if (null != lastBlock)
            { 
                // 마지막 블록의 해시값을 새 블록에 적는다.
                block.m_previousHash = this.hash(lastBlock);
            }

            // 블록체인의 리스트에 새로운 블록을 추가한다.
            this.m_blocks.Add(block);

            return true;
        }


        /**
         * 블록체인에 저장된 모든 데이터 목록을 보여준다.
         */
        public void showAllData()
        {
            int cData = this.m_blocks.Count;

            for (int i=0; i<cData; i++)
            {
                //System.Console.WriteLine(this.m_blocks[i]);
                System.Console.WriteLine("[" + i + "] " + this.m_blocks[i].m_data.sName + 
                    "   | 이전 블록 hash = " + this.m_blocks[i].m_previousHash);
                System.Console.WriteLine("----------------------------");
            }
        }
    }
}
