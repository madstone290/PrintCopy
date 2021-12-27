using SimPrinter.Core;
using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintOrder();
        }

        public void PrintOrder()
        {
            ILabelPrinter labelPrinter = LabelPrinterCollection.BixolonSrp770;

            OrderModel order = new OrderModel()
            {
                Contact = "010-6321-66645",
                Address = "수성구 상동 72 정화우방팔레스 102동207호(수성구 수성로 135 정화우방팔레스 102동207호)",
                Memo = "[배민 선결제완료] (수저포크 X) (배달요청)1층현관 비반207#2502#입니다.누륵고 올라오셔서 현관앞에 두시고 벨 한번만 눌러주세요. 배달의민족 콜센터: 1600-0987",
                Products = new ProductModel[]
                {
                    new ProductModel()
                    {
                        Type = ProductType.Pizza,
                        Name = "정통 Set L",
                        Quantity = "1",
                        SetComponents = new List<string>()
                        {
                            "수퍼디럭스콤비네이션피자",
                            "코카콜라",
                            "치즈오븐스파게티"
                        }

                    },
                    new ProductModel()
                    {
                        Name = "콤비네이션 L",
                        SetComponents = new List<string>(),
                        Quantity = "2", 
                        Type = ProductType.Pizza,
                    },
                    new ProductModel()
                    {
                        Type = ProductType.Other,
                        Name = "배달료 3000"
                    },
                    new ProductModel()
                    {
                        Type = ProductType.Other,
                        Name = "스프라이트 m 2개"
                    },
                      new ProductModel()
                    {
                        Type = ProductType.Other,
                        Name = "스페기티",
                        Quantity  = "3"
                    },
                }
            };

            labelPrinter.Print(order);
        }
    }
}
