import java.util.List;
import java.util.ArrayList;
import java.security.MessageDigest;

public class CBlockChain 
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
        this.m_blocks = new ArrayList<CBlock>();
    }


    /**
     * 해시함수. 
     * 다양한 방법이 사용될 수 있다. 여기서는 간단하게 그 블록이 가지고 있는 모든 자료를 다 한줄의 문자열로 이어 붙여서 해시한다.
     */
    protected String hash(CBlock block)
    {
        String tempString = block.m_data.strName + block.m_previousHash;
        byte[] tempSource = tempString.getBytes();
        
        String strOutput = "";

        try
        {
            MessageDigest md = MessageDigest.getInstance("MD5");
	        md.update(tempSource);
	        byte tempHash[] = md.digest();
            
	        StringBuffer sb = new StringBuffer();
	        for (int i = 0; i < tempHash.length; i++) 
            {
	            sb.append(Integer.toString((tempHash[i] & 0xff) + 0x100, 16).substring(1));
	        }

            strOutput = sb.toString();
        }
        catch(Exception ex)
        {

        }

        return strOutput;
    }

    /**
     * 데이터 블록을 하나 추가한다.
     */
    public Boolean addBlock(CData data)
    {
        // 블록에 데이터를 담는다.
        CBlock block = new CBlock();
        block.m_data = new CData();
        block.m_data.strName = data.strName;

        // 마지막 블록 = 새로 담을 블록의 이전 블록. 마지막 블록이 있으면 그 마지막 블록을 해시한다.
        CBlock lastBlock = null;
        
        try
        {
            lastBlock = m_blocks.get(m_blocks.size() - 1);
        }
        catch(Exception ex)
        {
            //System.Console.WriteLine("오류발생: " + ex.ToString());
        }
        
        if (null != lastBlock)
        { 
            // 마지막 블록의 해시값을 새 블록에 적는다.
            block.m_previousHash = hash(lastBlock);
        }

        // 블록체인의 리스트에 새로운 블록을 추가한다.
        this.m_blocks.add(block);

        return true;
    }


    /**
     * 블록체인에 저장된 모든 데이터 목록을 보여준다.
     */
    public void showAllData()
    {
        int cData = this.m_blocks.size();

        for (int i=0; i<cData; i++)
        {
            //System.Console.WriteLine(this.m_blocks[i]);
            System.out.println("[" + i + "] " + this.m_blocks.get(i).m_data.strName + 
                "   | 이전 블록 hash = " + this.m_blocks.get(i).m_previousHash);
            System.out.println("----------------------------");
        }
    }
}
