using System.Data;

namespace ShopSampleAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDb = new ShopHelper().ShopDb;
        }
    }
}
