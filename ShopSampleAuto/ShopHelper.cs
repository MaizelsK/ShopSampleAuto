using System;
using System.Data;

namespace ShopSampleAuto
{
    class ShopHelper
    {
        public ShopHelper()
        {
            ShopDb = CreateShopDataSet();
        }

        public DataSet ShopDb { get; set; }

        private DataSet CreateShopDataSet()
        {
            DataSet shopDb = new DataSet("ShopDB");

            // Таблица покупателей
            DataTable customers = new DataTable("Customers");
            customers.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("firstName", typeof(string)),
                new DataColumn("surName", typeof(string))
            });
            customers.Columns["id"].AutoIncrement = true;
            customers.PrimaryKey = new DataColumn[] { customers.Columns["id"] };

            // Таблица продавцов
            DataTable sellers = new DataTable("Sellers");
            sellers.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("firstName", typeof(string)),
                new DataColumn("surName", typeof(string))
            });
            sellers.Columns["id"].AutoIncrement = true;
            sellers.PrimaryKey = new DataColumn[] { sellers.Columns["id"] };

            // Создание продуктов
            DataTable products = new DataTable("Products");
            products.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("name", typeof(string)),
                new DataColumn("description", typeof(string)),
                new DataColumn("price", typeof(decimal)),
                new DataColumn("createDate", typeof(DateTime))
            });
            products.Columns["id"].AutoIncrement = true;
            products.Columns["createDate"].DefaultValue = DateTime.Now;
            products.PrimaryKey = new DataColumn[] { products.Columns["id"] };

            // Таблица заказов
            DataTable orders = new DataTable("Orders");
            orders.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("idCustomer", typeof(int)),
                new DataColumn("idSeller", typeof(int)),
                new DataColumn("idProduct", typeof(int)),
                new DataColumn("orderDate", typeof(DateTime))
            });
            orders.Columns["id"].AutoIncrement = true;
            orders.Columns["orderDate"].DefaultValue = DateTime.Now;
            orders.PrimaryKey = new DataColumn[] { orders.Columns["id"] };

            // Создание ограничений
            shopDb.Tables.AddRange(new DataTable[] { customers, sellers, orders, products });
            shopDb.Relations.AddRange(new DataRelation[]
            {
                new DataRelation("FK_ORDERS_IDCUSTOMERS", customers.Columns["id"],
                                                        orders.Columns["idCustomer"]),
                new DataRelation("FK_ORDERS_IDSELLERS", sellers.Columns["id"],
                                                        orders.Columns["idSeller"]),
                new DataRelation("FK_ORDERS_IDPRODUCT", products.Columns["id"],
                                                        orders.Columns["idProduct"]),
            });

            return shopDb;
        }
    }
}
