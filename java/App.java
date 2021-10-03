public class App 
{
    public static void main(String[] args) throws Exception 
    {
        CBlockChain chain = new CBlockChain();
        
        CData data = new CData();
        data.strName = "data1";
        chain.addBlock(data);

        data = new CData();
        data.strName = "data2";
        chain.addBlock(data);

        data = new CData();
        data.strName = "data3";
        chain.addBlock(data);

            // 모든 자료를 보여준다.
        chain.showAllData();


    }
}
