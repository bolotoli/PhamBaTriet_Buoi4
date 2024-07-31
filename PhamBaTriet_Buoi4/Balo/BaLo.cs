using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách các vật phẩm với giá trị và trọng lượng tương ứng
            List<Item> items = new List<Item>
        {
            new Item { Value = 60, Weight = 10 },
            new Item { Value = 100, Weight = 20 },
            new Item { Value = 120, Weight = 30 }
        };

            int capacity = 50; // Sức chứa của ba lô

            // Tính giá trị lớn nhất có thể đưa vào ba lô
            double maxValue = GreedyKnapsack(capacity, items);
            Console.WriteLine("Gia tri lon nhat trong balo = " + maxValue); // In kết quả ra màn hình
            Console.ReadLine();
        }

        // Lớp biểu diễn một vật phẩm với giá trị và trọng lượng
        public class Item
        {
            public int Value { get; set; } // Giá trị của vật phẩm
            public int Weight { get; set; } // Trọng lượng của vật phẩm
            public double Ratio { get { return (double)Value / Weight; } } // Tỷ lệ giá trị trên trọng lượng
        }

        // Hàm giải thuật tham lam để tính giá trị lớn nhất có thể đưa vào ba lô
        public static double GreedyKnapsack(int capacity, List<Item> items)
        {
            // Sắp xếp các vật phẩm theo tỷ lệ giá trị trên trọng lượng giảm dần
            items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

            double totalValue = 0; // Tổng giá trị của các vật phẩm trong ba lô
            int currentWeight = 0; // Trọng lượng hiện tại của ba lô

            // Duyệt qua từng vật phẩm
            foreach (var item in items)
            {
                if (currentWeight + item.Weight <= capacity) // Nếu còn đủ chỗ trong ba lô
                {
                    currentWeight += item.Weight; // Thêm vật phẩm vào ba lô
                    totalValue += item.Value; // Cộng giá trị của vật phẩm vào tổng giá trị
                }
                else // Nếu không còn đủ chỗ trong ba lô
                {
                    int remainingWeight = capacity - currentWeight; // Tính trọng lượng còn lại của ba lô
                    totalValue += item.Value * ((double)remainingWeight / item.Weight); // Thêm một phần của vật phẩm vào ba lô
                    break; // Kết thúc quá trình
                }
            }

            return totalValue; // Trả về tổng giá trị lớn nhất có thể đưa vào ba lô
        }
    }
}