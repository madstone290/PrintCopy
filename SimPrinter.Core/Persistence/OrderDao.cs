using Newtonsoft.Json;
using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.Persistence
{
    public class OrderDao
    {
        private const string directoryName = "Data";
        private const string baseFileName = "OrderProduct";
        private const string fileExe = "json";

        /// <summary>
        /// 디렉토리 경로
        /// </summary>
        private readonly string directoryPath;

        public OrderDao(string basePath)
        {
            directoryPath = Path.Combine(basePath, directoryName);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        string GetFilePath(DateTime date)
        {
            string fileName = string.Format("{0}-{1}.{2}", baseFileName, date.ToString("yyyy-MM-dd"), fileExe);

            return Path.Combine(directoryPath, fileName);
        }

        public int GetOrderNumber(DateTime date)
        {
            List<OrderModel> orderProducts = GetOrders(date);

            return orderProducts.OrderBy(x => x.OrderNumber)
                .Select(x => x.OrderNumber)
                .LastOrDefault() + 1;
        }

        /// <summary>
        /// 주문저장
        /// </summary>
        /// <param name="date">저장일</param>
        /// <param name="order">주문</param>
        public void Save(DateTime date, OrderModel order)
        {
            List<OrderModel> orderProducts = GetOrders(date);
            orderProducts.Add(order);

            string json = JsonConvert.SerializeObject(orderProducts, Formatting.Indented);

            File.WriteAllText(GetFilePath(date), json);
        }

        public List<OrderModel> GetOrders(DateTime date)
        {
            string filePath = GetFilePath(date);
            if (!File.Exists(filePath))
                return new List<OrderModel>();

            string json = File.ReadAllText(filePath);

            List<OrderModel> orderProducts;
            try
            {
                orderProducts = JsonConvert.DeserializeObject<List<OrderModel>>(json);
            }
            catch
            {
                orderProducts = new List<OrderModel>();
                //TODO log
            }
            return orderProducts;
        }



    }
}
